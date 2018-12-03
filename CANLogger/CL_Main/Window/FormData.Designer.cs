namespace CL_Main
{
    partial class FormData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormData));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.cNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTimeStamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cFrameID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cFrameType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cFrameFormat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDataLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlReceiveIcon = new System.Windows.Forms.Panel();
            this.pnlSendIcon = new System.Windows.Forms.Panel();
            this.toolStripSend = new System.Windows.Forms.ToolStrip();
            this.btnSendMode = new System.Windows.Forms.ToolStripButton();
            this.btnSendFile = new System.Windows.Forms.ToolStripButton();
            this.sp4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnContinueShow = new System.Windows.Forms.ToolStripButton();
            this.btnStopShow = new System.Windows.Forms.ToolStripButton();
            this.btnShowMode = new System.Windows.Forms.ToolStripButton();
            this.btnClear = new System.Windows.Forms.ToolStripButton();
            this.sp1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFilter = new System.Windows.Forms.ToolStripButton();
            this.cbxFilter = new System.Windows.Forms.ToolStripComboBox();
            this.sp2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnRTSave = new System.Windows.Forms.ToolStripButton();
            this.sp3 = new System.Windows.Forms.ToolStripSeparator();
            this.pnlSend = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.toolStripSend.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            resources.ApplyResources(this.splitContainer, "splitContainer");
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.dgvData);
            this.splitContainer.Panel1.Controls.Add(this.pnlReceiveIcon);
            // 
            // splitContainer.Panel2
            // 
            resources.ApplyResources(this.splitContainer.Panel2, "splitContainer.Panel2");
            this.splitContainer.Panel2.Controls.Add(this.pnlSend);
            this.splitContainer.Panel2.Controls.Add(this.pnlSendIcon);
            this.splitContainer.Panel2.Controls.Add(this.toolStripSend);
            // 
            // dgvData
            // 
            resources.ApplyResources(this.dgvData, "dgvData");
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cNO,
            this.cTimeStamp,
            this.cStatus,
            this.cFrameID,
            this.cFrameType,
            this.cFrameFormat,
            this.cDataLength,
            this.cData});
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowTemplate.Height = 27;
            // 
            // cNO
            // 
            resources.ApplyResources(this.cNO, "cNO");
            this.cNO.Name = "cNO";
            this.cNO.ReadOnly = true;
            // 
            // cTimeStamp
            // 
            resources.ApplyResources(this.cTimeStamp, "cTimeStamp");
            this.cTimeStamp.Name = "cTimeStamp";
            this.cTimeStamp.ReadOnly = true;
            // 
            // cStatus
            // 
            resources.ApplyResources(this.cStatus, "cStatus");
            this.cStatus.Name = "cStatus";
            this.cStatus.ReadOnly = true;
            // 
            // cFrameID
            // 
            resources.ApplyResources(this.cFrameID, "cFrameID");
            this.cFrameID.Name = "cFrameID";
            this.cFrameID.ReadOnly = true;
            // 
            // cFrameType
            // 
            resources.ApplyResources(this.cFrameType, "cFrameType");
            this.cFrameType.Name = "cFrameType";
            this.cFrameType.ReadOnly = true;
            // 
            // cFrameFormat
            // 
            resources.ApplyResources(this.cFrameFormat, "cFrameFormat");
            this.cFrameFormat.Name = "cFrameFormat";
            this.cFrameFormat.ReadOnly = true;
            // 
            // cDataLength
            // 
            resources.ApplyResources(this.cDataLength, "cDataLength");
            this.cDataLength.Name = "cDataLength";
            this.cDataLength.ReadOnly = true;
            // 
            // cData
            // 
            resources.ApplyResources(this.cData, "cData");
            this.cData.Name = "cData";
            this.cData.ReadOnly = true;
            // 
            // pnlReceiveIcon
            // 
            this.pnlReceiveIcon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.pnlReceiveIcon, "pnlReceiveIcon");
            this.pnlReceiveIcon.Name = "pnlReceiveIcon";
            // 
            // pnlSendIcon
            // 
            this.pnlSendIcon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.pnlSendIcon, "pnlSendIcon");
            this.pnlSendIcon.Name = "pnlSendIcon";
            // 
            // toolStripSend
            // 
            this.toolStripSend.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.toolStripSend.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripSend.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSendMode,
            this.btnSendFile,
            this.sp4});
            resources.ApplyResources(this.toolStripSend, "toolStripSend");
            this.toolStripSend.Name = "toolStripSend";
            // 
            // btnSendMode
            // 
            this.btnSendMode.Image = global::CL_Main.Properties.Resources.sendmode;
            resources.ApplyResources(this.btnSendMode, "btnSendMode");
            this.btnSendMode.Name = "btnSendMode";
            this.btnSendMode.Click += new System.EventHandler(this.btnSendMode_Click);
            // 
            // btnSendFile
            // 
            this.btnSendFile.Image = global::CL_Main.Properties.Resources.sendfile;
            resources.ApplyResources(this.btnSendFile, "btnSendFile");
            this.btnSendFile.Name = "btnSendFile";
            // 
            // sp4
            // 
            this.sp4.Name = "sp4";
            resources.ApplyResources(this.sp4, "sp4");
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnContinueShow,
            this.btnStopShow,
            this.btnShowMode,
            this.btnClear,
            this.sp1,
            this.btnFilter,
            this.cbxFilter,
            this.sp2,
            this.btnSave,
            this.btnRTSave,
            this.sp3});
            resources.ApplyResources(this.toolStrip, "toolStrip");
            this.toolStrip.Name = "toolStrip";
            // 
            // btnContinueShow
            // 
            this.btnContinueShow.Image = global::CL_Main.Properties.Resources.start;
            resources.ApplyResources(this.btnContinueShow, "btnContinueShow");
            this.btnContinueShow.Name = "btnContinueShow";
            // 
            // btnStopShow
            // 
            this.btnStopShow.Image = global::CL_Main.Properties.Resources.stop;
            resources.ApplyResources(this.btnStopShow, "btnStopShow");
            this.btnStopShow.Name = "btnStopShow";
            // 
            // btnShowMode
            // 
            this.btnShowMode.Image = global::CL_Main.Properties.Resources.showmode;
            resources.ApplyResources(this.btnShowMode, "btnShowMode");
            this.btnShowMode.Name = "btnShowMode";
            // 
            // btnClear
            // 
            this.btnClear.Image = global::CL_Main.Properties.Resources.clear;
            resources.ApplyResources(this.btnClear, "btnClear");
            this.btnClear.Name = "btnClear";
            // 
            // sp1
            // 
            this.sp1.Name = "sp1";
            resources.ApplyResources(this.sp1, "sp1");
            // 
            // btnFilter
            // 
            this.btnFilter.Image = global::CL_Main.Properties.Resources.filter;
            resources.ApplyResources(this.btnFilter, "btnFilter");
            this.btnFilter.Name = "btnFilter";
            // 
            // cbxFilter
            // 
            this.cbxFilter.BackColor = System.Drawing.SystemColors.ScrollBar;
            resources.ApplyResources(this.cbxFilter, "cbxFilter");
            this.cbxFilter.Name = "cbxFilter";
            // 
            // sp2
            // 
            this.sp2.Name = "sp2";
            resources.ApplyResources(this.sp2, "sp2");
            // 
            // btnSave
            // 
            this.btnSave.Image = global::CL_Main.Properties.Resources.save;
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            // 
            // btnRTSave
            // 
            this.btnRTSave.Image = global::CL_Main.Properties.Resources.rtsave;
            resources.ApplyResources(this.btnRTSave, "btnRTSave");
            this.btnRTSave.Name = "btnRTSave";
            // 
            // sp3
            // 
            this.sp3.Name = "sp3";
            resources.ApplyResources(this.sp3, "sp3");
            // 
            // pnlSend
            // 
            resources.ApplyResources(this.pnlSend, "pnlSend");
            this.pnlSend.Name = "pnlSend";
            // 
            // FormData
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.toolStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormData";
            this.Load += new System.EventHandler(this.FormData_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.toolStripSend.ResumeLayout(false);
            this.toolStripSend.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnContinueShow;
        private System.Windows.Forms.ToolStripButton btnStopShow;
        private System.Windows.Forms.ToolStripButton btnShowMode;
        private System.Windows.Forms.ToolStripSeparator sp1;
        private System.Windows.Forms.ToolStripButton btnFilter;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ToolStripButton btnClear;
        private System.Windows.Forms.ToolStripComboBox cbxFilter;
        private System.Windows.Forms.ToolStripSeparator sp2;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnRTSave;
        private System.Windows.Forms.ToolStripSeparator sp3;
        private System.Windows.Forms.ToolStrip toolStripSend;
        private System.Windows.Forms.ToolStripButton btnSendFile;
        private System.Windows.Forms.ToolStripButton btnSendMode;
        private System.Windows.Forms.ToolStripSeparator sp4;
        private System.Windows.Forms.Panel pnlSendIcon;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Panel pnlReceiveIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTimeStamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn cStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn cFrameID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cFrameType;
        private System.Windows.Forms.DataGridViewTextBoxColumn cFrameFormat;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDataLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn cData;
        private System.Windows.Forms.Panel pnlSend;
    }
}