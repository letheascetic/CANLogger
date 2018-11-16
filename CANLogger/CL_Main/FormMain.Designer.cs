﻿namespace CL_Main
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
            this.btnLanguage = new System.Windows.Forms.ToolStripDropDownButton();
            this.itemLanguageCN = new System.Windows.Forms.ToolStripMenuItem();
            this.itemLanguageEn = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripConfig = new System.Windows.Forms.ToolStrip();
            this.btnStart = new System.Windows.Forms.ToolStripButton();
            this.btnStop = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFilter = new System.Windows.Forms.ToolStripButton();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.toolStrip.SuspendLayout();
            this.toolStripConfig.SuspendLayout();
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
            this.toolStripSeparator3,
            this.btnLanguage});
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
            // btnLanguage
            // 
            this.btnLanguage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemLanguageCN,
            this.itemLanguageEn});
            this.btnLanguage.Image = global::CL_Main.Properties.Resources.language;
            resources.ApplyResources(this.btnLanguage, "btnLanguage");
            this.btnLanguage.Name = "btnLanguage";
            this.btnLanguage.Tag = "0";
            this.btnLanguage.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.btnLanguage_DropDownItemClicked);
            // 
            // itemLanguageCN
            // 
            this.itemLanguageCN.Checked = true;
            this.itemLanguageCN.CheckState = System.Windows.Forms.CheckState.Checked;
            this.itemLanguageCN.Name = "itemLanguageCN";
            resources.ApplyResources(this.itemLanguageCN, "itemLanguageCN");
            this.itemLanguageCN.Tag = "zh-CN";
            // 
            // itemLanguageEn
            // 
            this.itemLanguageEn.Name = "itemLanguageEn";
            resources.ApplyResources(this.itemLanguageEn, "itemLanguageEn");
            this.itemLanguageEn.Tag = "en";
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.Name = "statusStrip";
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.Name = "menuStrip";
            // 
            // toolStripConfig
            // 
            this.toolStripConfig.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.toolStripConfig.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripConfig.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnStart,
            this.btnStop,
            this.btnClose,
            this.toolStripSeparator4,
            this.btnFilter});
            resources.ApplyResources(this.toolStripConfig, "toolStripConfig");
            this.toolStripConfig.Name = "toolStripConfig";
            // 
            // btnStart
            // 
            this.btnStart.Image = global::CL_Main.Properties.Resources.start;
            resources.ApplyResources(this.btnStart, "btnStart");
            this.btnStart.Name = "btnStart";
            // 
            // btnStop
            // 
            this.btnStop.Image = global::CL_Main.Properties.Resources.stop;
            resources.ApplyResources(this.btnStop, "btnStop");
            this.btnStop.Name = "btnStop";
            // 
            // btnClose
            // 
            this.btnClose.Image = global::CL_Main.Properties.Resources.close;
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Name = "btnClose";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // btnFilter
            // 
            this.btnFilter.Image = global::CL_Main.Properties.Resources.filter;
            resources.ApplyResources(this.btnFilter, "btnFilter");
            this.btnFilter.Name = "btnFilter";
            // 
            // tabControl
            // 
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            // 
            // FormMain
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.toolStripConfig);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.Name = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.toolStripConfig.ResumeLayout(false);
            this.toolStripConfig.PerformLayout();
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
        private System.Windows.Forms.ToolStripDropDownButton btnLanguage;
        private System.Windows.Forms.ToolStripMenuItem itemDeviceUSBCANII;
        private System.Windows.Forms.ToolStripMenuItem itemLanguageCN;
        private System.Windows.Forms.ToolStripMenuItem itemLanguageEn;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStrip toolStripConfig;
        private System.Windows.Forms.ToolStripButton btnStart;
        private System.Windows.Forms.ToolStripButton btnStop;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnFilter;
        private System.Windows.Forms.TabControl tabControl;
    }
}
