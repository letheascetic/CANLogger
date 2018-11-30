using CL_Framework;
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
        private DeviceGroup pMeviceGroup = DeviceGroup.CreateInstance();
        private List<Device> pDevices = new List<Device>();
        private List<UCCANStatus> pChannelStatusList = new List<UCCANStatus>();

        public FormStatus()
        {
            InitializeComponent();
            InitLoadControls();
        }

        public bool AddDevice(Device newDevice)
        {
            if (newDevice == null)
            {
                LogHelper.Log("newDevice could not be null");
                return false;
            }

            for (uint channelIndex = 0; channelIndex < newDevice.CANNum; channelIndex++)
            {
                Channel channel = newDevice.GetChannel(channelIndex);
                AddChannel(channel);
            }

            pDevices.Add(newDevice);
            return true;
        }

        public bool RemoveDevice(Device device)
        {
            if (device == null)
            {
                LogHelper.Log("device could not be null");
                return false;
            }

            foreach (UCCANStatus pChannelStatus in pChannelStatusList)
            {
                if (Object.ReferenceEquals(device, pChannelStatus.GetChannel().ParentDevice))
                {
                    TabPage tabPage = (TabPage)pChannelStatus.Parent;

                }
            }

            return false;
        }

        public void SetLanguage(string language)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(language);
            System.ComponentModel.ComponentResourceManager resources = new ComponentResourceManager(this.GetType());

            resources.ApplyResources(this, "$this");
        }

        private void InitLoadControls()
        {
            //UCStatus statusChannel1 = new UCStatus();
            //TabPage tabPage1 = new TabPage();
            //tabPage1.Text = "CAN1";
            //tabPage1.Controls.Add(statusChannel1);
            //statusChannel1.Dock = DockStyle.Fill;
            //this.tabControl.Controls.Add(tabPage1);

            //UCStatus statusChannel2 = new UCStatus();
            //TabPage tabPage2 = new TabPage();
            //tabPage2.Text = "CAN2";
            //tabPage2.Controls.Add(statusChannel2);
            //statusChannel2.Dock = DockStyle.Fill;
            //this.tabControl.Controls.Add(tabPage2);
        }

        private void AddChannel(Channel channel)
        {
            TabPage tabPage = new TabPage(channel.ChannelName);
            
            UCCANStatus pChnanelStatus = new UCCANStatus(channel);
            pChnanelStatus.Parent = tabPage;
            pChnanelStatus.Dock = DockStyle.Fill;

            tabControl.TabPages.Add(tabPage);

            pChannelStatusList.Add(pChnanelStatus);
        }

        private void FormStatus_Load(object sender, EventArgs e)
        {

        }
    }
}
