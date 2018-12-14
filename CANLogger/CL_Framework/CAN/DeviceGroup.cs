using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CL_Framework
{
    public delegate void DeviceEventHandler(Device device, Object paras);
    public delegate void ChannelEventHandler(Channel channel, Object paras);

    /// <summary>
    /// 单列模式
    /// </summary>
    public class DeviceGroup
    {
        ///////////////////////////////////////////////////////////////////////////////////////////
        private static readonly ILog Logger = LogManager.GetLogger("info");
        private volatile static DeviceGroup p_DeviceGroup = null;
        private static readonly object locker = new object();
        ///////////////////////////////////////////////////////////////////////////////////////////
        public event DeviceEventHandler DeviceAdded;
        public event DeviceEventHandler DeviceRemoved;
        public event DeviceEventHandler DeviceUpdated;
        public event DeviceEventHandler SelectedDeviceChanged;
        public event ChannelEventHandler ChannelUpdated;
        ///////////////////////////////////////////////////////////////////////////////////////////
        private List<Device> devices;
        private Device p_SelectedDevice = null;
        ///////////////////////////////////////////////////////////////////////////////////////////
        public List<Device> Devices
        { get { return devices; } }
        ///////////////////////////////////////////////////////////////////////////////////////////
        public static DeviceGroup CreateInstance()
        {
            if (p_DeviceGroup == null)
            {
                lock (locker)
                {
                    if (p_DeviceGroup == null)
                        p_DeviceGroup = new DeviceGroup();
                }
            }
            return p_DeviceGroup;
        }

        private DeviceGroup()
        {
            devices = new List<Device>();
        }
        
        public UInt32 GetNewDeviceIndex(DEVICE_TYPE deviceType)
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

        public Device GetDevice(DEVICE_TYPE deviceType, UInt32 deviceIndex)
        {
            if (deviceType == DEVICE_TYPE.UNKNOWN)
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

        public Device GetSelectedDevice()
        {
            return this.p_SelectedDevice;
        }

        public bool Add(Device device)
        {
            if (device == null)
            {
                return false;
            }
            
            if (GetDevice(device.DeviceType, device.DeviceIndex) != null)
            {
                Logger.Info(string.Format("add device failed, this device[{0}] already in device group", device.GetDeviceName()));
                return false;
            }

            lock (locker)
            {
                this.devices.Add(device);
            }
            
            if (DeviceAdded != null)
            {
                DeviceAdded.Invoke(device, null);
            }

            return true;
        }

        public bool Remove(Device device)
        {
            if (device == null)
            {
                return false;
            }

            if (GetDevice(device.DeviceType, device.DeviceIndex) == null)
            {
                Logger.Info(string.Format("delete device failed, no this device[{0}] in device group", device.GetDeviceName()));
                return false;
            }

            lock (locker)
            {
                this.devices.Remove(device);
            }
            
            if (DeviceRemoved != null)
            {
                DeviceRemoved.Invoke(device, null);
            }
            return true;
        }

        public bool Update(Device device)
        {
            if (device == null)
            {
                return false;
            }

            if (GetDevice(device.DeviceType, device.DeviceIndex) == null)
            {
                Logger.Info(string.Format("update device failed, no this device[{0}] in device group", device.GetDeviceName()));
                return false;
            }

            if (DeviceUpdated != null)
            {
                DeviceUpdated.Invoke(device, null);
            }
            return true;
        }

        public bool ChangeSelectedDevice(Device device)
        {
            if (device == null)
            {
                return false;
            }
            if (GetDevice(device.DeviceType, device.DeviceIndex) == null)
            {
                Logger.Info(string.Format("change selected device failed, no this device[{0}] in device group", device.GetDeviceName()));
                return false;
            }
            this.p_SelectedDevice = device;
            if (this.SelectedDeviceChanged != null)
            {
                this.SelectedDeviceChanged.Invoke(device, null);
            }
            return true;
        }

        public bool UpdateChannel(Channel channel)
        {
            if (channel == null)
            {
                return false;
            }

            Device device = channel.ParentDevice;
            if (GetDevice(device.DeviceType, device.DeviceIndex) == null)
            {
                Logger.Info(string.Format("update channel failed, no parent device[{0}] in device group", device.GetDeviceName()));
                return false;
            }

            if(this.ChannelUpdated != null)
            {
                this.ChannelUpdated.Invoke(channel, null);
            }
            return true;
        }

    }
}
