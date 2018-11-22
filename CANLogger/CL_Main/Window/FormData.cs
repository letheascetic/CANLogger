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
        public readonly static int SEND_MODE_NORMAL = 0;
        public readonly static int SEND_MODE_LIST = 1;

        private bool isShowing = true;
        private int sendMode = SEND_MODE_NORMAL;

        //private UCNormalSendMode ucSendModeNormal;
        //private UCListSendMode ucSendModeList;

        public bool IsShowing
        { get { return isShowing; } set { isShowing = value; } }

        public int SendMode
        { get { return sendMode; } set { sendMode = value; } }

        public FormData()
        {
            InitializeComponent();
        }

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

        private void InitLoadControls()
        {
            //ucSendModeNormal.Visible = SendMode == SEND_MODE_NORMAL ? true : false;

            //ucSendModeList = new UCListSendMode();
            //ucSendModeList.Parent = splitContainer.Panel2;
            //ucSendModeList.Dock = DockStyle.Fill;
            //ucSendModeList.Visible = SendMode == SEND_MODE_LIST ? true : false;

            //this.Text = channelName;
            btnContinueShow.Enabled = !IsShowing;
            btnStopShow.Enabled = IsShowing;
        }

        private void FormData_Load(object sender, EventArgs e)
        {
            InitLoadControls();
        }

        private void btnSendMode_Click(object sender, EventArgs e)
        {

        }
    }
}
