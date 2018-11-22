namespace CL_Main
{
    partial class UCListSendMode
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.cSend = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cFrameID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cFrameType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDLC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTotalNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSendNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cInterval = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cSend,
            this.cNO,
            this.cName,
            this.cFrameID,
            this.cFrameType,
            this.cDLC,
            this.cData,
            this.cTotalNum,
            this.cSendNum,
            this.cInterval});
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(0, 0);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowTemplate.Height = 27;
            this.dgvData.Size = new System.Drawing.Size(1000, 120);
            this.dgvData.TabIndex = 0;
            // 
            // cSend
            // 
            this.cSend.HeaderText = "发送/停止";
            this.cSend.Name = "cSend";
            this.cSend.ReadOnly = true;
            this.cSend.Width = 81;
            // 
            // cNO
            // 
            this.cNO.HeaderText = "序号";
            this.cNO.Name = "cNO";
            this.cNO.ReadOnly = true;
            this.cNO.Width = 66;
            // 
            // cName
            // 
            this.cName.HeaderText = "名称";
            this.cName.Name = "cName";
            this.cName.ReadOnly = true;
            this.cName.Width = 66;
            // 
            // cFrameID
            // 
            this.cFrameID.HeaderText = "帧ID";
            this.cFrameID.Name = "cFrameID";
            this.cFrameID.ReadOnly = true;
            this.cFrameID.Width = 67;
            // 
            // cFrameType
            // 
            this.cFrameType.HeaderText = "帧类型";
            this.cFrameType.Name = "cFrameType";
            this.cFrameType.ReadOnly = true;
            this.cFrameType.Width = 81;
            // 
            // cDLC
            // 
            this.cDLC.HeaderText = "DLC";
            this.cDLC.Name = "cDLC";
            this.cDLC.ReadOnly = true;
            this.cDLC.Width = 60;
            // 
            // cData
            // 
            this.cData.HeaderText = "数据";
            this.cData.Name = "cData";
            this.cData.ReadOnly = true;
            this.cData.Width = 66;
            // 
            // cTotalNum
            // 
            this.cTotalNum.HeaderText = "总帧数量";
            this.cTotalNum.Name = "cTotalNum";
            this.cTotalNum.ReadOnly = true;
            this.cTotalNum.Width = 96;
            // 
            // cSendNum
            // 
            this.cSendNum.HeaderText = "已发送帧数";
            this.cSendNum.Name = "cSendNum";
            this.cSendNum.ReadOnly = true;
            this.cSendNum.Width = 111;
            // 
            // cInterval
            // 
            this.cInterval.HeaderText = "间隔时间";
            this.cInterval.Name = "cInterval";
            this.cInterval.ReadOnly = true;
            this.cInterval.Width = 96;
            // 
            // UCListSendMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvData);
            this.Name = "UCListSendMode";
            this.Size = new System.Drawing.Size(1000, 120);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cSend;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn cName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cFrameID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cFrameType;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDLC;
        private System.Windows.Forms.DataGridViewTextBoxColumn cData;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTotalNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSendNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn cInterval;
    }
}
