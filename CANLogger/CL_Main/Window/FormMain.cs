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
using System.Reflection;
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
        private DeviceGroup deviceGroup = new DeviceGroup();

        private List<FormData> formDataList = new List<FormData>();
        private FormDevice formDevice = new FormDevice();
        private FormStatus formStatus = new FormStatus();


        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(Loading));
            thread.IsBackground = true;
            thread.Start();

            InitVarialbes();
            InitLoadControls();
            thread.Join();
        }

        private void InitVarialbes()
        {
            
        }

        private void Loading()
        {
            FormLoading formLoading = new FormLoading();
            formLoading.ShowDialog();
        }

        private void InitLoadSkinMenuItems()
        {
            skinEngine = new SkinEngine();
            List<string> skins = Directory.GetFiles(Application.StartupPath + @"\skins\", "*.ssk").ToList();

            int index = 0;
            skins.ForEach(skinFile =>
            {
                LogHelper.Log(string.Format("get skin file: [{0}]", skinFile));
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
            InitLoadSkinMenuItems();

            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            this.Text += version;

            LogHelper.Log(string.Format("get CAN Logger version: [{0}]", version));

            //init & load FormData
            //FormData formData1 = new FormData();
            // formData2 = new FormData();
            //formData1.Show(this.dockPanel, DockState.Document);
            //formData2.Show(formData1.Pane, null);

            // init & load FormDevice
            formDevice.Show(this.dockPanel, DockState.DockBottom);

            //init & load FormStatus
            formStatus.Show(formDevice.Pane, DockAlignment.Right, 0.5);

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

        private void UpdateControls()
        {

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
            Device device = this.formDevice.GetSelectedDevice();
            bool isNewDevice = device == null ? true : false;

            DialogDevice dialogDevice = new DialogDevice(device);
            if (dialogDevice.ShowDialog() == DialogResult.OK)
            {
                this.formDevice.UpdateControls();
                //this.formStatus.UpdateControls();
                dialogDevice.Close();
            }
        }

    }
}
