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
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAddSet = new System.Windows.Forms.ToolStripButton();
            this.btnReset = new System.Windows.Forms.ToolStripButton();
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
            this.toolStrip.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddSet,
            this.toolStripSeparator1,
            this.btnReset,
            this.toolStripSeparator2,
            this.btnDelete});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(570, 27);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // btnAddSet
            // 
            this.btnAddSet.Image = global::CL_Main.Properties.Resources.add;
            this.btnAddSet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddSet.Name = "btnAddSet";
            this.btnAddSet.Size = new System.Drawing.Size(99, 24);
            this.btnAddSet.Text = "添加/设置";
            // 
            // btnReset
            // 
            this.btnReset.Image = global::CL_Main.Properties.Resources.reset;
            this.btnReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(63, 24);
            this.btnReset.Text = "复位";
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::CL_Main.Properties.Resources.delete;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(63, 24);
            this.btnDelete.Text = "删除";
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
            this.dgvDeviceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDeviceList.Location = new System.Drawing.Point(0, 27);
            this.dgvDeviceList.Name = "dgvDeviceList";
            this.dgvDeviceList.RowTemplate.Height = 27;
            this.dgvDeviceList.Size = new System.Drawing.Size(570, 155);
            this.dgvDeviceList.TabIndex = 1;
            // 
            // cOpen
            // 
            this.cOpen.HeaderText = "状态";
            this.cOpen.Name = "cOpen";
            this.cOpen.Width = 50;
            // 
            // cDevice
            // 
            this.cDevice.HeaderText = "设备";
            this.cDevice.Name = "cDevice";
            this.cDevice.Width = 80;
            // 
            // cChannelNum
            // 
            this.cChannelNum.HeaderText = "通道数";
            this.cChannelNum.Name = "cChannelNum";
            // 
            // cBaudRate
            // 
            this.cBaudRate.HeaderText = "波特率";
            this.cBaudRate.Name = "cBaudRate";
            // 
            // cBusLoad
            // 
            this.cBusLoad.HeaderText = "总线负载";
            this.cBusLoad.Name = "cBusLoad";
            // 
            // cBusFlow
            // 
            this.cBusFlow.HeaderText = "总线流量";
            this.cBusFlow.Name = "cBusFlow";
            // 
            // FormDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(570, 182);
            this.Controls.Add(this.dgvDeviceList);
            this.Controls.Add(this.toolStrip);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormDevice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设备";
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