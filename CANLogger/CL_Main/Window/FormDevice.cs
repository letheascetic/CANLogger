using CL_Framework;
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
        private DeviceGroup deviceGroup = DeviceGroup.CreateInstance();
        private Hashtable nameDevicePairs = new Hashtable();

        public FormDevice()
        {
            InitializeComponent();
        }

        public void SetLanguage(string language)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(language);
            System.ComponentModel.ComponentResourceManager resources = new ComponentResourceManager(this.GetType());

            resources.ApplyResources(this, "$this");
        }

        public Device GetSelectedDevice()
        {
            Channel channel = GetSelectedChannel();
            if (channel != null)
            {
                return channel.ParentDevice;
            }
            return null;
        }

        public Channel GetSelectedChannel()
        {
            if (dgvChannels.SelectedRows.Count <= 0)
            {
                return null;
            }
            Channel channel = (Channel)dgvChannels.SelectedRows[0].Tag;
            return channel;
        }

        public void UpdateControls()
        {
            foreach (Device device in deviceGroup.Devices)
            {
                string deviceName = string.Join("-", device.DeviceTypeDesc, device.DeviceIndex);
                if (!this.nameDevicePairs.ContainsKey(deviceName))  // new device found
                {
                    AddDevice(deviceName, device);
                }
            }

            foreach (DictionaryEntry keyValuePair in this.nameDevicePairs)
            {
                string deviceName = (string)keyValuePair.Key;
                Device device = (Device)keyValuePair.Value;
                if (deviceGroup.GetDevice(device.DeviceType, device.DeviceIndex) == null)   // device removed
                {
                    RemoveDevice(deviceName, device);
                }
            }

        }

        public void AddDevice(string deviceName, Device device)
        {
            nameDevicePairs.Add(deviceName, device);
            chbxDevices.Items.Add(deviceName, true);
            for (uint channelIndex = 0; channelIndex < device.CANNum; channelIndex++)
            {
                Channel channel = device.GetChannel(channelIndex);
                int index = dgvChannels.Rows.Add();
                dgvChannels.Rows[index].Tag = channel;
                dgvChannels.Rows[index].Cells[1].Value = channel.ChannelName;
                dgvChannels.Rows[index].Cells[2].Value = channel.ChannelIndex;
                dgvChannels.Rows[index].Cells[3].Value = channel.BaudRate;
            }
        }

        public void RemoveDevice(string deviceName, Device device)
        {
            int index = chbxDevices.FindString(deviceName);
            if (index >= 0)
            {
                chbxDevices.Items.RemoveAt(index);
            }

            foreach (DataGridViewRow row in dgvChannels.Rows)
            {
                Channel channel = (Channel)row.Tag;
                if (Object.ReferenceEquals(device, channel.ParentDevice))
                {
                    dgvChannels.Rows.Remove(row);
                }
            }
            nameDevicePairs.Remove(deviceName);
        }

        public void InitLoadControls()
        {
            chbxDevices.Items.Clear();
            UpdateControls();
        }

        private void btnAddSet_Click(object sender, EventArgs e)
        {

        }

        private void FormDevice_Load(object sender, EventArgs e)
        {
            InitLoadControls();
        }

        private void chbxDevices_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            
        }
    }
}
