using log4net;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Timers;

namespace CL_Framework
{
    public class Channel
    {
        ///////////////////////////////////////////////////////////////////////////////////////////
        private static readonly ILog Logger = log4net.LogManager.GetLogger("info");
        private static readonly uint DEFAULT_RCV_TIMER_INTERVAL = 50;
        private static readonly uint DEFAULT_STATUS_ERRORINFO_TIMER_INTERVAL = 1000;
        private static readonly uint DEFAULT_STATUS_ERRORINFO_STACK_MAXIMUM = 10;
        private static readonly uint DEFAULT_RESEND_INTERVAL = 3000;     //发送失败重新发送间隔(ms)
        ///////////////////////////////////////////////////////////////////////////////////////////
        private uint m_ChannelIndex;
        private string m_ChannelName;
        private int m_BaudRate;
        private bool m_IsInitialized = false;
        private bool m_IsStarted = false;
        private Device p_ParentDevice = null;
        private INIT_CONFIG p_InitConfig;
        private ConcurrentQueue<CAN_ERR_INFO> p_CANErrorInfoQueue = new ConcurrentQueue<CAN_ERR_INFO>();
        private ConcurrentQueue<CAN_STATUS> p_CANStatusQueue = new ConcurrentQueue<CAN_STATUS>();
        private ConcurrentQueue<CAN_FRAME> p_CANRcvBufQueue = new ConcurrentQueue<CAN_FRAME>();
        private Timer p_StatusTimer;
        private Timer p_RcvTimer;
        ///////////////////////////////////////////////////////////////////////////////////////////
        public ConcurrentQueue<CAN_FRAME> RcvBufQueue
        { get { return p_CANRcvBufQueue; } }
        public INIT_CONFIG Config
        { get { return p_InitConfig; } }
        public uint ChannelIndex
        { get { return m_ChannelIndex; } }
        public string ChannelName
        { get { return m_ChannelName; } }
        public Device ParentDevice
        { get { return p_ParentDevice; } }
        public int BaudRate
        { get { return m_BaudRate; } }
        public bool IsStarted
        { get { return m_IsStarted; } }
        public CAN_MODE Mode
        { get { return (CAN_MODE)Enum.ToObject(typeof(CAN_MODE), this.p_InitConfig.Mode); } }
        public bool IsInitialized
        { get { return m_IsInitialized; } }
        ///////////////////////////////////////////////////////////////////////////////////////////
        public Channel(uint mChannelIndex, string mChannelName, Device pParentDevice)
        {
            this.m_IsStarted = false;
            this.m_IsInitialized = false;

            this.p_StatusTimer = new Timer();
            this.p_StatusTimer.Interval = DEFAULT_STATUS_ERRORINFO_TIMER_INTERVAL;
            this.p_StatusTimer.Elapsed += StatusTimer_Elapsed;

            this.p_RcvTimer = new Timer();
            this.p_RcvTimer.Interval = DEFAULT_RCV_TIMER_INTERVAL;
            this.p_RcvTimer.Elapsed += RcvTimer_Elapsed;

            this.m_ChannelIndex = mChannelIndex;
            this.m_ChannelName = mChannelName;
            this.p_ParentDevice = pParentDevice;

            this.p_InitConfig = CAN.CreateBasicInitConfig();
            this.m_BaudRate = CAN.CHANNEL_DEFAULT_BAUDRATE;

            this.InitCAN(this.m_BaudRate, ref this.p_InitConfig);

            this.p_StatusTimer.Start();
            this.p_RcvTimer.Start();
        }

