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
            this.btnAddSet = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnReset = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.dgvDeviceList = new System.Windows.Forms.DataGridView();
            this.cOpen = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cDevice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cChannelNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cBaudRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cBusLoad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cBusFlow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeviceList)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.SystemColors.MenuBar;
            resources.ApplyResources(this.toolStrip, "toolStrip");
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddSet,
            this.toolStripSeparator1,
            this.btnReset,
            this.toolStripSeparator2,
            this.btnDelete});
            this.toolStrip.Name = "toolStrip";
            // 
            // btnAddSet
            // 
            this.btnAddSet.Image = global::CL_Main.Properties.Resources.add;
            resources.ApplyResources(this.btnAddSet, "btnAddSet");
            this.btnAddSet.Name = "btnAddSet";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // btnReset
            // 
            this.btnReset.Image = global::CL_Main.Properties.Resources.reset;
            resources.ApplyResources(this.btnReset, "btnReset");
            this.btnReset.Name = "btnReset";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::CL_Main.Properties.Resources.delete;
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.Name = "btnDelete";
            // 
            // dgvDeviceList
            // 
            this.dgvDeviceList.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDeviceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeviceList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cOpen,
            this.cDevice,
            this.cChannelNum,
            this.cBaudRate,
            this.cBusLoad,
            this.cBusFlow});
            resources.ApplyResources(this.dgvDeviceList, "dgvDeviceList");
            this.dgvDeviceList.Name = "dgvDeviceList";
            this.dgvDeviceList.RowTemplate.Height = 27;
            // 
            // cOpen
            // 
            resources.ApplyResources(this.cOpen, "cOpen");
            this.cOpen.Name = "cOpen";
            // 
            // cDevice
            // 
            resources.ApplyResources(this.cDevice, "cDevice");
            this.cDevice.Name = "cDevice";
            // 
            // cChannelNum
            // 
            resources.ApplyResources(this.cChannelNum, "cChannelNum");
            this.cChannelNum.Name = "cChannelNum";
            // 
            // cBaudRate
            // 
            resources.ApplyResources(this.cBaudRate, "cBaudRate");
            this.cBaudRate.Name = "cBaudRate";
            // 
            // cBusLoad
            // 
            resources.ApplyResources(this.cBusLoad, "cBusLoad");
            this.cBusLoad.Name = "cBusLoad";
            // 
            // cBusFlow
            // 
            resources.ApplyResources(this.cBusFlow, "cBusFlow");
            this.cBusFlow.Name = "cBusFlow";
            // 
            // FormDevice
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.dgvDeviceList);
            this.Controls.Add(this.toolStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.HideOnClose = true;
            this.Name = "FormDevice";
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeviceList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnAddSet;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnReset;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.DataGridView dgvDeviceList;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cOpen;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDevice;
        private System.Windows.Forms.DataGridViewTextBoxColumn cChannelNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn cBaudRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn cBusLoad;
        private System.Windows.Forms.DataGridViewTextBoxColumn cBusFlow;
    }
}