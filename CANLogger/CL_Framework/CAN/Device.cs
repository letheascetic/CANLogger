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
        ///////////////////////////////////////////////////////////////////////////////////////////
        private static readonly ILog Logger = LogManager.GetLogger("info");
        ///////////////////////////////////////////////////////////////////////////////////////////
        private bool m_IsDeviceOpen;
        private DEVICE_TYPE m_DeviceType;
        private string m_DeviceTypeDesc;
        private UInt32 m_DeviceIndex;
        private BOARD_INFO p_DeviceInfo;
        private Channel[] channels;
        ///////////////////////////////////////////////////////////////////////////////////////////
        public Channel[] Channels
        { get { return channels; } }
        public DEVICE_TYPE DeviceType
        { get { return m_DeviceType; } }
        public string DeviceTypeDesc
        { get { return m_DeviceTypeDesc; } }
        public UInt32 DeviceIndex
        { get { return m_DeviceIndex; } }
        public Boolean IsDeviceOpen
        { get { return m_IsDeviceOpen; } }
        public BOARD_INFO DeviceInfo
        { get { return p_DeviceInfo; } set { p_DeviceInfo = value; } }
        public uint CANNum
        { get { return p_DeviceInfo.CANNum > CAN.DEVICE_CANNUM_MAXIMUM ? CAN.DEVICE_CANNUM_MAXIMUM : p_DeviceInfo.CANNum; } }
        ///////////////////////////////////////////////////////////////////////////////////////////
        private Device(DEVICE_TYPE mDeviceType)
        {
            this.m_DeviceType = mDeviceType;
            this.m_DeviceTypeDesc = CAN.FindDeviceTypeKey(mDeviceType);
            this.m_DeviceIndex = DeviceGroup.CreateInstance().GetNewDeviceIndex(mDeviceType);
            this.m_IsDeviceOpen = false;
            this.p_DeviceInfo = new BOARD_INFO();
        }

        public Channel GetChannel(uint mChannelIndex)
        {
            return mChannelIndex >= this.CANNum ? null : this.channels[mChannelIndex];
        }

        public string GetDeviceName()
        {
            return string.Join("-", m_DeviceTypeDesc, m_DeviceIndex);
        }

        private void InitCAN(UInt32 mCANNum)
        {
            channels = new Channel[mCANNum];
            for (UInt32 nIndex = 0; nIndex < mCANNum; nIndex++)
            {
                string mChannelName = string.Join("-", new string[] { m_DeviceTypeDesc, m_DeviceIndex.ToString(), "CAN" + nIndex.ToString() });
                Channel channel = new Channel(nIndex, mChannelName, this);
                channels[nIndex] = channel;
            }
        }

        public static uint CreateDevice(DEVICE_TYPE mDeviceType, out Device device)
        {
            device = null;

            Device newDevice = new Device(mDeviceType);

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

        /// <summary>
        /// 打开设备
        /// </summary>
        /// <returns></returns>
        public uint OpenDevice()
        {
            if(this.m_IsDeviceOpen)
            {
                Logger.Info(string.Format("device[{0}] already open", this.GetDeviceName()));
                return (uint)CAN_RESULT.SUCCESSFUL;
            }

            if (CANDLL.OpenDevice((UInt32)m_DeviceType, m_DeviceIndex, 0) == CAN.CAN_DLL_RESULT_SUCCESS)
            {
                Logger.Info(string.Format("open device[{0}] successful", this.GetDeviceName()));
                m_IsDeviceOpen = true;
                return (uint)CAN_RESULT.SUCCESSFUL;
            }

            uint result = (uint)CAN_RESULT.ERR_UNKNOWN;
            CAN_ERR_INFO pCANErrorInfo = new CAN_ERR_INFO();
            if (CANDLL.ReadErrInfo((UInt32)m_DeviceType, m_DeviceIndex, -1, ref pCANErrorInfo) == CAN.CAN_DLL_RESULT_SUCCESS)
            {
                result = pCANErrorInfo.ErrCode;
            }

            Logger.Info(string.Format("open device[{0}] failed: [0x{1}]", this.GetDeviceName(), result.ToString("x")));
            return result;
        }

        /// <summary>
        /// 关闭设备
        /// </summary>
        /// <returns></returns>
        public uint CloseDevice()
        {
            if (CANDLL.CloseDevice((UInt32)m_DeviceType, m_DeviceIndex) == CAN.CAN_DLL_RESULT_SUCCESS)
            {
                Logger.Info(string.Format("close device[{0}] successful", this.GetDeviceName()));
                return (uint)CAN_RESULT.SUCCESSFUL;
            }

            uint result = (uint)CAN_RESULT.ERR_UNKNOWN;
            CAN_ERR_INFO pCANErrorInfo = new CAN_ERR_INFO();
            if (CANDLL.ReadErrInfo((uint)m_DeviceType, m_DeviceIndex, -1, ref pCANErrorInfo) == CAN.CAN_DLL_RESULT_SUCCESS)
            {
                result = pCANErrorInfo.ErrCode;
            }

            Logger.Info(string.Format("close device[{0}] failed: [0x{1}]", this.GetDeviceName(), result.ToString("x")));
            return result;
        }

        /// <summary>
        /// 读取板卡信息
        /// </summary>
        /// <returns></returns>
        private uint ReadBoardInfo()
        {
            if (CANDLL.ReadBoardInfo((UInt32)m_DeviceType, m_DeviceIndex, ref p_DeviceInfo) == CAN.CAN_DLL_RESULT_SUCCESS)
            {
                Logger.Info(string.Format("device[{0}] read board info successful", this.GetDeviceName()));
                return (uint)CAN_RESULT.SUCCESSFUL;
            }

            uint result = (uint)CAN_RESULT.ERR_UNKNOWN;
            CAN_ERR_INFO pCANErrorInfo = new CAN_ERR_INFO();
            if (CANDLL.ReadErrInfo((UInt32)m_DeviceType, m_DeviceIndex, -1, ref pCANErrorInfo) == CAN.CAN_DLL_RESULT_SUCCESS)
            {
                result = pCANErrorInfo.ErrCode;
            }

            Logger.Info(string.Format("device[{0}] read board info failed: [0x{1}]", this.GetDeviceName(), result.ToString("x")));
            return result;
        }
    }
}
