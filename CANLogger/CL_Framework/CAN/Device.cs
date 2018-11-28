using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CL_Framework
{
    public enum DeviceType : UInt32
    {   
        USBCAN = 3,
        USBCANII = 4
    }

    public class Device
    {
        public static Dictionary<string, DeviceType> DeviceTypies;
        private static readonly string USBCAN = "USBCAN";
        private static readonly string USBCANII = "USBCAN-II";

        private bool isDeviceOpen;
        private DeviceType deviceType;
        private UInt32 deviceIndex;
        private BOARD_INFO deviceInfo;
        private InitConfig initConfig;
        
        public DeviceType DeviceType
        { get { return deviceType; } }
        public UInt32 DeviceIndex
        { get { return deviceIndex; } }
        public Boolean IsDeviceOpen
        { get { return isDeviceOpen; } }
        public string DeviceID
        { get { return deviceInfo.StrSerialNO.ToString(); } }

        static Device()
        {
            DeviceTypies = new Dictionary<string, DeviceType>();
            DeviceTypies.Add(USBCAN, CL_Framework.DeviceType.USBCAN);
            DeviceTypies.Add(USBCANII, CL_Framework.DeviceType.USBCANII);
        }

        private Device(DeviceType deviceType, UInt32 deviceIndex)
        {
            this.deviceType = deviceType;
            this.deviceIndex = deviceIndex;

            this.isDeviceOpen = false;
            this.deviceInfo = new BOARD_INFO();
            this.initConfig = new InitConfig();
        }

        public static Device OpenInitDevice(DeviceType deviceType, UInt32 deviceIndex, UInt32 Reserved)
        {
            Device device = new Device(deviceType, deviceIndex);

            return device;
        }

        public CANStatus OpenDevice()
        {
            return CANDLL.OpenDevice((UInt32)deviceType, deviceIndex, 0);
        }

        public CANStatus CloseDevice()
        {
            return CANDLL.CloseDevice((UInt32)deviceType, deviceIndex);
        }



    }
}
