using CL_Framework;
using log4net;
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
        /************************************************************************************/
        private static readonly ILog Logger = log4net.LogManager.GetLogger("info");
        /************************************************************************************/
        private DeviceGroup p_DeviceGroup = DeviceGroup.CreateInstance();
        private Device p_SelectedDevice = null;
        private Channel p_SelectedChannel = null;
        /************************************************************************************/
        public Device SelectedDevice
        { get { return p_SelectedDevice; } }
        public Channel SelectedChannel
        { get { return p_SelectedChannel; } }
        /************************************************************************************/
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
                dgvChannels.Rows[index].Cells[0].Value = channel.IsStarted ? "启动" : "复位";
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
                row.Cells[0].Value = channel.IsStarted ? "启动" : "复位";
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

            if (object.ReferenceEquals(device, this.p_SelectedDevice))
            {
                this.p_SelectedChannel = null;
                this.tbxDevice.Text = string.Empty;
            }

            if (this.p_SelectedChannel != null && object.ReferenceEquals(device, this.p_SelectedChannel.ParentDevice))
            {
                this.p_SelectedChannel = null;
                this.tbxCAN.Text = string.Empty;
            }
        }

        public void ChangeSelectedDevice(Device device, object paras)
        {
            Device oldSelectedDevice = this.p_SelectedDevice;
            if (object.ReferenceEquals(oldSelectedDevice, device))
            {
                Logger.Info("selected device no change");
                return;
            }

            this.p_SelectedDevice = device;
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

        public void UpdateChannel(Channel channel, object paras)
        {
            List<DataGridViewRow> mappingRows = FindMappingRows(channel);
            foreach (DataGridViewRow row in mappingRows)
            {
                row.Cells[0].Value = channel.IsStarted ? "启动" : "复位";
                row.Cells[1].Value = CAN.FindCANModeKey(channel.Mode);
                row.Cells[2].Value = channel.ChannelName;
                row.Cells[3].Value = channel.ChannelIndex;
                row.Cells[4].Value = channel.BaudRate;
            }
        }

        #endregion

        #region private functions

        private void Init()
        {
            p_DeviceGroup.DeviceAdded += new DeviceEventHandler(this.AddDevice);
            p_DeviceGroup.DeviceRemoved += new DeviceEventHandler(this.RemoveDevice);
            p_DeviceGroup.DeviceUpdated += new DeviceEventHandler(this.UpdateDevice);
            p_DeviceGroup.SelectedDeviceChanged += new DeviceEventHandler(this.ChangeSelectedDevice);
            p_DeviceGroup.ChannelUpdated += new ChannelEventHandler(this.UpdateChannel);
        }

        private void Finish()
        {
            p_DeviceGroup.DeviceAdded -= this.AddDevice;
            p_DeviceGroup.DeviceRemoved -= this.RemoveDevice;
            p_DeviceGroup.DeviceUpdated -= this.UpdateDevice;
            p_DeviceGroup.SelectedDeviceChanged -= this.ChangeSelectedDevice;
            p_DeviceGroup.ChannelUpdated -= this.UpdateChannel;

            this.Dispose();
        }

        private void ChangeSelectedChannel()
        {
            Channel oldSelectedChannel = this.p_SelectedChannel;
            Channel newSelectedChannel = GetSelectedChannel();

            if (object.ReferenceEquals(oldSelectedChannel, newSelectedChannel))
            {
                Logger.Info("selected channel no change");
                return;
            }

            this.p_SelectedChannel = newSelectedChannel;
            this.tbxCAN.Text = this.p_SelectedChannel == null ? string.Empty : newSelectedChannel.ChannelName;
        }

        private Channel GetSelectedChannel()
        {
            if (dgvChannels.CurrentRow == null || dgvChannels.CurrentRow.Tag == null)
            {
                Logger.Info("no selected channel.");
                return null;
            }
            Channel channel = (Channel)dgvChannels.CurrentRow.Tag;
            Logger.Info(string.Format("selected channel: [{0}]", channel.ChannelName));
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

        private List<DataGridViewRow> FindMappingRows(Channel channel)
        {
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            if (channel == null)
            {
                return rows;
            }

            foreach (DataGridViewRow row in dgvChannels.Rows)
            {
                Channel rowChannel = (Channel)row.Tag;
                if (Object.ReferenceEquals(rowChannel, channel))
                {
                    rows.Add(row);
                }
            }

            return rows;
        }

        #endregion

        #region events

        private void dgvChannels_SelectionChanged(object sender, EventArgs e)
        {
            ChangeSelectedChannel();
        }

        private void FormDevice_FormClosing(object sender, FormClosingEventArgs e)
        {
            Finish();
        }

        #endregion


    }
}