        /// <summary>
        /// 初始化CAN
        /// </summary>
        /// <param name="mBaudRate">波特率</param>
        /// <param name="pInitConfig">初始化CAN的配置参数</param>
        /// <returns></returns>
        public uint InitCAN(int mBaudRate, ref INIT_CONFIG pInitConfig)
        {
            INIT_CONFIG pConfig = CAN.CreateBasicInitConfig();
            CAN.ConfigBaudRate(m_BaudRate, ref pConfig);

            if (pConfig.Timing0 != pInitConfig.Timing0 || pConfig.Timing1 != pInitConfig.Timing1)
            {
                Logger.Info(string.Format("baudrate[{0}] and initConfig[0x{1}:0x{2}] not match",
                    m_BaudRate, pInitConfig.Timing0.ToString("x"), pInitConfig.Timing1.ToString("x")));
                return (uint)CAN_RESULT.ERR_UNKNOWN;
            }

            this.m_BaudRate = mBaudRate;
            this.p_InitConfig = pInitConfig;
            if (CANDLL.InitCAN((UInt32)p_ParentDevice.DeviceType, p_ParentDevice.DeviceIndex, m_ChannelIndex, ref pInitConfig) == CAN.CAN_DLL_RESULT_SUCCESS)
            {
                Logger.Info(string.Format("init channel[{0}] successful.", m_ChannelName));
                this.m_IsInitialized = true;
                return (uint)CAN_RESULT.SUCCESSFUL;
            }

            this.m_IsInitialized = false;
            uint result = (uint)CAN_RESULT.ERR_UNKNOWN;
            CAN_ERR_INFO pCANErrorInfo = new CAN_ERR_INFO();
            if (ReadErrInfo(ref pCANErrorInfo) == (uint)CAN_RESULT.SUCCESSFUL)
            {
                result = pCANErrorInfo.ErrCode;
            }

            Logger.Info(string.Format("init channel[{0}] failed: [0x{1}].", m_ChannelName, result.ToString("x")));
            return result;
        }

        /// <summary>
        /// 读取CAN最近一次错误信息
        /// </summary>
        /// <param name="pCanErrInfo"></param>
        /// <returns></returns>
        public uint ReadErrInfo(ref CAN_ERR_INFO pCanErrInfo)
        {
            if (CANDLL.ReadErrInfo((UInt32)p_ParentDevice.DeviceType, p_ParentDevice.DeviceIndex, (int)m_ChannelIndex, ref pCanErrInfo) == CAN.CAN_DLL_RESULT_SUCCESS)
            {
                Logger.Info(string.Format("channel[{0}] read error info successful.", m_ChannelName));
                return (uint)CAN_RESULT.SUCCESSFUL;
            }
            Logger.Info(string.Format("channel[{0}] read error info failed.", m_ChannelName));
            return (uint)CAN_RESULT.ERR_UNKNOWN;
        }

        /// <summary>
        /// 读取CAN状态
        /// </summary>
        /// <param name="pCanStatus"></param>
        /// <returns></returns>
        public uint ReadCanStatus(ref CAN_STATUS pCanStatus)
        {
            if (CANDLL.ReadCanStatus((UInt32)p_ParentDevice.DeviceType, p_ParentDevice.DeviceIndex, m_ChannelIndex, ref pCanStatus) == CAN.CAN_DLL_RESULT_SUCCESS)
            {
                Logger.Info(string.Format("channel[{0}] read can status successful.", m_ChannelName));
                return (uint)CAN_RESULT.SUCCESSFUL;
            }
            Logger.Info(string.Format("channel[{0}] read can status failed.", m_ChannelName));
            return (uint)CAN_RESULT.ERR_UNKNOWN;
        }

        /// <summary>
        /// 读取CAN的指定配置参数
        /// </summary>
        /// <param name="refType">参数类型</param>
        /// <param name="data">读取到的值</param>
        /// <returns></returns>
        public uint GetReference(uint refType, ref byte data)
        {
            if (CANDLL.GetReference((UInt32)p_ParentDevice.DeviceType, p_ParentDevice.DeviceIndex, m_ChannelIndex, refType, ref data) == CAN.CAN_DLL_RESULT_SUCCESS)
            {
                Logger.Info(string.Format("channel[{0}] read reference successful.", m_ChannelName));
                return (uint)CAN_RESULT.SUCCESSFUL;
            }
            Logger.Info(string.Format("channel[{0}] read reference failed.", m_ChannelName));
            return (uint)CAN_RESULT.ERR_UNKNOWN;
        }

