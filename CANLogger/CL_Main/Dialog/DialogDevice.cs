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
        private DeviceGroup pDeviceGroup = DeviceGroup.CreateInstance();
        private Device device = null;

        #region public apis

        public DialogDevice(Device device)
        {
            InitializeComponent();
            this.device = device;
        }

        public Device GetDevice()
        {
            return this.device;
        }

        #endregion

        #region private functions

        private void Init()
        {
            //init load top panel
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            lbVersion.Text += string.Join(".", new object[] { version.Major, version.Minor, version.Build });

            //init load select panel
            //load cbxSelectDevice data source
            BindingSource bs = new BindingSource();
            bs.DataSource = CAN.DEVICE_TYPE_LIST.Keys;
            cbxSelectDevice.DataSource = bs;
            //cbxSelectDevice.DataSource = CAN.DEVICE_TYPE_LIST.Keys;
            //cbxSelectDevice.ValueMember = "Key";
            //cbxSelectDevice.DisplayMember = "Value";
            cbxSelectDevice.SelectedIndex = device != null ?
                cbxSelectDevice.FindString(device.DeviceTypeDesc) : cbxSelectDevice.FindString(CAN.DEVICE_TYPE_USBCANII);
            cbxSelectDevice.Enabled = device == null ? true : false;

            UpdateControls();
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
                //dgvDevice.Rows[index].Cells[0].Value = System.Text.Encoding.Default.GetString(device.DeviceInfo.StrHWType);
                dgvDevice.Rows[index].Cells[0].Value = device.DeviceTypeDesc;
                dgvDevice.Rows[index].Cells[1].Value = device.DeviceIndex;
                dgvDevice.Rows[index].Cells[2].Value = String.Concat("0x", Convert.ToString(device.DeviceInfo.HWVersion, 16));
                dgvDevice.Rows[index].Cells[3].Value = String.Concat("0x", Convert.ToString(device.DeviceInfo.FWVersion, 16));
                dgvDevice.Rows[index].Cells[4].Value = String.Concat("0x", Convert.ToString(device.DeviceInfo.DriverVersion, 16));
                dgvDevice.Rows[index].Cells[5].Value = String.Concat("0x", Convert.ToString(device.DeviceInfo.InVersion, 16));
                dgvDevice.Rows[index].Cells[6].Value = device.DeviceInfo.IRQNum;
                dgvDevice.Rows[index].Cells[7].Value = device.CANNum;
                dgvDevice.Rows[index].Cells[8].Value = System.Text.Encoding.Default.GetString(device.DeviceInfo.StrSerialNO);
            }
        }

        private void UpdateConfigPanel()
        {
            tabControl.TabPages.Clear();
            if (device != null)
            {
                for (uint channelIndex = 0; channelIndex < device.CANNum; channelIndex++)
                {
                    TabPage tpgCAN = new TabPage(string.Concat("CAN", channelIndex));
                    tpgCAN.Name = string.Concat("tpgCAN", channelIndex);
                    //tpgCAN.AutoScroll = true;
                    UCCANConfig ucConfigCAN = new UCCANConfig(device.GetChannel(channelIndex));
                    tpgCAN.Controls.Add(ucConfigCAN);
                    //ucConfigCAN.Parent = tpgCAN;
                    ucConfigCAN.Dock = DockStyle.Fill;
                    tabControl.TabPages.Add(tpgCAN);
                }
            }
        }

        private Device CreateDevice(DEVICE_TYPE deviceType)
        {
            Device device = null;
            // get new device index
            UInt32 deviceIndex = pDeviceGroup.GetNewDeviceIndex(deviceType);
            // create new device
            if (Device.CreateDevice(deviceType, out device) == CANResult.STATUS_OK)
            {
                return device;
            }
            return null;
        }

        #endregion

        #region events

        private void DialogDevice_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void btnOpenDevice_Click(object sender, EventArgs e)
        {
            string deviceTypeDesc = cbxSelectDevice.SelectedValue.ToString();
            DEVICE_TYPE deviceType = (DEVICE_TYPE)CAN.DEVICE_TYPE_LIST[deviceTypeDesc];
            //DEVICE_TYPE deviceType = (DEVICE_TYPE)Enum.Parse(typeof(DEVICE_TYPE), cbxSelectDevice.SelectedValue.ToString());
            Device newDevice = null;

            if (device == null)
            {
                LogHelper.Log("try to open a new device");
                newDevice = CreateDevice(deviceType);
                if (newDevice == null)
                {
                    MessageBox.Show("打开设备失败。");
                    return;
                }
                device = newDevice;
                UpdateControls();
                return;
            }

            if (device.DeviceType == deviceType)
            {
                if (!device.IsDeviceOpen)
                {
                    LogHelper.Log(string.Format(
                        "try to re-open an old device: [{0}-{1}]", device.DeviceTypeDesc, device.DeviceIndex));
                    device.OpenDevice();
                    return;
                }
                LogHelper.Log(string.Format("device already opened: [{0}-{1}]",
                    device.DeviceTypeDesc, device.DeviceIndex));
                return;
            }

            if (device.IsDeviceOpen)
            {
                LogHelper.Log(string.Format(
                    "try to open another device, close the old device firstly: [{0}-{1}]",
                    device.DeviceTypeDesc, device.DeviceIndex));
                device.CloseDevice();
            }

            LogHelper.Log("try to open a new device");
            newDevice = CreateDevice(deviceType);
            if (device == null)
            {
                MessageBox.Show("打开设备失败。");
                return;
            }
            device = newDevice;
            UpdateControls();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            foreach (TabPage tpgCAN in tabControl.TabPages)
            {
                foreach (Control control in tpgCAN.Controls)
                {
                    UCCANConfig ucCANConfig = control as UCCANConfig;
                    if (ucCANConfig != null)
                    {
                        ucCANConfig.ConfigAndSatrt();
                        break;
                    }
                }
            }
            //this.pDeviceGroup.Add(this.device, null);
            this.DialogResult = DialogResult.OK;
        }

        private void btnConfigOnly_Click(object sender, EventArgs e)
        {
            foreach (TabPage tpgCAN in tabControl.TabPages)
            {
                foreach (Control control in tpgCAN.Controls)
                {
                    UCCANConfig ucCANConfig = control as UCCANConfig;
                    if (ucCANConfig != null)
                    {
                        ucCANConfig.ConfigOnly();
                        break;
                    }
                }
            }
            //this.pDeviceGroup.Add(this.device, null);
            this.DialogResult = DialogResult.OK;
        }

        #endregion
    }
}
