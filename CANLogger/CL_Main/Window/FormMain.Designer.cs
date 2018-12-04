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
            this.lbSelectDevice = new System.Windows.Forms.ToolStripLabel();
            this.cbxSelectDevice = new System.Windows.Forms.ToolStripComboBox();
            this.sp1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnOperateDevice = new System.Windows.Forms.ToolStripDropDownButton();
            this.itemAddDevice = new System.Windows.Forms.ToolStripMenuItem();
            this.itemConfigDevice = new System.Windows.Forms.ToolStripMenuItem();
            this.itemResetDevice = new System.Windows.Forms.ToolStripMenuItem();
            this.itemDeleteDevice = new System.Windows.Forms.ToolStripMenuItem();
            this.sp2 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOption = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSkin = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSkinDefault = new System.Windows.Forms.ToolStripMenuItem();
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
            this.lbSelectDevice,
            this.cbxSelectDevice,
            this.sp1,
            this.btnOperateDevice,
            this.sp2});
            this.toolStrip.Name = "toolStrip";
            // 
            // lbSelectDevice
            // 
            this.lbSelectDevice.Name = "lbSelectDevice";
            resources.ApplyResources(this.lbSelectDevice, "lbSelectDevice");
            // 
            // cbxSelectDevice
            // 
            this.cbxSelectDevice.BackColor = System.Drawing.SystemColors.Control;
            this.cbxSelectDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbxSelectDevice, "cbxSelectDevice");
            this.cbxSelectDevice.Name = "cbxSelectDevice";
            this.cbxSelectDevice.SelectedIndexChanged += new System.EventHandler(this.cbxSelectDevice_SelectedIndexChanged);
            // 
            // sp1
            // 
            this.sp1.Name = "sp1";
            resources.ApplyResources(this.sp1, "sp1");
            // 
            // btnOperateDevice
            // 
            this.btnOperateDevice.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemAddDevice,
            this.itemConfigDevice,
            this.itemResetDevice,
            this.itemDeleteDevice});
            this.btnOperateDevice.Image = global::CL_Main.Properties.Resources.opertion;
            resources.ApplyResources(this.btnOperateDevice, "btnOperateDevice");
            this.btnOperateDevice.Name = "btnOperateDevice";
            // 
            // itemAddDevice
            // 
            this.itemAddDevice.Image = global::CL_Main.Properties.Resources.add;
            this.itemAddDevice.Name = "itemAddDevice";
            resources.ApplyResources(this.itemAddDevice, "itemAddDevice");
            this.itemAddDevice.Click += new System.EventHandler(this.itemAddDevice_Click);
            // 
            // itemConfigDevice
            // 
            this.itemConfigDevice.Image = global::CL_Main.Properties.Resources.config;
            this.itemConfigDevice.Name = "itemConfigDevice";
            resources.ApplyResources(this.itemConfigDevice, "itemConfigDevice");
            // 
            // itemResetDevice
            // 
            this.itemResetDevice.Image = global::CL_Main.Properties.Resources.resetall;
            this.itemResetDevice.Name = "itemResetDevice";
            resources.ApplyResources(this.itemResetDevice, "itemResetDevice");
            // 
            // itemDeleteDevice
            // 
            this.itemDeleteDevice.Image = global::CL_Main.Properties.Resources.delete;
            this.itemDeleteDevice.Name = "itemDeleteDevice";
            resources.ApplyResources(this.itemDeleteDevice, "itemDeleteDevice");
            this.itemDeleteDevice.Click += new System.EventHandler(this.itemDeleteDevice_Click);
            // 
            // sp2
            // 
            this.sp2.Name = "sp2";
            resources.ApplyResources(this.sp2, "sp2");
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
            this.menuItemSkin.Checked = true;
            this.menuItemSkin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuItemSkin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemSkinDefault});
            this.menuItemSkin.Image = global::CL_Main.Properties.Resources.skin;
            this.menuItemSkin.Name = "menuItemSkin";
            resources.ApplyResources(this.menuItemSkin, "menuItemSkin");
            this.menuItemSkin.Tag = "0";
            this.menuItemSkin.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuItemSkin_DropDownItemClicked);
            // 
            // menuItemSkinDefault
            // 
            this.menuItemSkinDefault.Checked = true;
            this.menuItemSkinDefault.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuItemSkinDefault.Name = "menuItemSkinDefault";
            resources.ApplyResources(this.menuItemSkinDefault, "menuItemSkinDefault");
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
            this.menuItemAbout.Click += new System.EventHandler(this.menuItemAbout_Click);
            // 
            // dockPanel
            // 
            this.dockPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
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
        private System.Windows.Forms.ToolStripSeparator sp1;
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
        private System.Windows.Forms.ToolStripMenuItem menuItemSkinDefault;
        private System.Windows.Forms.ToolStripLabel lbSelectDevice;
        private System.Windows.Forms.ToolStripComboBox cbxSelectDevice;
        private System.Windows.Forms.ToolStripDropDownButton btnOperateDevice;
        private System.Windows.Forms.ToolStripMenuItem itemAddDevice;
        private System.Windows.Forms.ToolStripMenuItem itemConfigDevice;
        private System.Windows.Forms.ToolStripMenuItem itemResetDevice;
        private System.Windows.Forms.ToolStripMenuItem itemDeleteDevice;
        private System.Windows.Forms.ToolStripSeparator sp2;
    }
}