        /// <summary>
        /// 设置CAN的指定类型配置参数
        /// </summary>
        /// <param name="refType">参数类型</param>
        /// <param name="data">设置的值</param>
        /// <returns></returns>
        unsafe public uint SetReference(uint refType, byte* data)
        {
            if (CANDLL.SetReference((uint)p_ParentDevice.DeviceType, p_ParentDevice.DeviceIndex, m_ChannelIndex, refType, data) == CAN.CAN_DLL_RESULT_SUCCESS)
            {
                Logger.Info(string.Format("channel[{0}] set reference successful.", m_ChannelName));
                return (uint)CAN_RESULT.SUCCESSFUL;
            }

            uint result = (uint)CAN_RESULT.ERR_UNKNOWN;
            CAN_ERR_INFO pCANErrorInfo = new CAN_ERR_INFO();
            if (ReadErrInfo(ref pCANErrorInfo) == (uint)CAN_RESULT.SUCCESSFUL)
            {
                result = pCANErrorInfo.ErrCode;
            }

            Logger.Info(string.Format("channel[{0}] set reference failed: [0x{1}].", m_ChannelName, result.ToString("x")));
            return result;
        }

        /// <summary>
        /// 读取CAN接收到的帧数
        /// </summary>
        /// <returns></returns>
        private uint GetReceiveNum()
        {
            return CANDLL.GetReceiveNum((uint)p_ParentDevice.DeviceType, p_ParentDevice.DeviceIndex, m_ChannelIndex);
        }

        /// <summary>
        /// 清空CAN缓冲区
        /// </summary>
        /// <returns></returns>
        public uint ClearBuffer()
        {
            if (CANDLL.ClearBuffer((UInt32)p_ParentDevice.DeviceType, p_ParentDevice.DeviceIndex, m_ChannelIndex) == CAN.CAN_DLL_RESULT_SUCCESS)
            {
                Logger.Info(string.Format("channel[{0}] clear buffer successful.", m_ChannelName));
                return (uint)CAN_RESULT.SUCCESSFUL;
            }

            uint result = (uint)CAN_RESULT.ERR_UNKNOWN;
            CAN_ERR_INFO pCANErrorInfo = new CAN_ERR_INFO();
            if (ReadErrInfo(ref pCANErrorInfo) == (uint)CAN_RESULT.SUCCESSFUL)
            {
                result = pCANErrorInfo.ErrCode;
            }

            Logger.Info(string.Format("channel[{0}] clear buffer failed: [0x{1}].", m_ChannelName, result.ToString("x")));
            return result;
        }

        /// <summary>
        /// 启动CAN
        /// </summary>
        /// <returns></returns>
        public uint StartCAN()
        {
            if(this.m_IsStarted)
            {
                Logger.Info(string.Format("channel[{0}] already start.", m_ChannelName));
                return (uint)CAN_RESULT.SUCCESSFUL;
            }

            if (CANDLL.StartCAN((UInt32)p_ParentDevice.DeviceType, p_ParentDevice.DeviceIndex, m_ChannelIndex) == CAN.CAN_DLL_RESULT_SUCCESS)
            {
                Logger.Info(string.Format("channel[{0}] start successful.", m_ChannelName));
                this.m_IsStarted = true;
                return (uint)CAN_RESULT.SUCCESSFUL;
            }

            this.m_IsStarted = false;
            uint result = (uint)CAN_RESULT.ERR_UNKNOWN;
            CAN_ERR_INFO pCANErrorInfo = new CAN_ERR_INFO();
            if (ReadErrInfo(ref pCANErrorInfo) == (uint)CAN_RESULT.SUCCESSFUL)
            {
                result = pCANErrorInfo.ErrCode;
            }

            Logger.Info(string.Format("channel[{0}] start failed: [0x{1}].", m_ChannelName, result.ToString("x")));
            return result;
        }

        /// <summary>
        /// 发送CAN帧
        /// </summary>
        /// <param name="pCanFrames">发送的CAN帧数组</param>
        /// <param name="length">需要发送的帧数</param>
        /// <returns>成功发送的帧数</returns>
        unsafe public uint Transmit(CAN_FRAME[] pCanFrames, uint length)
        {
            uint realSendNum = 0;
            try
            {
                //设置发送失败后重发的超时时间
                uint nTimeOut = DEFAULT_RESEND_INTERVAL;
                SetReference((uint)CAN_REFERENCE_REFTYPE.CONFIG_RESEND_TIMEOUT, (byte*)&nTimeOut);

                CAN_OBJ[] pCANObjs = new CAN_OBJ[length];
                for (int index = 0; index < length; index++)
                {
                    pCANObjs[index] = pCanFrames[index].CANObj;
                }

                realSendNum = CANDLL.Transmit((uint)p_ParentDevice.DeviceType, p_ParentDevice.DeviceIndex, m_ChannelIndex, ref pCANObjs[0], (uint)pCANObjs.Length);
                Logger.Info(string.Format("channel[{0}] transmit [{1}/{2}] messages successful.", m_ChannelName, realSendNum, pCANObjs.Length));
                return realSendNum;
            }
            catch (Exception e)
            {
                Logger.Error(string.Format("channel[{0}] transmit exception.", m_ChannelName), e);
                return realSendNum;
            }
        }

