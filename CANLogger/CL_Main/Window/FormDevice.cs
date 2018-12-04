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
        }

        /// <summary>
        /// 配置设备或复位设备
        /// </summary>
        /// <param name="device"></param>
        public void UpdateDevice(Device device, object paras)
        {
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
        }

        public void RemoveDevice(Device device, object paras)
        {
            List<DataGridViewRow> rows = FindMappingRows(device);
            foreach (DataGridViewRow row in rows)
            {
                dgvChannels.Rows.Remove(row);
            }

            if (object.ReferenceEquals(device, this.selectedDevice))
            {
                this.selectedDevice = null;
                this.tbxDevice.Text = string.Empty;
            }

            if (this.selectedChannel != null && object.ReferenceEquals(device, this.selectedChannel.ParentDevice))
            {
                this.selectedChannel = null;
                this.tbxCAN.Text = string.Empty;
            }
        }

        public void ChangeSelectedDevice(Device device, object paras)
        {
            Device oldSelectedDevice = this.selectedDevice;
            if (object.ReferenceEquals(oldSelectedDevice, device))
            {
                LogHelper.Log("selected device no change");
                return;
            }

            this.selectedDevice = device;
            this.tbxDevice.Text = device == null ? string.Empty : device.GetDeviceName();

            List<DataGridViewRow> oldSelectedDeviceMappingRows = FindMappingRows(oldSelectedDevice);
            foreach (DataGridViewRow row in oldSelectedDeviceMappingRows)
            {
                row.Visible = false;
            }

            List<DataGridViewRow> newSelectedDeviceMappingRows = FindMappingRows(device);
            foreach (DataGridViewRow row in newSelectedDeviceMappingRows)
            {
                row.Visible = true;
            }

            dgvChannels.CurrentCell = newSelectedDeviceMappingRows[0].Cells[0];     //获取焦点
            ChangeSelectedChannel();
        }
        
        #endregion

        #region private functions

        private void Init()
        {
            pDeviceGroup.DeviceAdded += new DeviceEventHandler(this.AddDevice);
            pDeviceGroup.DeviceRemoved += new DeviceEventHandler(this.RemoveDevice);
            pDeviceGroup.DeviceUpdated += new DeviceEventHandler(this.UpdateDevice);
            pDeviceGroup.SelectedDeviceChanged += new DeviceEventHandler(this.ChangeSelectedDevice);
        }

        private void ChangeSelectedChannel()
        {
            Channel oldSelectedChannel = this.selectedChannel;
            Channel newSelectedChannel = GetSelectedChannel();

            if (object.ReferenceEquals(oldSelectedChannel, newSelectedChannel))
            {
                LogHelper.Log("selected channel no change");
                return;
            }

            this.selectedChannel = newSelectedChannel;
            this.tbxCAN.Text = this.selectedChannel == null ? string.Empty : newSelectedChannel.ChannelName;
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

        private void dgvChannels_SelectionChanged(object sender, EventArgs e)
        {
            ChangeSelectedChannel();
        }

        #endregion

    }
}
