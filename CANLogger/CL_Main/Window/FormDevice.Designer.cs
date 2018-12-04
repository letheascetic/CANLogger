namespace CL_Main
{
    partial class FormDevice
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDevice));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.lbDevice = new System.Windows.Forms.ToolStripLabel();
            this.tbxDevice = new System.Windows.Forms.ToolStripTextBox();
            this.sp1 = new System.Windows.Forms.ToolStripSeparator();
            this.lbCAN = new System.Windows.Forms.ToolStripLabel();
            this.tbxCAN = new System.Windows.Forms.ToolStripTextBox();
            this.sp2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnOptionCAN = new System.Windows.Forms.ToolStripDropDownButton();
            this.itemStartCAN = new System.Windows.Forms.ToolStripMenuItem();
            this.itemResetCAN = new System.Windows.Forms.ToolStripMenuItem();
            this.sp3 = new System.Windows.Forms.ToolStripSeparator();
            this.dgvChannels = new System.Windows.Forms.DataGridView();
            this.cStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cMode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cChannelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cChannelIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cBaudRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cBusLoad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cBusFlow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChannels)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.SystemColors.MenuBar;
            resources.ApplyResources(this.toolStrip, "toolStrip");
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbDevice,
            this.tbxDevice,
            this.sp1,
            this.lbCAN,
            this.tbxCAN,
            this.sp2,
            this.btnOptionCAN,
            this.sp3});
            this.toolStrip.Name = "toolStrip";
            // 
            // lbDevice
            // 
            this.lbDevice.Name = "lbDevice";
            resources.ApplyResources(this.lbDevice, "lbDevice");
            // 
            // tbxDevice
            // 
            resources.ApplyResources(this.tbxDevice, "tbxDevice");
            this.tbxDevice.Name = "tbxDevice";
            this.tbxDevice.ReadOnly = true;
            // 
            // sp1
            // 
            this.sp1.Name = "sp1";
            resources.ApplyResources(this.sp1, "sp1");
            // 
            // lbCAN
            // 
            this.lbCAN.Name = "lbCAN";
            resources.ApplyResources(this.lbCAN, "lbCAN");
            // 
            // tbxCAN
            // 
            resources.ApplyResources(this.tbxCAN, "tbxCAN");
            this.tbxCAN.Name = "tbxCAN";
            this.tbxCAN.ReadOnly = true;
            // 
            // sp2
            // 
            this.sp2.Name = "sp2";
            resources.ApplyResources(this.sp2, "sp2");
            // 
            // btnOptionCAN
            // 
            this.btnOptionCAN.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemStartCAN,
            this.itemResetCAN});
            this.btnOptionCAN.Image = global::CL_Main.Properties.Resources.opertion;
            resources.ApplyResources(this.btnOptionCAN, "btnOptionCAN");
            this.btnOptionCAN.Name = "btnOptionCAN";
            // 
            // itemStartCAN
            // 
            this.itemStartCAN.Image = global::CL_Main.Properties.Resources.start;
            this.itemStartCAN.Name = "itemStartCAN";
            resources.ApplyResources(this.itemStartCAN, "itemStartCAN");
            // 
            // itemResetCAN
            // 
            this.itemResetCAN.Image = global::CL_Main.Properties.Resources.stop;
            this.itemResetCAN.Name = "itemResetCAN";
            resources.ApplyResources(this.itemResetCAN, "itemResetCAN");
            // 
            // sp3
            // 
            this.sp3.Name = "sp3";
            resources.ApplyResources(this.sp3, "sp3");
            // 
            // dgvChannels
            // 
            this.dgvChannels.AllowUserToAddRows = false;
            this.dgvChannels.AllowUserToDeleteRows = false;
            this.dgvChannels.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvChannels.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvChannels.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvChannels.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvChannels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChannels.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cStatus,
            this.cMode,
            this.cChannelName,
            this.cChannelIndex,
            this.cBaudRate,
            this.cBusLoad,
            this.cBusFlow});
            resources.ApplyResources(this.dgvChannels, "dgvChannels");
            this.dgvChannels.MultiSelect = false;
            this.dgvChannels.Name = "dgvChannels";
            this.dgvChannels.ReadOnly = true;
            this.dgvChannels.RowTemplate.Height = 27;
            this.dgvChannels.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChannels.SelectionChanged += new System.EventHandler(this.dgvChannels_SelectionChanged);
            // 
            // cStatus
            // 
            resources.ApplyResources(this.cStatus, "cStatus");
            this.cStatus.Name = "cStatus";
            this.cStatus.ReadOnly = true;
            this.cStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cMode
            // 
            resources.ApplyResources(this.cMode, "cMode");
            this.cMode.Name = "cMode";
            this.cMode.ReadOnly = true;
            // 
            // cChannelName
            // 
            resources.ApplyResources(this.cChannelName, "cChannelName");
            this.cChannelName.Name = "cChannelName";
            this.cChannelName.ReadOnly = true;
            // 
            // cChannelIndex
            // 
            resources.ApplyResources(this.cChannelIndex, "cChannelIndex");
            this.cChannelIndex.Name = "cChannelIndex";
            this.cChannelIndex.ReadOnly = true;
            // 
            // cBaudRate
            // 
            resources.ApplyResources(this.cBaudRate, "cBaudRate");
            this.cBaudRate.Name = "cBaudRate";
            this.cBaudRate.ReadOnly = true;
            // 
            // cBusLoad
            // 
            resources.ApplyResources(this.cBusLoad, "cBusLoad");
            this.cBusLoad.Name = "cBusLoad";
            this.cBusLoad.ReadOnly = true;
            // 
            // cBusFlow
            // 
            resources.ApplyResources(this.cBusFlow, "cBusFlow");
            this.cBusFlow.Name = "cBusFlow";
            this.cBusFlow.ReadOnly = true;
            // 
            // FormDevice
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.dgvChannels);
            this.Controls.Add(this.toolStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.HideOnClose = true;
            this.Name = "FormDevice";
            this.Load += new System.EventHandler(this.FormDevice_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChannels)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.DataGridView dgvChannels;
        private System.Windows.Forms.ToolStripLabel lbDevice;
        private System.Windows.Forms.ToolStripSeparator sp1;
        private System.Windows.Forms.ToolStripDropDownButton btnOptionCAN;
        private System.Windows.Forms.ToolStripMenuItem itemStartCAN;
        private System.Windows.Forms.ToolStripMenuItem itemResetCAN;
        private System.Windows.Forms.ToolStripLabel lbCAN;
        private System.Windows.Forms.ToolStripTextBox tbxCAN;
        private System.Windows.Forms.ToolStripSeparator sp2;
        private System.Windows.Forms.ToolStripSeparator sp3;
        private System.Windows.Forms.DataGridViewTextBoxColumn cStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn cMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn cChannelName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cChannelIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn cBaudRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn cBusLoad;
        private System.Windows.Forms.DataGridViewTextBoxColumn cBusFlow;
        private System.Windows.Forms.ToolStripTextBox tbxDevice;
    }
}