        /// <summary>
        /// 接收CAN帧数据
        /// </summary>
        /// <param name="pCanFrames">接收到的帧数组</param>
        /// <param name="length">需要接收的帧数</param>
        /// <param name="waitMilliseconds">等待时间ms</param>
        /// <returns>实际接收的帧数</returns>
        public uint Receive(out CAN_FRAME[] pCanFrames, uint length, int waitMilliseconds)
        {
            uint realRcvNum = 0;
            pCanFrames = null;
            try
            {
                IntPtr pReceive = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(CAN_OBJ)) * (Int32)length);
                realRcvNum = CANDLL.Receive((uint)p_ParentDevice.DeviceType, p_ParentDevice.DeviceIndex, m_ChannelIndex, pReceive, length, waitMilliseconds);

                if (realRcvNum != uint.MaxValue)
                {
                    Logger.Info(string.Format("channel[{0}] receive [{1}] messages successful.", m_ChannelName, realRcvNum));
                    pCanFrames = new CAN_FRAME[realRcvNum];
                    for (int index = 0; index < realRcvNum; index++)
                    {
                        CAN_OBJ pCANObj = (CAN_OBJ)Marshal.PtrToStructure((IntPtr)((UInt32)pReceive + index * Marshal.SizeOf(typeof(CAN_OBJ))), typeof(CAN_OBJ));
                        pCanFrames[index] = new CAN_FRAME(pCANObj, DateTime.Now, CAN_FRAME_DIRECTION.RECEIVE, CAN_FRAME_STATUS.SUCCESS);
                    }
                    Marshal.FreeHGlobal(pReceive);
                    return realRcvNum;
                }

                Marshal.FreeHGlobal(pReceive);

                CAN_ERR_INFO pCANErrorInfo = new CAN_ERR_INFO();
                uint result = (uint)CAN_RESULT.ERR_UNKNOWN;
                if (ReadErrInfo(ref pCANErrorInfo) == (uint)CAN_RESULT.SUCCESSFUL)
                {
                    result = pCANErrorInfo.ErrCode;
                }

