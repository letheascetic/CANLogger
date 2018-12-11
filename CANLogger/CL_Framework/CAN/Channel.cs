using log4net;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace CL_Framework
{
    public class Channel
    {
        private static readonly ILog Logger = log4net.LogManager.GetLogger("info");
        private static readonly uint DEFAULT_RCV_TIMER_INTERVAL = 50;
        private static readonly uint DEFAULT_STATUS_ERRORINFO_TIMER_INTERVAL = 1000;
        private static readonly uint DEFAULT_STATUS_ERRORINFO_STACK_MAXIMUM = 100;
        //------------------------------------------------------------------------------
        private uint channelIndex;
        private string channelName;
        private int baudRate;
        private bool isInitialized = false;
        private bool isStarted = false;
        
        private Device parentDevice = null;
        private InitConfig initConfig;

        private ConcurrentQueue<CANErrInfo> pCANErrorInfoQueue = new ConcurrentQueue<CANErrInfo>();
        private ConcurrentQueue<CANStatus> pCANStatusQueue = new ConcurrentQueue<CANStatus>();
        private ConcurrentQueue<CANOBJ> pCANRevBufQueue = new ConcurrentQueue<CANOBJ>();

        private Timer pStatusTimer;
        private Timer pRcvTimer;
        //------------------------------------------------------------------------------
        public InitConfig Config
        { get { return initConfig; } }

        public uint ChannelIndex
        { get { return channelIndex; } }

        public string ChannelName
        { get { return channelName; } }

        public Device ParentDevice
        { get { return parentDevice; } }

        public int BaudRate
        { get { return baudRate; } }

        public bool IsStarted
        { get { return isStarted; } }

        public CAN_MODE Mode
        { get { return (CAN_MODE)Enum.ToObject(typeof(CAN_MODE), this.initConfig.Mode); } }

        public bool IsInitialized
        { get { return isInitialized; } }

        public Channel(uint channelIndex, string channelName, Device parentDevice)
        {
            this.isStarted = false;
            this.isInitialized = false;

            this.pStatusTimer = new Timer();
            this.pStatusTimer.Interval = DEFAULT_STATUS_ERRORINFO_TIMER_INTERVAL;
            this.pStatusTimer.Elapsed += StatusTimer_Elapsed;

            this.pRcvTimer = new Timer();
            this.pRcvTimer.Interval = DEFAULT_RCV_TIMER_INTERVAL;
            this.pRcvTimer.Elapsed += RcvTimer_Elapsed;

            this.channelIndex = channelIndex;
            this.channelName = channelName;
            this.parentDevice = parentDevice;

            this.initConfig = CAN.CreateBasicInitConfig();
            this.baudRate = CAN.CHANNEL_DEFAULT_BAUDRATE;

            this.InitCAN(this.baudRate, ref this.initConfig);

            this.pStatusTimer.Start();
            this.pRcvTimer.Start();
        }

        public uint InitCAN(int baudRate, ref InitConfig initConfig)
        {
            InitConfig config = CAN.CreateBasicInitConfig();
            CAN.ConfigBaudRate(baudRate, ref config);

            if (config.Timing0 != initConfig.Timing0 || config.Timing1 != initConfig.Timing1)
            {
                Logger.Info(string.Format("baudrate[{0}] and initConfig[0x{1}:0x{2}] not match",
                    baudRate, initConfig.Timing0.ToString("x"), initConfig.Timing1.ToString("x")));
                return (uint)CAN_RESULT.ERR_UNKNOWN;
            }

            this.baudRate = baudRate;
            this.initConfig = initConfig;
            if (CANDLL.InitCAN((UInt32)parentDevice.DeviceType, parentDevice.DeviceIndex, channelIndex, ref initConfig) == CANDLLResult.STATUS_OK)
            {
                Logger.Info(string.Format("init channel[{0}] successful.", channelName));
                this.isInitialized = true;
                return (uint)CAN_RESULT.SUCCESSFUL;
            }

            this.isInitialized = false;
            uint result = (uint)CAN_RESULT.ERR_UNKNOWN;
            CANErrInfo pCANErrorInfo;
            if (ReadErrInfo(out pCANErrorInfo) == (uint)CAN_RESULT.SUCCESSFUL)
            {
                result = pCANErrorInfo.ErrCode;
            }

            Logger.Info(string.Format("init channel[{0}] failed: [0x{1}].", channelName, result.ToString("x")));
            return result;
        }

        public uint ReadErrInfo(out CANErrInfo canErrInfo)
        {
            if (CANDLL.ReadErrInfo((UInt32)parentDevice.DeviceType, parentDevice.DeviceIndex, 
                (int)channelIndex, out canErrInfo) == CANDLLResult.STATUS_OK)
            {
                Logger.Info(string.Format("channel[{0}] read error info successful.", channelName));
                return (uint)CAN_RESULT.SUCCESSFUL;
            }
            Logger.Info(string.Format("channel[{0}] read error info failed.", channelName));
            return (uint)CAN_RESULT.ERR_UNKNOWN;
        }

        public uint ReadCanStatus(out CANStatus canStatus)
        {
            if (CANDLL.ReadCanStatus((UInt32)parentDevice.DeviceType, parentDevice.DeviceIndex,
                channelIndex, out canStatus) == CANDLLResult.STATUS_OK)
            {
                Logger.Info(string.Format("channel[{0}] read can status successful.", channelName));
                return (uint)CAN_RESULT.SUCCESSFUL;
            }
            Logger.Info(string.Format("channel[{0}] read can status failed.", channelName));
            return (uint)CAN_RESULT.ERR_UNKNOWN;
        }

        public uint GetReference(UInt32 refType, IntPtr data)
        {
            if (CANDLL.GetReference((UInt32)parentDevice.DeviceType, parentDevice.DeviceIndex,
                channelIndex, refType, data) == CANDLLResult.STATUS_OK)
            {
                Logger.Info(string.Format("channel[{0}] read reference successful.", channelName));
                return (uint)CAN_RESULT.SUCCESSFUL;
            }
            Logger.Info(string.Format("channel[{0}] read reference failed.", channelName));
            return (uint)CAN_RESULT.ERR_UNKNOWN;
        }

        public uint SetReference(UInt32 refType, IntPtr data)
        {
            if (CANDLL.SetReference((uint)parentDevice.DeviceType, parentDevice.DeviceIndex,
                channelIndex, refType, data) == CANDLLResult.STATUS_OK)
            {
                Logger.Info(string.Format("channel[{0}] set reference successful.", channelName));
                return (uint)CAN_RESULT.SUCCESSFUL;
            }

            CANErrInfo pCANErrorInfo;
            uint result = (uint)CAN_RESULT.ERR_UNKNOWN;
            if (ReadErrInfo(out pCANErrorInfo) == (uint)CAN_RESULT.SUCCESSFUL)
            {
                result = pCANErrorInfo.ErrCode;
            }

            Logger.Info(string.Format("channel[{0}] set reference failed: [0x{1}].", channelName, result.ToString("x")));
            return result;
        }

        public uint GetReceiveNum()
        {
            return CANDLL.GetReceiveNum((uint)parentDevice.DeviceType, parentDevice.DeviceIndex, channelIndex);
        }

        public uint ClearBuffer()
        {
            if (CANDLL.ClearBuffer((UInt32)parentDevice.DeviceType, parentDevice.DeviceIndex,
                channelIndex) == CANDLLResult.STATUS_OK)
            {
                Logger.Info(string.Format("channel[{0}] clear buffer successful.", channelName));
                return (uint)CAN_RESULT.SUCCESSFUL;
            }

            CANErrInfo pCANErrorInfo;
            uint result = (uint)CAN_RESULT.ERR_UNKNOWN;
            if (ReadErrInfo(out pCANErrorInfo) == (uint)CAN_RESULT.SUCCESSFUL)
            {
                result = pCANErrorInfo.ErrCode;
            }

            Logger.Info(string.Format("channel[{0}] clear buffer failed: [0x{1}].", channelName, result.ToString("x")));
            return result;
        }

        public uint StartCAN()
        {
            if(this.isStarted)
            {
                Logger.Info(string.Format("channel[{0}] already start.", channelName));
                return (uint)CAN_RESULT.SUCCESSFUL;
            }

            if (CANDLL.StartCAN((UInt32)parentDevice.DeviceType, parentDevice.DeviceIndex,
                channelIndex) == CANDLLResult.STATUS_OK)
            {
                Logger.Info(string.Format("channel[{0}] start successful.", channelName));
                this.isStarted = true;
                return (uint)CAN_RESULT.SUCCESSFUL;
            }

            this.isStarted = false;
            CANErrInfo pCANErrorInfo;
            uint result = (uint)CAN_RESULT.ERR_UNKNOWN;
            if (ReadErrInfo(out pCANErrorInfo) == (uint)CAN_RESULT.SUCCESSFUL)
            {
                result = pCANErrorInfo.ErrCode;
            }

            Logger.Info(string.Format("channel[{0}] start failed: [0x{1}].", channelName, result.ToString("x")));
            return result;
        }

        public uint Transmit(CANOBJ[] canFrames, UInt32 canFrameLength)
        {
            if (canFrames.Length < canFrameLength)
            {
                Logger.Info(string.Format("channel[{0}] CAN frames[{1}] less than num[{2}] to send.", channelName, canFrames.Length, canFrameLength));
                canFrameLength = (uint)canFrames.Length;
            }
            uint realSendNum = CANDLL.Transmit((UInt32)parentDevice.DeviceType, parentDevice.DeviceIndex, channelIndex, canFrames, canFrameLength);
            Logger.Info(string.Format("channel[{0}] transmit [{1}/{2}] messages successful.", channelName, realSendNum, canFrameLength));
            return realSendNum;
        }

        public uint Receive(out CANOBJ[] canFrames, UInt32 canFrameLength, Int32 waitMilliseconds)
        {
            uint realRcvNum = CANDLL.Receive((UInt32)parentDevice.DeviceType, parentDevice.DeviceIndex, channelIndex,
                out canFrames, canFrameLength, waitMilliseconds);
            if (realRcvNum != uint.MaxValue)
            {
                Logger.Info(string.Format("channel[{0}] receive [{1}] messages successful.", channelName, realRcvNum));
                return realRcvNum;
            }

            CANErrInfo pCANErrorInfo;
            uint result = (uint)CAN_RESULT.ERR_UNKNOWN;
            if (ReadErrInfo(out pCANErrorInfo) == (uint)CAN_RESULT.SUCCESSFUL)
            {
                result = pCANErrorInfo.ErrCode;
            }

            Logger.Info(string.Format("channel[{0}] receive failed: [0x{1}].", channelName, pCANErrorInfo.ErrCode.ToString("x")));
            return realRcvNum;
        }

        public uint ResetCAN()
        {
            if (!this.isStarted)
            {
                Logger.Info(string.Format("channel[{0}] already reset.", channelName));
                return (uint)CAN_RESULT.SUCCESSFUL;
            }

            if (CANDLL.ResetCAN((UInt32)parentDevice.DeviceType, parentDevice.DeviceIndex,
                channelIndex) == CANDLLResult.STATUS_OK)
            {
                Logger.Info(string.Format("channel[{0}] reset successful.", channelName));
                this.isStarted = false;
                return (uint)CAN_RESULT.SUCCESSFUL;

            }

            CANErrInfo pCANErrorInfo;
            uint result = (uint)CAN_RESULT.ERR_UNKNOWN;
            if (ReadErrInfo(out pCANErrorInfo) == (uint)CAN_RESULT.SUCCESSFUL)
            {
                result = pCANErrorInfo.ErrCode;
            }

            Logger.Info(string.Format("channel[{0}] reset failed: [0x{1}].", channelName, result.ToString("x")));
            return result;
        }

        private void StatusTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (!this.isInitialized)
            {
                return;
            }

            CANStatus pCANStatus;
            CANErrInfo pCANErrorInfo;
            this.pStatusTimer.Stop();

            try
            {
                if (ReadCanStatus(out pCANStatus) == (uint)CAN_RESULT.SUCCESSFUL)
                {
                    if (this.pCANStatusQueue.Count >= DEFAULT_STATUS_ERRORINFO_STACK_MAXIMUM)
                    {
                        ReleaseStatusQueue((int)DEFAULT_STATUS_ERRORINFO_STACK_MAXIMUM >> 1);
                    }
                    this.pCANStatusQueue.Enqueue(pCANStatus);
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Read CAN Status Exception", ex);
            }

            try
            {
                if (ReadErrInfo(out pCANErrorInfo) == (uint)CAN_RESULT.SUCCESSFUL)
                {
                    if (this.pCANErrorInfoQueue.Count >= DEFAULT_STATUS_ERRORINFO_STACK_MAXIMUM)
                    {
                        ReleaseErrorInfoQueue((int)DEFAULT_STATUS_ERRORINFO_STACK_MAXIMUM >> 1);
                    }
                    this.pCANErrorInfoQueue.Enqueue(pCANErrorInfo);
                }
            }
            catch(Exception ex)
            {
                Logger.Error("Read CAN Error Info Exception", ex);
            }

            this.pStatusTimer.Start();
        }

        private void RcvTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if(!this.isStarted)
            {
                return;
            }

            this.pRcvTimer.Stop();

            try
            {
                uint numToRcv = GetReceiveNum();
                if (numToRcv <= 0)
                {
                    return;
                }

                Logger.Info(string.Format("channel[{0}] has [{1}] messages to receive.", channelName, numToRcv));

                int waitTime = 1000;
                CANOBJ[] pCANFrames = new CANOBJ[numToRcv];
                uint realRcvNum = Receive(out pCANFrames, numToRcv, waitTime);

                if (realRcvNum == uint.MaxValue)
                {
                    return;
                }

                Logger.Info(string.Format("channel[{0}] current rev buf queue size: [{1}].", channelName, this.pCANRevBufQueue.Count));
                int numToRelease = this.pCANRevBufQueue.Count + (int)realRcvNum - (int)CAN.CHANNEL_REC_BUF_MAXIMUM;
                if (numToRelease > 0)
                {
                    ReleaseRcvBufQueue(numToRelease);
                }
                
                for (uint index = 0; index < realRcvNum; index++)
                {
                    this.pCANRevBufQueue.Enqueue(pCANFrames[index]);
                }

            }
            catch (Exception ex)
            {
                Logger.Info(string.Format("channel[{0}] receive messages exception.", channelName), ex);
            }
            finally
            {
                this.pRcvTimer.Start();
            }
        }

        private void ReleaseRcvBufQueue(int numToRelease)
        {
            Logger.Info(string.Format("channel[{0}] release rcv buf queue size: [{1}].", channelName, numToRelease));
            CANOBJ pCANOBJ;
            for (int i = 0; i < numToRelease; i++)
            {
                this.pCANRevBufQueue.TryDequeue(out pCANOBJ);
            }
        }

        private void ReleaseStatusQueue(int numToRelease)
        {
            Logger.Info(string.Format("channel[{0}] release status queue size: [{1}].", channelName, numToRelease));
            CANStatus pCANStatus;
            for (int i = 0; i < numToRelease; i++)
            {
                this.pCANStatusQueue.TryDequeue(out pCANStatus);
            }
        }

        private void ReleaseErrorInfoQueue(int numToRelease)
        {
            Logger.Info(string.Format("channel[{0}] release error info queue size: [{1}].", channelName, numToRelease));
            CANErrInfo pCANErrorInfo;
            for (int i = 0; i < numToRelease; i++)
            {
                this.pCANErrorInfoQueue.TryDequeue(out pCANErrorInfo);
            }
        }

    }
}
