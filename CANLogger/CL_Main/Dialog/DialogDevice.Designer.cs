namespace CL_Main
{
    partial class DialogDevice
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogDevice));
            this.panelTop = new System.Windows.Forms.Panel();
            this.lbVersion = new System.Windows.Forms.Label();
            this.panelBottom = new System.Windows.Forms.FlowLayoutPanel();
            this.btnConfigOnly = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.panelSelect = new System.Windows.Forms.Panel();
            this.btnOpenDevice = new System.Windows.Forms.Button();
            this.cbxSelectDevice = new System.Windows.Forms.ComboBox();
            this.lbSelectDevice = new System.Windows.Forms.Label();
            this.panelList = new System.Windows.Forms.Panel();
            this.dgvDevice = new System.Windows.Forms.DataGridView();
            this.cHWType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDeviceIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cHWVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cFWVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDriverVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cInVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cIRQNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cChannelNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSerialNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelConfig = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.cANBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panelTop.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelSelect.SuspendLayout();
            this.panelList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevice)).BeginInit();
            this.panelConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cANBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panelTop.Controls.Add(this.lbVersion);
            resources.ApplyResources(this.panelTop, "panelTop");
            this.panelTop.Name = "panelTop";
            // 
            // lbVersion
            // 
            resources.ApplyResources(this.lbVersion, "lbVersion");
            this.lbVersion.ForeColor = System.Drawing.Color.SteelBlue;
            this.lbVersion.Name = "lbVersion";
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panelBottom.Controls.Add(this.btnConfigOnly);
            this.panelBottom.Controls.Add(this.btnStart);
            resources.ApplyResources(this.panelBottom, "panelBottom");
            this.panelBottom.Name = "panelBottom";
            // 
            // btnConfigOnly
            // 
            resources.ApplyResources(this.btnConfigOnly, "btnConfigOnly");
            this.btnConfigOnly.Name = "btnConfigOnly";
            this.btnConfigOnly.UseVisualStyleBackColor = true;
            this.btnConfigOnly.Click += new System.EventHandler(this.btnConfigOnly_Click);
            // 
            // btnStart
            // 
            resources.ApplyResources(this.btnStart, "btnStart");
            this.btnStart.Name = "btnStart";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // panelSelect
            // 
            this.panelSelect.Controls.Add(this.btnOpenDevice);
            this.panelSelect.Controls.Add(this.cbxSelectDevice);
            this.panelSelect.Controls.Add(this.lbSelectDevice);
            resources.ApplyResources(this.panelSelect, "panelSelect");
            this.panelSelect.Name = "panelSelect";
            // 
            // btnOpenDevice
            // 
            resources.ApplyResources(this.btnOpenDevice, "btnOpenDevice");
            this.btnOpenDevice.Name = "btnOpenDevice";
            this.btnOpenDevice.UseVisualStyleBackColor = true;
            this.btnOpenDevice.Click += new System.EventHandler(this.btnOpenDevice_Click);
            // 
            // cbxSelectDevice
            // 
            this.cbxSelectDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSelectDevice.FormattingEnabled = true;
            resources.ApplyResources(this.cbxSelectDevice, "cbxSelectDevice");
            this.cbxSelectDevice.Name = "cbxSelectDevice";
            // 
            // lbSelectDevice
            // 
            resources.ApplyResources(this.lbSelectDevice, "lbSelectDevice");
            this.lbSelectDevice.Name = "lbSelectDevice";
            // 
            // panelList
            // 
            this.panelList.Controls.Add(this.dgvDevice);
            resources.ApplyResources(this.panelList, "panelList");
            this.panelList.Name = "panelList";
            // 
            // dgvDevice
            // 
            this.dgvDevice.AllowUserToAddRows = false;
            this.dgvDevice.AllowUserToDeleteRows = false;
            this.dgvDevice.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDevice.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDevice.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dgvDevice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDevice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDevice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cHWType,
            this.cDeviceIndex,
            this.cHWVersion,
            this.cFWVersion,
            this.cDriverVersion,
            this.cInVersion,
            this.cIRQNum,
            this.cChannelNum,
            this.cSerialNO});
            resources.ApplyResources(this.dgvDevice, "dgvDevice");
            this.dgvDevice.MultiSelect = false;
            this.dgvDevice.Name = "dgvDevice";
            this.dgvDevice.ReadOnly = true;
            this.dgvDevice.RowTemplate.Height = 27;
            // 
            // cHWType
            // 
            resources.ApplyResources(this.cHWType, "cHWType");
            this.cHWType.Name = "cHWType";
            this.cHWType.ReadOnly = true;
            // 
            // cDeviceIndex
            // 
            resources.ApplyResources(this.cDeviceIndex, "cDeviceIndex");
            this.cDeviceIndex.Name = "cDeviceIndex";
            this.cDeviceIndex.ReadOnly = true;
            // 
            // cHWVersion
            // 
            resources.ApplyResources(this.cHWVersion, "cHWVersion");
            this.cHWVersion.Name = "cHWVersion";
            this.cHWVersion.ReadOnly = true;
            // 
            // cFWVersion
            // 
            resources.ApplyResources(this.cFWVersion, "cFWVersion");
            this.cFWVersion.Name = "cFWVersion";
            this.cFWVersion.ReadOnly = true;
            // 
            // cDriverVersion
            // 
            resources.ApplyResources(this.cDriverVersion, "cDriverVersion");
            this.cDriverVersion.Name = "cDriverVersion";
            this.cDriverVersion.ReadOnly = true;
            // 
            // cInVersion
            // 
            resources.ApplyResources(this.cInVersion, "cInVersion");
            this.cInVersion.Name = "cInVersion";
            this.cInVersion.ReadOnly = true;
            // 
            // cIRQNum
            // 
            resources.ApplyResources(this.cIRQNum, "cIRQNum");
            this.cIRQNum.Name = "cIRQNum";
            this.cIRQNum.ReadOnly = true;
            // 
            // cChannelNum
            // 
            resources.ApplyResources(this.cChannelNum, "cChannelNum");
            this.cChannelNum.Name = "cChannelNum";
            this.cChannelNum.ReadOnly = true;
            // 
            // cSerialNO
            // 
            resources.ApplyResources(this.cSerialNO, "cSerialNO");
            this.cSerialNO.Name = "cSerialNO";
            this.cSerialNO.ReadOnly = true;
            // 
            // panelConfig
            // 
            this.panelConfig.Controls.Add(this.tabControl);
            resources.ApplyResources(this.panelConfig, "panelConfig");
            this.panelConfig.Name = "panelConfig";
            // 
            // tabControl
            // 
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            // 
            // cANBindingSource
            // 
            this.cANBindingSource.DataSource = typeof(CL_Framework.CAN);
            // 
            // DialogDevice
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelConfig);
            this.Controls.Add(this.panelList);
            this.Controls.Add(this.panelSelect);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DialogDevice";
            this.Load += new System.EventHandler(this.DialogDevice_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelSelect.ResumeLayout(false);
            this.panelSelect.PerformLayout();
            this.panelList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevice)).EndInit();
            this.panelConfig.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cANBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.FlowLayoutPanel panelBottom;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel panelSelect;
        private System.Windows.Forms.Panel panelList;
        private System.Windows.Forms.Panel panelConfig;
        private System.Windows.Forms.Label lbSelectDevice;
        private System.Windows.Forms.ComboBox cbxSelectDevice;
        private System.Windows.Forms.Button btnOpenDevice;
        private System.Windows.Forms.DataGridView dgvDevice;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Label lbVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cHWType;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDeviceIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn cHWVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cFWVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDriverVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cInVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cIRQNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn cChannelNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSerialNO;
        private System.Windows.Forms.Button btnConfigOnly;
        private System.Windows.Forms.BindingSource cANBindingSource;
    }
}