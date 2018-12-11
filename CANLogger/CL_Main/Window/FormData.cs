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
    public partial class FormData : DockContent
    {
        private readonly static int SEND_MODE_NORMAL = 0;
        private readonly static int SEND_MODE_LIST = 1;
        private readonly static string[] SEND_MODE_DESC = new string[] { "普通发送模式", "列表发送模式" };

        private DeviceGroup pDeviceGroup = DeviceGroup.CreateInstance();
        private Channel channel = null;
        private UCNormalSendMode pUCSendModeNormal = null;
        private UCListSendMode pUCSendModeList = null;

        private int sendMode = SEND_MODE_LIST;

        #region public apis

        public FormData(Channel channel)
        {
            InitializeComponent();
            this.channel = channel;
        }

        public Channel GetChannel()
        {
            return this.channel;
        }

        #endregion

        #region private functions

        private void Init()
        {

            this.Text = channel.ChannelName;
            this.pUCSendModeNormal = new UCNormalSendMode(this.channel);
            this.pUCSendModeList = new UCListSendMode(this.channel);
            this.pnlSend.Controls.Add(this.pUCSendModeNormal);
            this.pnlSend.Controls.Add(this.pUCSendModeList);

            if (channel.IsStarted)
            {
                this.btnStartReset.Text = "复位CAN";
                this.btnStartReset.Image = global::CL_Main.Properties.Resources.stop;
            }
            else
            {
                this.btnStartReset.Text = "启动CAN";
                this.btnStartReset.Image = global::CL_Main.Properties.Resources.start;
            }

            pDeviceGroup.ChannelUpdated += new ChannelEventHandler(this.UpdateChannel);

            ChangeSendMode();
        }

        private void Finish()
        {
            pDeviceGroup.ChannelUpdated -= this.UpdateChannel;
            this.Dispose();
        }

        private void ChangeSendMode()
        {
            if (sendMode == SEND_MODE_NORMAL)
            {
                sendMode = SEND_MODE_LIST;
                this.pUCSendModeNormal.Dock = DockStyle.None;
                this.pUCSendModeNormal.Visible = false;
                this.pUCSendModeList.Dock = DockStyle.Fill;
                this.pUCSendModeList.Visible = true;
            }
            else
            {
                sendMode = SEND_MODE_NORMAL;
                this.pUCSendModeList.Dock = DockStyle.None;
                this.pUCSendModeList.Visible = false;
                this.pUCSendModeNormal.Dock = DockStyle.Fill;
                this.pUCSendModeNormal.Visible = true;
            }
            this.btnSendMode.Text = SEND_MODE_DESC[this.sendMode];
        }

        #endregion

        public void SetLanguage(string language)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(language);
            System.ComponentModel.ComponentResourceManager resources = new ComponentResourceManager(this.GetType());

            resources.ApplyResources(this, "$this");

            resources.ApplyResources(this.btnStartReset, this.btnStartReset.Name);
            resources.ApplyResources(this.btnShowMode, this.btnShowMode.Name);
            resources.ApplyResources(this.btnFilter, this.btnFilter.Name);

        }

        public void UpdateChannel(Channel channel, object paras)
        {

        }

        #region events

        private void FormData_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void btnSendMode_Click(object sender, EventArgs e)
        {
            ChangeSendMode();
        }

        private void btnStartReset_Click(object sender, EventArgs e)
        {
            if (channel.IsStarted)
            {
                string content = string.Format("确定要复位当前CAN通道[{0}]吗？", channel.ChannelName);
                DialogResult dialogResult = MessageBox.Show(content, "复位CAN", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.OK)
                {
                    if (channel.ResetCAN() == (uint)CAN_RESULT.SUCCESSFUL)
                    {
                        pDeviceGroup.UpdateChannel(channel);
                        return;
                    }
                    MessageBox.Show(string.Format("复位当前CAN通道[{0}]失败.", channel.ChannelName));
                }
            }
            else
            {
                if (channel.StartCAN() == (uint)CAN_RESULT.SUCCESSFUL)
                {
                    pDeviceGroup.UpdateChannel(channel);
                    return;
                }
                else
                {
                    MessageBox.Show(string.Format("启动当前CAN通道[{0}]失败.", channel.ChannelName));
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.dgvData.Rows.Clear();
        }

        private void FormData_FormClosing(object sender, FormClosingEventArgs e)
        {
            Finish();
        }

        #endregion


    }
}
