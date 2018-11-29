using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CL_Framework
{
    public class Channel
    {
        private uint channelIndex;
        private string channelName;
        private int baudRate;
        
        private Device parentDevice;
        private InitConfig initConfig;


        public uint ChannelIndex
        { get { return channelIndex; } }

        public string ChannelName
        { get { return channelName; } }

        public int BaudRate
        { get { return baudRate; } }

        public CANMode Mode
        { get { return (CANMode)Enum.ToObject(typeof(CANMode), this.initConfig.Mode); } }


        public Channel(uint channelIndex, string channelName, Device parentDevice)
        {
            this.channelIndex = channelIndex;
            this.channelName = channelName;
            this.parentDevice = parentDevice;
            this.initConfig = CANDLL.CreateBasicInitConfig();
            this.baudRate = CANDLL.DEFAULT_BAUDRATE;
        }
        
        public CANResult InitCAN(int baudRate, ref InitConfig initConfig)
        {
            InitConfig config = CANDLL.CreateBasicInitConfig();
            CANDLL.ConfigBaudRate(baudRate, ref config);
            if (config.Timing0 != initConfig.Timing0 || config.Timing1 != initConfig.Timing1)
            {
                return CANResult.STATUS_ERR;
            }

            this.baudRate = baudRate;
            this.initConfig = initConfig;
            return CANDLL.InitCAN((UInt32)parentDevice.DeviceType, parentDevice.DeviceIndex, channelIndex, ref initConfig);
        }

        public CANResult ReadErrInfo(out CANErrInfo canErrInfo)
        {
            return CANDLL.ReadErrInfo((UInt32)parentDevice.DeviceType, parentDevice.DeviceIndex, channelIndex, out canErrInfo);
        }

        public CANResult ReadCanStatus(out CANStatus canStatus)
        {
            return CANDLL.ReadCanStatus((UInt32)parentDevice.DeviceType, parentDevice.DeviceIndex, channelIndex, out canStatus);
        }

        public CANResult GetReference(UInt32 refType, IntPtr data)
        {
            return CANDLL.GetReference((UInt32)parentDevice.DeviceType, parentDevice.DeviceIndex, channelIndex, refType, data);
        }

        public CANResult SetReference(UInt32 refType, IntPtr data)
        {
            return CANDLL.SetReference((UInt32)parentDevice.DeviceType, parentDevice.DeviceIndex, channelIndex, refType, data);
        }

        public UInt32 GetReceiveNum()
        {
            return CANDLL.GetReceiveNum((UInt32)parentDevice.DeviceType, parentDevice.DeviceIndex, channelIndex);
        }

        public CANResult ClearBuffer()
        {
            return CANDLL.ClearBuffer((UInt32)parentDevice.DeviceType, parentDevice.DeviceIndex, channelIndex);
        }

        public CANResult StartCAN()
        {
            return CANDLL.StartCAN((UInt32)parentDevice.DeviceType, parentDevice.DeviceIndex, channelIndex);
        }

        public UInt32 Transmit(CANOBJ[] canFrames, UInt32 canFrameLength)
        {
            return CANDLL.Transmit((UInt32)parentDevice.DeviceType, parentDevice.DeviceIndex, channelIndex, canFrames, canFrameLength);
        }

        public UInt32 Receive(out CANOBJ[] canFrames, UInt32 canFrameLength, Int32 waitMilliseconds)
        {
            return CANDLL.Receive((UInt32)parentDevice.DeviceType, parentDevice.DeviceIndex, channelIndex,
                out canFrames, canFrameLength, waitMilliseconds);
        }

        public CANResult ResetCAN()
        {
            return CANDLL.ResetCAN((UInt32)parentDevice.DeviceType, parentDevice.DeviceIndex, channelIndex);
        }

    }
}
