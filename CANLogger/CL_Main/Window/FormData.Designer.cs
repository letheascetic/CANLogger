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
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.cbxFilter = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cFormat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripSend = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSendMode = new System.Windows.Forms.ToolStripButton();
            this.btnSendFile = new System.Windows.Forms.ToolStripButton();
            this.btnContinueShow = new System.Windows.Forms.ToolStripButton();
            this.btnStopShow = new System.Windows.Forms.ToolStripButton();
            this.btnShowMode = new System.Windows.Forms.ToolStripButton();
            this.btnClear = new System.Windows.Forms.ToolStripButton();
            this.btnFilter = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnRTSave = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.toolStripSend.SuspendLayout();
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
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.panel1);
            this.splitContainer.Panel2.Controls.Add(this.toolStripSend);
            // 
            // dgvData
            // 
            resources.ApplyResources(this.dgvData, "dgvData");
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cNO,
            this.cTime,
            this.cState,
            this.cID,
            this.cType,
            this.cFormat,
            this.cLength,
            this.cData});
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowTemplate.Height = 27;
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
            this.toolStripSeparator4,
            this.btnFilter,
            this.cbxFilter,
            this.toolStripSeparator1,
            this.btnSave,
            this.btnRTSave,
            this.toolStripSeparator2});
            resources.ApplyResources(this.toolStrip, "toolStrip");
            this.toolStrip.Name = "toolStrip";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // cbxFilter
            // 
            this.cbxFilter.BackColor = System.Drawing.SystemColors.ScrollBar;
            resources.ApplyResources(this.cbxFilter, "cbxFilter");
            this.cbxFilter.Name = "cbxFilter";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // cNO
            // 
            resources.ApplyResources(this.cNO, "cNO");
            this.cNO.Name = "cNO";
            this.cNO.ReadOnly = true;
            // 
            // cTime
            // 
            resources.ApplyResources(this.cTime, "cTime");
            this.cTime.Name = "cTime";
            this.cTime.ReadOnly = true;
            // 
            // cState
            // 
            resources.ApplyResources(this.cState, "cState");
            this.cState.Name = "cState";
            this.cState.ReadOnly = true;
            // 
            // cID
            // 
            resources.ApplyResources(this.cID, "cID");
            this.cID.Name = "cID";
            this.cID.ReadOnly = true;
            // 
            // cType
            // 
            resources.ApplyResources(this.cType, "cType");
            this.cType.Name = "cType";
            this.cType.ReadOnly = true;
            // 
            // cFormat
            // 
            resources.ApplyResources(this.cFormat, "cFormat");
            this.cFormat.Name = "cFormat";
            this.cFormat.ReadOnly = true;
            // 
            // cLength
            // 
            resources.ApplyResources(this.cLength, "cLength");
            this.cLength.Name = "cLength";
            this.cLength.ReadOnly = true;
            // 
            // cData
            // 
            resources.ApplyResources(this.cData, "cData");
            this.cData.Name = "cData";
            this.cData.ReadOnly = true;
            // 
            // toolStripSend
            // 
            this.toolStripSend.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.toolStripSend.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripSend.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSendMode,
            this.btnSendFile,
            this.toolStripSeparator3});
            resources.ApplyResources(this.toolStripSend, "toolStripSend");
            this.toolStripSend.Name = "toolStripSend";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // btnSendMode
            // 
            this.btnSendMode.Image = global::CL_Main.Properties.Resources.sendmode;
            resources.ApplyResources(this.btnSendMode, "btnSendMode");
            this.btnSendMode.Name = "btnSendMode";
            // 
            // btnSendFile
            // 
            this.btnSendFile.Image = global::CL_Main.Properties.Resources.sendfile;
            resources.ApplyResources(this.btnSendFile, "btnSendFile");
            this.btnSendFile.Name = "btnSendFile";
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
            // btnFilter
            // 
            this.btnFilter.Image = global::CL_Main.Properties.Resources.filter;
            resources.ApplyResources(this.btnFilter, "btnFilter");
            this.btnFilter.Name = "btnFilter";
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
            // FormData
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.toolStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormData";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.toolStripSend.ResumeLayout(false);
            this.toolStripSend.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnContinueShow;
        private System.Windows.Forms.ToolStripButton btnStopShow;
        private System.Windows.Forms.ToolStripButton btnShowMode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnFilter;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.ToolStripButton btnClear;
        private System.Windows.Forms.ToolStripComboBox cbxFilter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnRTSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn cState;
        private System.Windows.Forms.DataGridViewTextBoxColumn cID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cType;
        private System.Windows.Forms.DataGridViewTextBoxColumn cFormat;
        private System.Windows.Forms.DataGridViewTextBoxColumn cLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn cData;
        private System.Windows.Forms.ToolStrip toolStripSend;
        private System.Windows.Forms.ToolStripButton btnSendFile;
        private System.Windows.Forms.ToolStripButton btnSendMode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Panel panel1;
    }
}