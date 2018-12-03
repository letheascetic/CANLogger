using CL_Framework;
using CL_Main.Dialog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace CL_Main
{
    public partial class FormDevice : DockContent
    {
        private DeviceGroup pDeviceGroup = DeviceGroup.CreateInstance();
        private Hashtable pNameDevicePairs = new Hashtable();

        private Device selectedDevice = null;
        private Channel selectedChannel = null;

        public Device SelectedDevice
        { get { return selectedDevice; } }

        public Channel SelectedChannel
        { get { return selectedChannel; } }

        #region public apis

        public FormDevice()
        {
            InitializeComponent();
            Init();
        }

        public void SetLanguage(string language)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(language);
            System.ComponentModel.ComponentResourceManager resources = new ComponentResourceManager(this.GetType());
            resources.ApplyResources(this, "$this");
        }

        public void AddDevice(Device device, object paras)
        {
            string deviceName = device.GetDeviceName();
            pNameDevicePairs.Add(deviceName, device);

            this.cbxDevice.Items.Add(deviceName);
            for (uint channelIndex = 0; channelIndex < device.CANNum; channelIndex++)
            {
                Channel channel = device.GetChannel(channelIndex);
                int index = dgvChannels.Rows.Add();
                dgvChannels.Rows[index].Visible = false;
                dgvChannels.Rows[index].Tag = channel;
                dgvChannels.Rows[index].Cells[0].Value = "";
                dgvChannels.Rows[index].Cells[1].Value = CAN.FindCANModeKey(channel.Mode);
                dgvChannels.Rows[index].Cells[2].Value = channel.ChannelName;
                dgvChannels.Rows[index].Cells[3].Value = channel.ChannelIndex;
                dgvChannels.Rows[index].Cells[4].Value = channel.BaudRate;
            }

            this.cbxDevice.SelectedIndex = this.cbxDevice.FindString(deviceName);
        }

        /// <summary>
        /// 配置设备或复位设备
        /// </summary>
        /// <param name="device"></param>
        public void UpdateDevice(Device device, object paras)
        {
            string deviceName = device.GetDeviceName();

            List<DataGridViewRow> mappingRows = FindMappingRows(device);
            foreach (DataGridViewRow row in mappingRows)
            {
                Channel channel = (Channel)row.Tag;
                row.Cells[0].Value = "";
                row.Cells[1].Value = CAN.FindCANModeKey(channel.Mode);
                row.Cells[2].Value = channel.ChannelName;
                row.Cells[3].Value = channel.ChannelIndex;
                row.Cells[4].Value = channel.BaudRate;
            }
            this.cbxDevice.SelectedIndex = this.cbxDevice.FindString(deviceName);
        }

        public void RemoveDevice(Device device, object paras)
        {
            string deviceName = device.GetDeviceName();
            this.pNameDevicePairs.Remove(deviceName);
            this.cbxDevice.Items.Remove(deviceName);

            List<DataGridViewRow> rows = FindMappingRows(device);
            foreach (DataGridViewRow row in rows)
            {
                dgvChannels.Rows.Remove(row);
            }

            if (cbxDevice.Items.Count > 0 && cbxDevice.SelectedIndex < 0)
            {
                cbxDevice.SelectedIndex = 0;
            }
        }

        #endregion

        #region private functions

        private void Init()
        {
            pDeviceGroup.DeviceAdded += new DeviceEventHandler(this.AddDevice);
            pDeviceGroup.DeviceRemoved += new DeviceEventHandler(this.RemoveDevice);
            pDeviceGroup.DeviceUpdated += new DeviceEventHandler(this.UpdateDevice);
        }

        private Device GetSelectedDevice()
        {
            string deviceName = this.cbxDevice.SelectedItem.ToString();
            if (deviceName == null || deviceName.Equals(string.Empty))
            {
                LogHelper.Log("no selected device.");
                return null;
            }

            LogHelper.Log(string.Format("selected device: [{0}]", deviceName));
            return (Device)pNameDevicePairs[deviceName];
        }

        private Channel GetSelectedChannel()
        {
            if (dgvChannels.CurrentRow == null || dgvChannels.CurrentRow.Tag == null)
            {
                LogHelper.Log("no selected channel.");
                return null;
            }
            Channel channel = (Channel)dgvChannels.CurrentRow.Tag;
            LogHelper.Log(string.Format("selected channel: [{0}]", channel.ChannelName));
            return channel;
        }

        private List<DataGridViewRow> FindMappingRows(Device device)
        {
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            if (device == null)
            {
                return rows;
            }

            foreach (DataGridViewRow row in dgvChannels.Rows)
            {
                Channel channel = (Channel)row.Tag;
                if (Object.ReferenceEquals(device, channel.ParentDevice))
                {
                    rows.Add(row);
                }
            }

            return rows;
        }

        #endregion

        #region events

        private void FormDevice_Load(object sender, EventArgs e)
        {
            
        }

        private void cbxDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            Device oldSelectedDevice = this.selectedDevice;
            Device newSelectedDevice = GetSelectedDevice();

            if (object.ReferenceEquals(oldSelectedDevice, newSelectedDevice))
            {
                LogHelper.Log("selected device no change");
                return;
            }

            this.selectedDevice = newSelectedDevice;

            List<DataGridViewRow> oldSelectedDeviceMappingRows = FindMappingRows(oldSelectedDevice);
            foreach (DataGridViewRow row in oldSelectedDeviceMappingRows)
            {
                row.Visible = false;
            }

            List<DataGridViewRow> newSelectedDeviceMappingRows = FindMappingRows(newSelectedDevice);
            foreach (DataGridViewRow row in newSelectedDeviceMappingRows)
            {
                row.Visible = true;
            }

            //if (newSelectedDeviceMappingRows.Count > 0)
            //{
            //    //默认选中指定Device的CAN0
            //    newSelectedDeviceMappingRows[0].Selected = true;
            //}
        }

        private void dgvChannels_SelectionChanged(object sender, EventArgs e)
        {
            Channel oldSelectedChannel = this.selectedChannel;
            Channel newSelectedChannel = GetSelectedChannel();

            this.selectedChannel = newSelectedChannel;
            tbxCAN.Text = this.selectedChannel == null ? 
                string.Empty : newSelectedChannel.ChannelName;
        }

        private void itemAddDevice_Click(object sender, EventArgs e)
        {
            DialogDevice dialogDevice = new DialogDevice(null);


        }

        private void itemConfigDevice_Click(object sender, EventArgs e)
        {

        }

        private void itemResetDevice_Click(object sender, EventArgs e)
        {

        }

        private void itemDeleteDevice_Click(object sender, EventArgs e)
        {
            Device device = this.selectedDevice;
            if (device == null)
            {
                return;
            }

            string deviceName = device.GetDeviceName();
            string content = string.Format("确定要删除当前设备（{0}）吗？", deviceName);

            if (MessageBox.Show(content, "删除设备", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.pDeviceGroup.Remove(device, null);
                RemoveDevice(device, null);
            }
        }

        #endregion

    }
}
