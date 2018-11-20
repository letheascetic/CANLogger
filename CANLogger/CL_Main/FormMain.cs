using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace CL_Main
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            new Sunisoft.IrisSkin.SkinEngine().SkinFile = "skins/MacOS.ssk";
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //Start Form Loading
            FormLoading formLoading = new FormLoading();
            formLoading.ShowDialog();

            InitLoadControls();
        }

        private void InitLoadControls()
        {
            //init & load FormData
            FormData formData1 = new FormData();
            FormData formData2 = new FormData();
            formData1.Show(this.dockPanel, DockState.Document);
            formData2.Show(formData1.Pane, null);

            //init & load FormDevice
            FormDevice formDevice = new FormDevice();
            formDevice.Show(this.dockPanel, DockState.DockBottom);

            //init & load FormStatus
            FormStatus formSatus = new FormStatus();
            formSatus.Show(formDevice.Pane, DockAlignment.Right, 0.5);

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
