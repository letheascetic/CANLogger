namespace CL_Main
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnDevice = new System.Windows.Forms.ToolStripDropDownButton();
            this.itemDeviceUSBCANII = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lbFrameFormat = new System.Windows.Forms.ToolStripLabel();
            this.cbxFrameFormat = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.lbIDFormat = new System.Windows.Forms.ToolStripLabel();
            this.cbxIDFormat = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOption = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSkin = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLanguageCN = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLanguageEN = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemManual = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.toolStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.SystemColors.MenuBar;
            resources.ApplyResources(this.toolStrip, "toolStrip");
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDevice,
            this.toolStripSeparator1,
            this.lbFrameFormat,
            this.cbxFrameFormat,
            this.toolStripSeparator2,
            this.lbIDFormat,
            this.cbxIDFormat,
            this.toolStripSeparator3});
            this.toolStrip.Name = "toolStrip";
            // 
            // btnDevice
            // 
            this.btnDevice.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemDeviceUSBCANII});
            this.btnDevice.Image = global::CL_Main.Properties.Resources.device;
            resources.ApplyResources(this.btnDevice, "btnDevice");
            this.btnDevice.Name = "btnDevice";
            // 
            // itemDeviceUSBCANII
            // 
            this.itemDeviceUSBCANII.Name = "itemDeviceUSBCANII";
            resources.ApplyResources(this.itemDeviceUSBCANII, "itemDeviceUSBCANII");
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // lbFrameFormat
            // 
            this.lbFrameFormat.Name = "lbFrameFormat";
            resources.ApplyResources(this.lbFrameFormat, "lbFrameFormat");
            // 
            // cbxFrameFormat
            // 
            resources.ApplyResources(this.cbxFrameFormat, "cbxFrameFormat");
            this.cbxFrameFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFrameFormat.DropDownWidth = 60;
            this.cbxFrameFormat.Items.AddRange(new object[] {
            resources.GetString("cbxFrameFormat.Items"),
            resources.GetString("cbxFrameFormat.Items1"),
            resources.GetString("cbxFrameFormat.Items2")});
            this.cbxFrameFormat.Name = "cbxFrameFormat";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // lbIDFormat
            // 
            this.lbIDFormat.Name = "lbIDFormat";
            resources.ApplyResources(this.lbIDFormat, "lbIDFormat");
            // 
            // cbxIDFormat
            // 
            resources.ApplyResources(this.cbxIDFormat, "cbxIDFormat");
            this.cbxIDFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxIDFormat.DropDownWidth = 60;
            this.cbxIDFormat.Items.AddRange(new object[] {
            resources.GetString("cbxIDFormat.Items")});
            this.cbxIDFormat.Name = "cbxIDFormat";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // statusStrip
            // 
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Name = "statusStrip";
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.Menu;
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile,
            this.menuItemOption,
            this.menuItemSkin,
            this.menuItemLanguage,
            this.menuItemHelp});
            this.menuStrip.Name = "menuStrip";
            // 
            // menuItemFile
            // 
            this.menuItemFile.Image = global::CL_Main.Properties.Resources.file;
            this.menuItemFile.Name = "menuItemFile";
            resources.ApplyResources(this.menuItemFile, "menuItemFile");
            // 
            // menuItemOption
            // 
            this.menuItemOption.Image = global::CL_Main.Properties.Resources.option;
            this.menuItemOption.Name = "menuItemOption";
            resources.ApplyResources(this.menuItemOption, "menuItemOption");
            // 
            // menuItemSkin
            // 
            this.menuItemSkin.Image = global::CL_Main.Properties.Resources.skin;
            this.menuItemSkin.Name = "menuItemSkin";
            resources.ApplyResources(this.menuItemSkin, "menuItemSkin");
            this.menuItemSkin.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuItemSkin_DropDownItemClicked);
            // 
            // menuItemLanguage
            // 
            this.menuItemLanguage.AutoToolTip = true;
            this.menuItemLanguage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemLanguageCN,
            this.menuItemLanguageEN});
            this.menuItemLanguage.Image = global::CL_Main.Properties.Resources.language;
            resources.ApplyResources(this.menuItemLanguage, "menuItemLanguage");
            this.menuItemLanguage.Name = "menuItemLanguage";
            this.menuItemLanguage.Tag = "0";
            this.menuItemLanguage.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuItemLanguage_DropDownItemClicked);
            // 
            // menuItemLanguageCN
            // 
            this.menuItemLanguageCN.Checked = true;
            this.menuItemLanguageCN.CheckState = System.Windows.Forms.CheckState.Checked;
            resources.ApplyResources(this.menuItemLanguageCN, "menuItemLanguageCN");
            this.menuItemLanguageCN.Name = "menuItemLanguageCN";
            this.menuItemLanguageCN.Tag = "zh-CN";
            // 
            // menuItemLanguageEN
            // 
            this.menuItemLanguageEN.Name = "menuItemLanguageEN";
            resources.ApplyResources(this.menuItemLanguageEN, "menuItemLanguageEN");
            this.menuItemLanguageEN.Tag = "en";
            // 
            // menuItemHelp
            // 
            this.menuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemManual,
            this.menuItemAbout});
            this.menuItemHelp.Image = global::CL_Main.Properties.Resources.help;
            this.menuItemHelp.Name = "menuItemHelp";
            resources.ApplyResources(this.menuItemHelp, "menuItemHelp");
            // 
            // menuItemManual
            // 
            this.menuItemManual.Name = "menuItemManual";
            resources.ApplyResources(this.menuItemManual, "menuItemManual");
            // 
            // menuItemAbout
            // 
            this.menuItemAbout.Name = "menuItemAbout";
            resources.ApplyResources(this.menuItemAbout, "menuItemAbout");
            // 
            // dockPanel
            // 
            resources.ApplyResources(this.dockPanel, "dockPanel");
            this.dockPanel.DockBottomPortion = 0.3D;
            this.dockPanel.Name = "dockPanel";
            // 
            // FormMain
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dockPanel);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.Name = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripDropDownButton btnDevice;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel lbFrameFormat;
        private System.Windows.Forms.ToolStripComboBox cbxFrameFormat;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel lbIDFormat;
        private System.Windows.Forms.ToolStripComboBox cbxIDFormat;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem itemDeviceUSBCANII;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuItemFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemOption;
        private System.Windows.Forms.ToolStripMenuItem menuItemLanguage;
        private System.Windows.Forms.ToolStripMenuItem menuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem menuItemLanguageCN;
        private System.Windows.Forms.ToolStripMenuItem menuItemLanguageEN;
        private System.Windows.Forms.ToolStripMenuItem menuItemAbout;
        private System.Windows.Forms.ToolStripMenuItem menuItemManual;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel;
        private System.Windows.Forms.ToolStripMenuItem menuItemSkin;
    }
}

