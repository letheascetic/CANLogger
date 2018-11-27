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
        private INIT_CONFIG initInfo;
        
        public DeviceType DeviceType
        { get { return deviceType; } }
        public UInt32 DeviceIndex
        { get { return deviceIndex; } }
        public Boolean IsDeviceOpen
        { get { return isDeviceOpen; } }

        static Device()
        {
            DeviceTypies = new Dictionary<string, DeviceType>();
            DeviceTypies.Add(USBCAN, CL_Framework.DeviceType.USBCAN);
            DeviceTypies.Add(USBCANII, CL_Framework.DeviceType.USBCANII);
        }

        public Device()
        {

        }

        public CANStatus OpenDevice()
        {
            return CANDLL.OpenDevice(deviceType, deviceIndex, 0);
        }

        public CANStatus CloseDevice()
        {
            return CANDLL.CloseDevice(deviceType, deviceIndex);
        }



    }
}
