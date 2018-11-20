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
        private FormDevice formDevice;
        private FormStatus formSatus;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //Start Form Loading
            //FormLoading formLoading = new FormLoading();
            //formLoading.ShowDialog();

            InitLoadControls();

        }

        private void InitLoadControls()
        {
            //init & load FormDevice
            formDevice = new FormDevice();
            formDevice.TopLevel = false;
            formDevice.Parent = this.splitContainer.Panel1;
            formDevice.Location = new Point(0, 0);
            formDevice.Dock = DockStyle.Fill;
            formDevice.Show();

            //init & load FormStatus
            formSatus = new FormStatus();
            formSatus.TopLevel = false;
            formSatus.Parent = this.splitContainer.Panel2;
            formSatus.Location = new Point(0, 0);
            formSatus.Dock = DockStyle.Fill;
            formSatus.Show();
        }

        private void SetLanguage(string language) 
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(language);
            System.ComponentModel.ComponentResourceManager resources = new ComponentResourceManager(this.GetType());

            resources.ApplyResources(this, "$this");

            resources.ApplyResources(this.btnDevice, this.btnDevice.Name);
            resources.ApplyResources(this.lbFrameFormat, this.lbFrameFormat.Name);
            resources.ApplyResources(this.lbIDFormat, this.lbIDFormat.Name);

            cbxFrameFormat.Items[0] = resources.GetString("cbxFrameFormat.Items");
            cbxFrameFormat.Items[1] = resources.GetString("cbxFrameFormat.Items1");
            cbxFrameFormat.Items[2] = resources.GetString("cbxFrameFormat.Items2");

            cbxIDFormat.Items[0] = resources.GetString("cbxIDFormat.Items");

        }

        private void menuItemLanguage_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)e.ClickedItem;
            if (item.Checked)
            {
                return;
            }

            SetLanguage((string)item.Tag);

            int oldIndex = Convert.ToInt32(menuItemLanguage.Tag);
            ToolStripMenuItem oldItem = (ToolStripMenuItem)menuItemLanguage.DropDownItems[oldIndex];
            oldItem.Checked = false;

            item.Checked = true;
            int newIndex = menuItemLanguage.DropDownItems.IndexOf(item);
            menuItemLanguage.Tag = newIndex;
        }
    }
}
