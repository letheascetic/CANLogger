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

        #endregion

        #region private functions

        private void Init()
        {
            this.Text = channel.ChannelName;
            this.pUCSendModeNormal = new UCNormalSendMode(this.channel);
            this.pUCSendModeList = new UCListSendMode(this.channel);
            this.pnlSend.Controls.Add(this.pUCSendModeNormal);
            this.pnlSend.Controls.Add(this.pUCSendModeList);

            ChangeSendMode();
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

            resources.ApplyResources(this.btnContinueShow, this.btnContinueShow.Name);
            resources.ApplyResources(this.btnStopShow, this.btnStopShow.Name);
            resources.ApplyResources(this.btnShowMode, this.btnShowMode.Name);
            resources.ApplyResources(this.btnFilter, this.btnFilter.Name);

        }

        //private void Init()
        //{
        //    //ucSendModeNormal.Visible = SendMode == SEND_MODE_NORMAL ? true : false;

        //    //ucSendModeList = new UCListSendMode();
        //    //ucSendModeList.Parent = splitContainer.Panel2;
        //    //ucSendModeList.Dock = DockStyle.Fill;
        //    //ucSendModeList.Visible = SendMode == SEND_MODE_LIST ? true : false;

        //    //this.Text = channelName;
        //    //btnContinueShow.Enabled = !IsShowing;
        //    //btnStopShow.Enabled = IsShowing;
        //}

        #region events
        
        private void FormData_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void btnSendMode_Click(object sender, EventArgs e)
        {
            ChangeSendMode();
        }

        #endregion




    }
}
