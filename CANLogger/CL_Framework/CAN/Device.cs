using log4net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CL_Framework
{
    public class Device
    {
        private static readonly ILog Logger = LogManager.GetLogger("info");

        private bool isDeviceOpen;
        private DEVICE_TYPE deviceType;
        private string deviceTypeDesc;
        private UInt32 deviceIndex;
        private BoardInfo deviceInfo;
        
        private Channel[] channels;

        public Channel[] Channels
        { get { return channels; } }
        
        public DEVICE_TYPE DeviceType
        { get { return deviceType; } }

        public string DeviceTypeDesc
        { get { return deviceTypeDesc; } }

        public UInt32 DeviceIndex
        { get { return deviceIndex; } }

        public Boolean IsDeviceOpen
        { get { return isDeviceOpen; } }

        public BoardInfo DeviceInfo
        { get { return deviceInfo; } set { deviceInfo = value; } }

        public uint CANNum
        { get { return deviceInfo.CANNum > CAN.DEVICE_CANNUM_MAXIMUM ? CAN.DEVICE_CANNUM_MAXIMUM : deviceInfo.CANNum; } }

        private Device(DEVICE_TYPE deviceType)
        {
            this.deviceType = deviceType;
            this.deviceTypeDesc = CAN.FindDeviceTypeKey(deviceType);
            this.deviceIndex = DeviceGroup.CreateInstance().GetNewDeviceIndex(deviceType);
            this.isDeviceOpen = false;
            this.deviceInfo = new BoardInfo();
        }

        public Channel GetChannel(uint channelIndex)
        {
            return channelIndex >= this.CANNum ? null : this.channels[channelIndex];
        }

        public string GetDeviceName()
        {
            return string.Join("-", deviceTypeDesc, deviceIndex);
        }

        private void InitCAN(UInt32 canNum)
        {
            channels = new Channel[canNum];
            for (UInt32 canIndex = 0; canIndex < canNum; canIndex++)
            {
                string channelName = string.Join("-", 
                    new string[] { this.deviceTypeDesc, this.deviceIndex.ToString(), "CAN" + canIndex.ToString() });
                Channel channel = new Channel(canIndex, channelName, this);
                channels[canIndex] = channel;
            }
        }

        public static uint CreateDevice(DEVICE_TYPE deviceType, out Device device)
        {
            device = null;

            Device newDevice = new Device(deviceType);

            uint result = newDevice.OpenDevice();
            if (result != (uint)CAN_RESULT.SUCCESSFUL)
            {
                Logger.Info(string.Format("create device[{0}] failed.", newDevice.GetDeviceName()));
                return result;
            }

            result = newDevice.ReadBoardInfo();
            if (result != (uint)CAN_RESULT.SUCCESSFUL)
            {
                Logger.Info(string.Format("create device[{0}] failed.", newDevice.GetDeviceName()));
                return result;
            }

            newDevice.InitCAN(newDevice.CANNum);
            device = newDevice;

            Logger.Info(string.Format("create device[{0}] successful.", newDevice.GetDeviceName()));
            return result;
        }

        public uint OpenDevice()
        {
            if(this.isDeviceOpen)
            {
                Logger.Info(string.Format("device[{0}] already open", this.GetDeviceName()));
                return (uint)CAN_RESULT.SUCCESSFUL;
            }

            if (CANDLL.OpenDevice((UInt32)deviceType, deviceIndex, 0) == CANDLLResult.STATUS_OK)
            {
                Logger.Info(string.Format("open device[{0}] successful", this.GetDeviceName()));
                isDeviceOpen = true;
                return (uint)CAN_RESULT.SUCCESSFUL;
            }

            uint result = (uint)CAN_RESULT.ERR_UNKNOWN;
            CANErrInfo pCANErrorInfo;
            if (CANDLL.ReadErrInfo((uint)this.deviceType, this.deviceIndex, -1, out pCANErrorInfo) == CANDLLResult.STATUS_OK)
            {
                result = pCANErrorInfo.ErrCode;
            }

            Logger.Info(string.Format("open device[{0}] failed: [0x{1}]", this.GetDeviceName(), result.ToString("x")));
            return result;
        }

        public uint CloseDevice()
        {
            if (CANDLL.CloseDevice((UInt32)deviceType, deviceIndex) == CANDLLResult.STATUS_OK)
            {
                Logger.Info(string.Format("close device[{0}] successful", this.GetDeviceName()));
                return (uint)CAN_RESULT.SUCCESSFUL;
            }

            uint result = (uint)CAN_RESULT.ERR_UNKNOWN;
            CANErrInfo pCANErrorInfo;
            if (CANDLL.ReadErrInfo((uint)this.deviceType, this.deviceIndex, -1, out pCANErrorInfo) == CANDLLResult.STATUS_OK)
            {
                result = pCANErrorInfo.ErrCode;
            }

            Logger.Info(string.Format("close device[{0}] failed: [0x{1}]", this.GetDeviceName(), result.ToString("x")));
            return result;
        }

        private uint ReadBoardInfo()
        {
            if (CANDLL.ReadBoardInfo((UInt32)deviceType, deviceIndex, out deviceInfo) == CANDLLResult.STATUS_OK)
            {
                Logger.Info(string.Format("device[{0}] read board info successful", this.GetDeviceName()));
                return (uint)CAN_RESULT.SUCCESSFUL;
            }

            uint result = (uint)CAN_RESULT.ERR_UNKNOWN;
            CANErrInfo pCANErrorInfo;
            if (CANDLL.ReadErrInfo((uint)this.deviceType, this.deviceIndex, -1, out pCANErrorInfo) == CANDLLResult.STATUS_OK)
            {
                result = pCANErrorInfo.ErrCode;
            }

            Logger.Info(string.Format("device[{0}] read board info failed: [0x{1}]", this.GetDeviceName(), result.ToString("x")));
            return result;
        }
    }
}
