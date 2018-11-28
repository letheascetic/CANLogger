using CL_Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CL_Main.Dialog
{
    public partial class DialogDevice : Form
    {
        private DeviceGroup deviceGroup = DeviceGroup.CreateInstance();
        private DeviceType deviceType = DeviceType.UNKNOWN;
        private UInt32 deviceIndex = 0;
        private Device device = null;

        public DialogDevice(DeviceType deviceType, UInt32 deviceIndex)
        {
            InitializeComponent();

            this.deviceType = deviceType;
            this.deviceIndex = deviceIndex;
            this.device = deviceGroup.GetDevice(deviceType, deviceIndex);
        }

        private void InitLoadControls()
        {
            //load cbxSelectDevice data source
            cbxSelectDevice.DataSource = Device.DeviceTypies;
            cbxSelectDevice.ValueMember = "Key";
            cbxSelectDevice.DisplayMember = "Value";
            cbxSelectDevice.SelectedIndex = device != null ? 
                cbxSelectDevice.FindString(device.DeviceTypeDesc) : cbxSelectDevice.FindString(Device.USBCANII);

            //btnOpenDevice.Enabled = (device == null || !device.IsDeviceOpen) ? true : false;
            tabControl.Enabled = (device != null && device.IsDeviceOpen) ? true : false;
        }

        private void UpdateControls()
        {
            tabControl.Enabled = (device != null && device.IsDeviceOpen) ? true : false;
        }

        private void DialogDevice_Load(object sender, EventArgs e)
        {
            InitLoadControls();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnOpenDevice_Click(object sender, EventArgs e)
        {
            if (device != null && device.IsDeviceOpen)
            {
                return;
            }

            if (device == null)
            {
                DeviceType deviceType = (DeviceType)Enum.Parse(typeof(DeviceType), cbxSelectDevice.SelectedValue.ToString());
                UInt32 deviceIndex = deviceGroup.GetNewDeviceIndex(deviceType);
                //Device device = Device.OpenInitDevice(deviceType, deviceIndex, 0);

            }
            return;
        }
    }
}