                Logger.Info(string.Format("channel[{0}] receive failed: [0x{1}].", m_ChannelName, result.ToString("x")));
                return realRcvNum;
            }
            catch (Exception e)
            {
                Logger.Error(string.Format("channel[{0}] receive exception.", m_ChannelName), e);
                return realRcvNum;
            }
        }

        /// <summary>
        /// 复位CAN
        /// </summary>
        /// <returns></returns>
        public uint ResetCAN()
        {
            if (!this.m_IsStarted)
            {
                Logger.Info(string.Format("channel[{0}] already reset.", m_ChannelName));
                return (uint)CAN_RESULT.SUCCESSFUL;
            }

            if (CANDLL.ResetCAN((UInt32)p_ParentDevice.DeviceType, p_ParentDevice.DeviceIndex, m_ChannelIndex) == CAN.CAN_DLL_RESULT_SUCCESS)
            {
                Logger.Info(string.Format("channel[{0}] reset successful.", m_ChannelName));
                this.m_IsStarted = false;
                return (uint)CAN_RESULT.SUCCESSFUL;
            }

            CAN_ERR_INFO pCANErrorInfo = new CAN_ERR_INFO();
            uint result = (uint)CAN_RESULT.ERR_UNKNOWN;
            if (ReadErrInfo(ref pCANErrorInfo) == (uint)CAN_RESULT.SUCCESSFUL)
            {
                result = pCANErrorInfo.ErrCode;
            }

            Logger.Info(string.Format("channel[{0}] reset failed: [0x{1}].", m_ChannelName, result.ToString("x")));
            return result;
        }

        #region private functions
        private void StatusTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (!this.m_IsInitialized)
            {
                return;
            }

            CAN_STATUS pCANStatus;
            CAN_ERR_INFO pCANErrorInfo;
            this.p_StatusTimer.Stop();

            //try
            //{
            //    if (ReadCanStatus(out pCANStatus) == (uint)CAN_RESULT.SUCCESSFUL)
            //    {
            //        if (this.pCANStatusQueue.Count >= DEFAULT_STATUS_ERRORINFO_STACK_MAXIMUM)
            //        {
            //            ReleaseStatusQueue((int)DEFAULT_STATUS_ERRORINFO_STACK_MAXIMUM >> 1);
            //        }
            //        this.pCANStatusQueue.Enqueue(pCANStatus);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Logger.Debug("Read CAN Status Exception", ex);
            //}

            //try
            //{
            //    if (ReadErrInfo(out pCANErrorInfo) == (uint)CAN_RESULT.SUCCESSFUL)
            //    {
            //        if (this.pCANErrorInfoQueue.Count >= DEFAULT_STATUS_ERRORINFO_STACK_MAXIMUM)
            //        {
            //            ReleaseErrorInfoQueue((int)DEFAULT_STATUS_ERRORINFO_STACK_MAXIMUM >> 1);
            //        }
            //        this.pCANErrorInfoQueue.Enqueue(pCANErrorInfo);
            //    }
            //}
            //catch(Exception ex)
            //{
            //    Logger.Debug("Read CAN Error Info Exception", ex);
            //}

            this.p_StatusTimer.Start();
        }

        private void RcvTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (!this.m_IsStarted)
            {
                return;
            }
            this.p_RcvTimer.Stop();
            try
            {
                uint numToRcv = GetReceiveNum();
                if (numToRcv > 0)
                {
                    Logger.Info(string.Format("channel[{0}] has [{1}] messages to receive.", m_ChannelName, numToRcv));
                    int waitTime = 100;
                    CAN_FRAME[] pCANFrames;
                    uint realRcvNum = Receive(out pCANFrames, numToRcv, waitTime);
                    if (realRcvNum != uint.MaxValue)
                    {
                        CANFramesEnqueue(pCANFrames, realRcvNum);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("channel[{0}] receive messages exception.", m_ChannelName), ex);
            }
            this.p_RcvTimer.Start();
        }

        private void CANFramesEnqueue(CAN_FRAME[] pCANFrames, uint length)
        {
            Logger.Info(string.Format("channel[{0}] current rev buf queue size: [{1}].", m_ChannelName, this.p_CANRcvBufQueue.Count));
            int numToRelease = this.p_CANRcvBufQueue.Count + (int)length - (int)CAN.CHANNEL_REC_BUF_MAXIMUM;
            if (numToRelease > 0)
            {
                Logger.Info(string.Format("channel[{0}] release rcv buf queue size: [{1}].", m_ChannelName, numToRelease));
                CAN_FRAME pCANFrame;
                for (int i = 0; i < numToRelease; i++)
                {
                    this.p_CANRcvBufQueue.TryDequeue(out pCANFrame);
                }
            }
            for (uint index = 0; index < length; index++)
            {
                this.p_CANRcvBufQueue.Enqueue(pCANFrames[index]);
            }
        }

        private void ReleaseStatusQueue(int numToRelease)
        {
            Logger.Info(string.Format("channel[{0}] release status queue size: [{1}].", m_ChannelName, numToRelease));
            CAN_STATUS pCANStatus;
            for (int i = 0; i < numToRelease; i++)
            {
                this.p_CANStatusQueue.TryDequeue(out pCANStatus);
            }
        }

        private void ReleaseErrorInfoQueue(int numToRelease)
        {
            Logger.Info(string.Format("channel[{0}] release error info queue size: [{1}].", m_ChannelName, numToRelease));
            CAN_ERR_INFO pCANErrorInfo;
            for (int i = 0; i < numToRelease; i++)
            {
                this.p_CANErrorInfoQueue.TryDequeue(out pCANErrorInfo);
            }
        }

        #endregion

    }
}
