using CL_Framework;
using log4net;
using System;
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
    public partial class FormStatus : DockContent
    {
        /************************************************************************************/
        private static readonly ILog Logger = log4net.LogManager.GetLogger("info");
        /************************************************************************************/
        private DeviceGroup p_DeviceGroup = DeviceGroup.CreateInstance();
        private List<UCCANStatus> p_ChannelStatusList = new List<UCCANStatus>();
        /************************************************************************************/
        #region public apis

        public FormStatus()
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
                AddChannel(channel);
            }
        }

        public void RemoveDevice(Device device, object paras)
        {
            List<UCCANStatus> pCANStatusList = GetMappingCANStatusList(device);
            foreach (UCCANStatus pCANStatus in pCANStatusList)
            {
                p_ChannelStatusList.Remove(pCANStatus);
                TabPage tabPage = (TabPage)pCANStatus.Parent;
                tabControl.TabPages.Remove(tabPage);
                tabPage.Dispose();
            }
        }

        public void UpdateDevice(Device device, object paras)
        {

        }

        #endregion

        #region private apis

        private void Init()
        {
            p_DeviceGroup.DeviceAdded += new DeviceEventHandler(this.AddDevice);
            p_DeviceGroup.DeviceRemoved += new DeviceEventHandler(this.RemoveDevice);
            p_DeviceGroup.DeviceUpdated += new DeviceEventHandler(this.UpdateDevice);
        }

        private void Finish()
        {
            p_DeviceGroup.DeviceAdded -= this.AddDevice;
            p_DeviceGroup.DeviceRemoved -= this.RemoveDevice;
            p_DeviceGroup.DeviceUpdated -= this.UpdateDevice;

            this.Dispose();
        }

        private List<UCCANStatus> GetMappingCANStatusList(Device device)
        {
            List<UCCANStatus> pCANStatusList = new List<UCCANStatus>();
            if (device == null)
            {
                return pCANStatusList;
            }
            foreach (UCCANStatus pCANStatus in this.p_ChannelStatusList)
            {
                Device parentDevice = pCANStatus.GetChannel().ParentDevice;
                if (Object.ReferenceEquals(device, parentDevice))
                {
                    pCANStatusList.Add(pCANStatus);
                }
            }
            return pCANStatusList;
        }

        private void AddChannel(Channel channel)
        {
            TabPage tabPage = new TabPage(channel.ChannelName);
            UCCANStatus pChnanelStatus = new UCCANStatus(channel);
            pChnanelStatus.Parent = tabPage;
            pChnanelStatus.Dock = DockStyle.Fill;
            tabControl.TabPages.Add(tabPage);
            p_ChannelStatusList.Add(pChnanelStatus);
        }

        #endregion

        #region events

        private void FormStatus_FormClosing(object sender, FormClosingEventArgs e)
        {
            Finish();
        }

        #endregion

    }
}
