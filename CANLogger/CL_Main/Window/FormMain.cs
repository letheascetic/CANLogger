using CL_Framework;
using CL_Main.Dialog;
using Sunisoft.IrisSkin;
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
        private SkinEngine skinEngine;
        private DeviceGroup deviceGroup;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LogHelper.Log("FormMain_Load...");

            Thread thread = new Thread(new ThreadStart(Loading));
            thread.IsBackground = true;
            thread.Start();

            InitLoadControls();
            thread.Join();
        }

        private void InitVarialbes()
        {
            deviceGroup = new DeviceGroup();
        }

        private void Loading()
        {
            FormLoading formLoading = new FormLoading();
            formLoading.ShowDialog();
        }

        private void InitLoadSkinMenuItems()
        {
            LogHelper.Log("InitLoadSkinMenuItems...");
            skinEngine = new SkinEngine();
            List<string> skins = Directory.GetFiles(Application.StartupPath + @"\skins\", "*.ssk").ToList();

            int index = 0;
            skins.ForEach(skinFile =>
            {
                string itemText = Path.GetFileNameWithoutExtension(skinFile);
                ToolStripMenuItem skinItem = new ToolStripMenuItem(itemText);
                skinItem.Tag = skinFile;
                skinItem.Name = String.Concat("menuItemSkin", itemText.Replace(" ", ""));
                this.menuItemSkin.DropDownItems.Add(skinItem);
                index++;
            });
        }

        private void InitLoadControls()
        {
            LogHelper.Log("InitLoadControls...");
            InitLoadSkinMenuItems();

            //init & load FormData
            //FormData formData1 = new FormData();
            // formData2 = new FormData();
            //formData1.Show(this.dockPanel, DockState.Document);
            //formData2.Show(formData1.Pane, null);

            //init & load FormDevice
            FormDevice formDevice = new FormDevice();
            formDevice.Show(this.dockPanel, DockState.DockBottom);

            //init & load FormStatus
            FormStatus formSatus = new FormStatus();
            formSatus.Show(formDevice.Pane, DockAlignment.Right, 0.5);

            this.Activate();
        }

        private void SetLanguage(string language) 
        {
            LogHelper.Log(string.Format("SetLanguage To {0}...", language));
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(language);
            System.ComponentModel.ComponentResourceManager resources = new ComponentResourceManager(this.GetType());

            resources.ApplyResources(this, "$this");

            resources.ApplyResources(this.btnAddSet, this.btnAddSet.Name);
            resources.ApplyResources(this.lbFrameFormat, this.lbFrameFormat.Name);
            resources.ApplyResources(this.lbIDFormat, this.lbIDFormat.Name);

            cbxFrameFormat.Items[0] = resources.GetString("cbxFrameFormat.Items");
            cbxFrameFormat.Items[1] = resources.GetString("cbxFrameFormat.Items1");
            cbxFrameFormat.Items[2] = resources.GetString("cbxFrameFormat.Items2");

            cbxIDFormat.Items[0] = resources.GetString("cbxIDFormat.Items");

        }

        private void menuItemLanguage_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            LogHelper.Log(string.Format("menuItemLanguage_DropDownItemClicked -> clickedItem: [{0}]", e.ClickedItem.Text));
            ToolStripMenuItem item = (ToolStripMenuItem)e.ClickedItem;
            if (item.Checked)
            {
                return;
            }

            this.Cursor = Cursors.WaitCursor;
    
            SetLanguage((string)item.Tag);

            int oldIndex = Convert.ToInt32(menuItemLanguage.Tag);
            ToolStripMenuItem oldItem = (ToolStripMenuItem)menuItemLanguage.DropDownItems[oldIndex];
            oldItem.Checked = false;

            item.Checked = true;
            int newIndex = menuItemLanguage.DropDownItems.IndexOf(item);
            menuItemLanguage.Tag = newIndex;

            this.Cursor = Cursors.Default;
        }

        private void menuItemSkin_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            LogHelper.Log(string.Format("menuItemSkin_DropDownItemClicked -> clickedItem: [{0}]", e.ClickedItem.Text));
            ToolStripMenuItem item = (ToolStripMenuItem)e.ClickedItem;
            if (item.Checked)
            {
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            string skinFile = item.Tag == null ? null : (string)item.Tag;
            skinEngine.SkinFile = skinFile;

            int oldIndex = Convert.ToInt32(menuItemSkin.Tag);
            ToolStripMenuItem oldItem = (ToolStripMenuItem)menuItemSkin.DropDownItems[oldIndex];
            oldItem.Checked = false;

            item.Checked = true;
            int newIndex = menuItemSkin.DropDownItems.IndexOf(item);
            menuItemSkin.Tag = newIndex;

            this.Cursor = Cursors.Default;
        }

        private void btnAddSet_Click(object sender, EventArgs e)
        {
            //DialogDevice dialogDevice = new DialogDevice();
            //dialogDevice.Show();
        }
    }
}
