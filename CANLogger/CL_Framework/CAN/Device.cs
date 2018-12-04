using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CL_Framework
{
    public class Device
    {
        private bool isDeviceOpen;
        private DEVICE_TYPE deviceType;
        private string deviceTypeDesc;
        private UInt32 deviceIndex;
        private BoardInfo deviceInfo;
        
        private Channel[] channels;
        
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

        public static CANResult CreateDevice(DEVICE_TYPE deviceType, out Device device)
        {
            device = null;
            //CANResult canResult = CANResult.STATUS_ERR;
            Device newDevice = new Device(deviceType);

            if (newDevice.OpenDevice() == CANResult.STATUS_ERR)
            {
                return CANResult.STATUS_ERR;
            }

            if (newDevice.ReadBoardInfo() == CANResult.STATUS_ERR)
            {
                return CANResult.STATUS_ERR;
            }

            newDevice.InitCAN(newDevice.CANNum);
            device = newDevice;

            return CANResult.STATUS_OK;
        }

        public CANResult OpenDevice()
        {
            CANResult result = CANDLL.OpenDevice((UInt32)deviceType, deviceIndex, 0);
            isDeviceOpen = result == CANResult.STATUS_OK ? true : false;
            return result;
        }

        public CANResult CloseDevice()
        {
            return CANDLL.CloseDevice((UInt32)deviceType, deviceIndex);
        }

        public CANResult InitCAN(UInt32 canIndex, int baudRate, ref InitConfig initConfig)
        {
            return channels[canIndex].InitCAN(baudRate, ref initConfig);
        }

        private CANResult ReadBoardInfo()
        {
            return CANDLL.ReadBoardInfo((UInt32)deviceType, deviceIndex, out deviceInfo);
        }

        public CANResult ReadErrInfo(UInt32 canIndex, out CANErrInfo canErrInfo)
        {
            return channels[canIndex].ReadErrInfo(out canErrInfo);
        }

        public CANResult ReadCanStatus(UInt32 canIndex, out CANStatus canStatus)
        {
            return channels[canIndex].ReadCanStatus(out canStatus);
        }

        public CANResult GetReference(UInt32 canIndex, UInt32 refType, IntPtr data)
        {
            return channels[canIndex].GetReference(refType, data);
        }

        public CANResult SetReference(UInt32 canIndex, UInt32 refType, IntPtr data)
        {
            return channels[canIndex].SetReference(refType, data);
        }

        public UInt32 GetReceiveNum(UInt32 canIndex)
        {
            return channels[canIndex].GetReceiveNum();
        }

        public CANResult ClearBuffer(UInt32 canIndex)
        {
            return channels[canIndex].ClearBuffer();
        }

        public CANResult StartCAN(UInt32 canIndex)
        {
            return channels[canIndex].StartCAN();
        }

        public UInt32 Transmit(UInt32 canIndex, CANOBJ[] canFrames, UInt32 canFrameLength)
        {
            return channels[canIndex].Transmit(canFrames, canFrameLength);
        }

        public UInt32 Receive(UInt32 canIndex, out CANOBJ[] canFrames, UInt32 canFrameLength, Int32 waitMilliseconds)
        {
            return channels[canIndex].Receive(out canFrames, canFrameLength, waitMilliseconds);
        }

        public CANResult ResetCAN(UInt32 canIndex)
        {
            return channels[canIndex].ResetCAN();
        }

        public void ResetAll()
        {
            foreach (Channel channel in channels)
            {
                channel.ResetCAN();
            }
        }

    }
}
