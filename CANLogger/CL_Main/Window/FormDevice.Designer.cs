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
            this.chbxDevices = new System.Windows.Forms.CheckedListBox();
            this.dgvChannels = new System.Windows.Forms.DataGridView();
            this.cStart = new System.Windows.Forms.DataGridViewCheckBoxColumn();
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
            this.btnAddSet.Click += new System.EventHandler(this.btnAddSet_Click);
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
            // chbxDevices
            // 
            this.chbxDevices.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.chbxDevices, "chbxDevices");
            this.chbxDevices.FormattingEnabled = true;
            this.chbxDevices.Items.AddRange(new object[] {
            resources.GetString("chbxDevices.Items"),
            resources.GetString("chbxDevices.Items1")});
            this.chbxDevices.Name = "chbxDevices";
            this.chbxDevices.UseCompatibleTextRendering = true;
            this.chbxDevices.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chbxDevices_ItemCheck);
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
            this.cStart,
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
            // 
            // cStart
            // 
            resources.ApplyResources(this.cStart, "cStart");
            this.cStart.Name = "cStart";
            this.cStart.ReadOnly = true;
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
            this.Controls.Add(this.chbxDevices);
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
        private System.Windows.Forms.ToolStripButton btnAddSet;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnReset;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.CheckedListBox chbxDevices;
        private System.Windows.Forms.DataGridView dgvChannels;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn cChannelName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cChannelIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn cBaudRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn cBusLoad;
        private System.Windows.Forms.DataGridViewTextBoxColumn cBusFlow;
    }
}