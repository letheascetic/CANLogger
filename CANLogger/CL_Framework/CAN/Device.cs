using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CL_Framework
{
    public enum DeviceType : UInt32
    {   
        UNKNOWN = 0,
        USBCAN = 3,
        USBCANII = 4
    }

    public class Device
    {
        public static List<KeyValuePair<DeviceType, string>> DeviceTypies = new List<KeyValuePair<DeviceType, string>>();
        public static readonly string UNKNOWN = "UNKNOWN";
        public static readonly string USBCAN = "USBCAN";
        public static readonly string USBCANII = "USBCAN-II";

        private bool isDeviceOpen;
        private DeviceType deviceType;
        private string deviceTypeDesc;
        private UInt32 deviceIndex;
        private BoardInfo deviceInfo;
        
        private Channel[] channels;
        
        public DeviceType DeviceType
        { get { return deviceType; } }

        public string DeviceTypeDesc
        { get { return deviceTypeDesc; } }

        public UInt32 DeviceIndex
        { get { return deviceIndex; } }

        public Boolean IsDeviceOpen
        { get { return isDeviceOpen; } }

        public BoardInfo DeviceInfo
        { get { return deviceInfo; } }

        public string DeviceID
        { get { return deviceInfo.StrSerialNO.ToString(); } }

        static Device()
        {
            DeviceTypies.Add(new KeyValuePair<DeviceType, string>(DeviceType.USBCAN, USBCAN));
            DeviceTypies.Add(new KeyValuePair<DeviceType, string>(DeviceType.USBCANII, USBCANII));
        }

        private Device(DeviceType deviceType, UInt32 deviceIndex)
        {
            this.deviceType = deviceType;
            this.deviceIndex = deviceIndex;

            this.isDeviceOpen = false;
            this.deviceInfo = new BoardInfo();
        }

        //public static CANStatus OpenInitDevice(DeviceType deviceType, UInt32 deviceIndex, UInt32 Reserved, out Device device)
        //{
        //    device = null;
        //    return CANStatus.STATUS_OK;
        //}

        public static string GetDeviceDesc(DeviceType deviceType)
        {
            if (deviceType == DeviceType.UNKNOWN)
            {
                return Device.UNKNOWN;
            }
            foreach (KeyValuePair<DeviceType, string> keyValuePair in DeviceTypies)
            {
                if (keyValuePair.Key == deviceType)
                {
                    return keyValuePair.Value;
                }
            }
            return null;
        }

        public CANResult OpenDevice()
        {
            return CANDLL.OpenDevice((UInt32)deviceType, deviceIndex, 0);
        }

        public CANResult CloseDevice()
        {
            return CANDLL.CloseDevice((UInt32)deviceType, deviceIndex);
        }


    }
}
