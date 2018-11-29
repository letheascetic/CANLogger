using CL_Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
            //init load top panel
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            lbVersion.Text += string.Join(".", new object[] { version.Major, version.Minor, version.Build});

            //init load select panel
            //load cbxSelectDevice data source
            cbxSelectDevice.DataSource = Device.DeviceTypies;
            cbxSelectDevice.ValueMember = "Key";
            cbxSelectDevice.DisplayMember = "Value";
            cbxSelectDevice.SelectedIndex = device != null ? 
                cbxSelectDevice.FindString(device.DeviceTypeDesc) : cbxSelectDevice.FindString(Device.USBCANII);
            cbxSelectDevice.Enabled = device == null ? true : false;

            UpdateControls();

            //btnOpenDevice.Enabled = (device == null || !device.IsDeviceOpen) ? true : false;
            //tabControl.Enabled = (device != null && device.IsDeviceOpen) ? true : false;
        }

        private void UpdateControls()
        {
            panelConfig.Visible = device == null ? false : true;
            tabControl.Visible = device == null ? false : true;
            panelList.Dock = device == null ? DockStyle.Fill : DockStyle.Top;

            UpdateDevicePanel();

            UpdateConfigPanel();
        }

        private void UpdateDevicePanel()
        {
            this.dgvDevice.Rows.Clear();
            if (device != null)
            {
                int index = dgvDevice.Rows.Add();
                dgvDevice.Rows[index].Cells[0].Value = device.DeviceInfo.StrHWType.ToString();
                dgvDevice.Rows[index].Cells[1].Value = device.DeviceIndex;
                dgvDevice.Rows[index].Cells[2].Value = String.Concat("0x", Convert.ToString(device.DeviceInfo.HWVersion, 16));
                dgvDevice.Rows[index].Cells[3].Value = String.Concat("0x", Convert.ToString(device.DeviceInfo.FWVersion, 16));
                dgvDevice.Rows[index].Cells[4].Value = String.Concat("0x", Convert.ToString(device.DeviceInfo.DriverVersion, 16));
                dgvDevice.Rows[index].Cells[5].Value = String.Concat("0x", Convert.ToString(device.DeviceInfo.InVersion, 16));
                dgvDevice.Rows[index].Cells[6].Value = device.DeviceInfo.IRQNum;
                dgvDevice.Rows[index].Cells[7].Value = device.DeviceInfo.CANNum;
                dgvDevice.Rows[index].Cells[8].Value = device.DeviceInfo.StrSerialNO.ToString();
            }
        }

        private void UpdateConfigPanel()
        {
            tabControl.TabPages.Clear();
            if (device != null)
            {
                for (uint channelIndex = 0; channelIndex < device.DeviceInfo.CANNum; channelIndex++)
                {
                    TabPage tpgCAN = new TabPage(string.Concat("CAN", channelIndex));
                    tpgCAN.Name = string.Concat("tpgCAN", channelIndex);
                    UCCANConfig ucConfigCAN = new UCCANConfig(device.GetChannel(channelIndex));
                    ucConfigCAN.Parent = tpgCAN;
                    ucConfigCAN.Dock = DockStyle.Fill;
                    tabControl.TabPages.Add(tpgCAN);
                }
            }
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
