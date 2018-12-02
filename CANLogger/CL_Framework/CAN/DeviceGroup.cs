using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CL_Framework
{
    public delegate void DeviceEventHandler(Device device, Object paras);

    /// <summary>
    /// 单列模式
    /// </summary>
    /// 
    public class DeviceGroup
    {
        private volatile static DeviceGroup deviceGroup = null;
        private static readonly object locker = new object();

        public event DeviceEventHandler DeviceAdded;
        public event DeviceEventHandler DeviceRemoved;
        public event DeviceEventHandler DeviceUpdated;

        private List<Device> devices;
        
        public List<Device> Devices
        { get { return devices; } }


        public static DeviceGroup CreateInstance()
        {
            if (deviceGroup == null)
            {
                lock (locker)
                {
                    if (deviceGroup == null)
                        deviceGroup = new DeviceGroup();
                }
            }
            return deviceGroup;
        }

        public DeviceGroup()
        {
            devices = new List<Device>();
        }
        
        public UInt32 GetNewDeviceIndex(DeviceType deviceType)
        {
            List<UInt32> indexList = new List<uint>();
            lock (locker)
            {
                foreach (Device device in devices)
                {
                    if (device.DeviceType == deviceType)
                    {
                        indexList.Add(device.DeviceIndex);
                    }
                }
                UInt32 newIndex = 0;
                while (indexList.Contains(newIndex++)) ;
                return --newIndex;
            }
        }

        public Device GetDevice(DeviceType deviceType, UInt32 deviceIndex)
        {
            if (deviceType == DeviceType.UNKNOWN)
            {
                return null;
            }
            lock (locker)
            {
                foreach (Device device in devices)
                {
                    if(device.DeviceType == deviceType && device.DeviceIndex == deviceIndex)
                    {
                        return device;
                    }
                }
                return null;
            }
        }

        public bool Add(Device device, object paras)
        {
            if (device == null)
            {
                return false;
            }
            
            if (GetDevice(device.DeviceType, device.DeviceIndex) != null)
            {
                LogHelper.Log(string.Format("add device failed, this device[{0}-{1}] already in device group",
                                device.DeviceTypeDesc, device.DeviceIndex));
                return false;
            }

            this.devices.Add(device);

            if (DeviceAdded != null)
            {
                DeviceAdded.Invoke(device, paras);
            }

            return true;
        }

        public bool Remove(Device device, object paras)
        {
            if (device == null)
            {
                return false;
            }

            if (GetDevice(device.DeviceType, device.DeviceIndex) == null)
            {
                LogHelper.Log(string.Format("delete device failed, no this device[{0}-{1}] in device group", 
                    device.DeviceTypeDesc, device.DeviceIndex));
                return false;
            }

            this.devices.Remove(device);
            DeviceRemoved.Invoke(device, paras);
            return true;
        }

        public bool Update(Device device, object paras)
        {
            if (device == null)
            {
                return false;
            }

            if (GetDevice(device.DeviceType, device.DeviceIndex) == null)
            {
                LogHelper.Log(string.Format("update device failed, no this device[{0}-{1}] in device group",
                    device.DeviceTypeDesc, device.DeviceIndex));
                return false;
            }

            DeviceUpdated.Invoke(device, paras);
            return true;
        }

    }
}
