﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CL_Framework
{
    public class Channel
    {
        private uint channelIndex;
        private string channelName;
        
        private Device parentDevice;
        private InitConfig initConfig;

        public Channel(uint channelIndex, string channelName, Device parentDevice)
        {
            this.channelIndex = channelIndex;
            this.channelName = channelName;
            this.parentDevice = parentDevice;
        }
        
        public CANResult InitCAN(ref InitConfig initConfig)
        {
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
