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

namespace CL_Main
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //Start Form Loading
            //FormLoading formLoading = new FormLoading();
            //formLoading.ShowDialog();
        }

        private void SetLanguage(string language) 
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(language);
            System.ComponentModel.ComponentResourceManager resources = new ComponentResourceManager(this.GetType());

            resources.ApplyResources(this, "$this");

            resources.ApplyResources(this.btnDevice, this.btnDevice.Name);
            resources.ApplyResources(this.lbFrameFormat, this.lbFrameFormat.Name);
            resources.ApplyResources(this.lbIDFormat, this.lbIDFormat.Name);
            resources.ApplyResources(this.btnLanguage, this.btnLanguage.Name);

            resources.ApplyResources(this.btnStart, this.btnStart.Name);
            resources.ApplyResources(this.btnStop, this.btnStop.Name);
            resources.ApplyResources(this.btnClose, this.btnClose.Name);
            resources.ApplyResources(this.btnFilter, this.btnFilter.Name);

            cbxFrameFormat.Items[0] = resources.GetString("cbxFrameFormat.Items");
            cbxFrameFormat.Items[1] = resources.GetString("cbxFrameFormat.Items1");
            cbxFrameFormat.Items[2] = resources.GetString("cbxFrameFormat.Items2");

            cbxIDFormat.Items[0] = resources.GetString("cbxIDFormat.Items");

        }

        private void btnLanguage_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)e.ClickedItem;
            if (item.Checked)
            {
                return;
            }

            SetLanguage((string)item.Tag);

            int oldIndex = Convert.ToInt32(btnLanguage.Tag);
            ToolStripMenuItem oldItem = (ToolStripMenuItem)btnLanguage.DropDownItems[oldIndex];
            oldItem.Checked = false;

            item.Checked = true;
            int newIndex = btnLanguage.DropDownItems.IndexOf(item);
            btnLanguage.Tag = newIndex;
            
        }

    }
}
