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
        public FormStatus()
        {
            InitializeComponent();
            InitLoadControls();
        }

        private void InitLoadControls()
        {
            UCStatus statusChannel1 = new UCStatus();
            TabPage tabPage1 = new TabPage();
            tabPage1.Text = "CAN1";
            tabPage1.Controls.Add(statusChannel1);
            statusChannel1.Dock = DockStyle.Fill;
            this.tabControl.Controls.Add(tabPage1);

            UCStatus statusChannel2 = new UCStatus();
            TabPage tabPage2 = new TabPage();
            tabPage2.Text = "CAN2";
            tabPage2.Controls.Add(statusChannel2);
            statusChannel2.Dock = DockStyle.Fill;
            this.tabControl.Controls.Add(tabPage2);
        }

        public void SetLanguage(string language)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(language);
            System.ComponentModel.ComponentResourceManager resources = new ComponentResourceManager(this.GetType());

            resources.ApplyResources(this, "$this");
        }
    }
}
