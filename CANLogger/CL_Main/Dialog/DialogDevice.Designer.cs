namespace CL_Main.Dialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogDevice));
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.panelSelect = new System.Windows.Forms.Panel();
            this.btnOpenDevice = new System.Windows.Forms.Button();
            this.cbxSelectDevice = new System.Windows.Forms.ComboBox();
            this.lbSelectDevice = new System.Windows.Forms.Label();
            this.panelList = new System.Windows.Forms.Panel();
            this.dgvDevice = new System.Windows.Forms.DataGridView();
            this.cName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cHardware = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelConfig = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpgCAN1 = new System.Windows.Forms.TabPage();
            this.lbCAN1K = new System.Windows.Forms.Label();
            this.tbxCAN1Channel = new System.Windows.Forms.TextBox();
            this.tbxCAN1Name = new System.Windows.Forms.TextBox();
            this.cbxCAN1RaudRate = new System.Windows.Forms.ComboBox();
            this.lbCAN1BaudRate = new System.Windows.Forms.Label();
            this.cbxCAN1Mode = new System.Windows.Forms.ComboBox();
            this.lbCAN1Mode = new System.Windows.Forms.Label();
            this.lbCAN1Name = new System.Windows.Forms.Label();
            this.lbCAN1Channel = new System.Windows.Forms.Label();
            this.tpgCAN2 = new System.Windows.Forms.TabPage();
            this.lbCAN2K = new System.Windows.Forms.Label();
            this.tbxCAN2Channel = new System.Windows.Forms.TextBox();
            this.tbxCAN2Name = new System.Windows.Forms.TextBox();
            this.cbxCAN2BaudRate = new System.Windows.Forms.ComboBox();
            this.lbCAN2BaudRate = new System.Windows.Forms.Label();
            this.cbxCAN2Mode = new System.Windows.Forms.ComboBox();
            this.lbCAN2Mode = new System.Windows.Forms.Label();
            this.lbCAN2Name = new System.Windows.Forms.Label();
            this.lbCAN2Channel = new System.Windows.Forms.Label();
            this.panelBottom.SuspendLayout();
            this.panelSelect.SuspendLayout();
            this.panelList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevice)).BeginInit();
            this.panelConfig.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tpgCAN1.SuspendLayout();
            this.tpgCAN2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            resources.ApplyResources(this.panelTop, "panelTop");
            this.panelTop.Name = "panelTop";
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panelBottom.Controls.Add(this.btnCancel);
            this.panelBottom.Controls.Add(this.btnOK);
            resources.ApplyResources(this.panelBottom, "panelBottom");
            this.panelBottom.Name = "panelBottom";
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
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
            this.dgvDevice.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dgvDevice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDevice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cName,
            this.cHardware,
            this.cID});
            resources.ApplyResources(this.dgvDevice, "dgvDevice");
            this.dgvDevice.Name = "dgvDevice";
            this.dgvDevice.ReadOnly = true;
            this.dgvDevice.RowTemplate.Height = 27;
            // 
            // cName
            // 
            resources.ApplyResources(this.cName, "cName");
            this.cName.Name = "cName";
            this.cName.ReadOnly = true;
            // 
            // cHardware
            // 
            resources.ApplyResources(this.cHardware, "cHardware");
            this.cHardware.Name = "cHardware";
            this.cHardware.ReadOnly = true;
            // 
            // cID
            // 
            resources.ApplyResources(this.cID, "cID");
            this.cID.Name = "cID";
            this.cID.ReadOnly = true;
            // 
            // panelConfig
            // 
            this.panelConfig.Controls.Add(this.tabControl);
            resources.ApplyResources(this.panelConfig, "panelConfig");
            this.panelConfig.Name = "panelConfig";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpgCAN1);
            this.tabControl.Controls.Add(this.tpgCAN2);
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            // 
            // tpgCAN1
            // 
            this.tpgCAN1.Controls.Add(this.lbCAN1K);
            this.tpgCAN1.Controls.Add(this.tbxCAN1Channel);
            this.tpgCAN1.Controls.Add(this.tbxCAN1Name);
            this.tpgCAN1.Controls.Add(this.cbxCAN1RaudRate);
            this.tpgCAN1.Controls.Add(this.lbCAN1BaudRate);
            this.tpgCAN1.Controls.Add(this.cbxCAN1Mode);
            this.tpgCAN1.Controls.Add(this.lbCAN1Mode);
            this.tpgCAN1.Controls.Add(this.lbCAN1Name);
            this.tpgCAN1.Controls.Add(this.lbCAN1Channel);
            resources.ApplyResources(this.tpgCAN1, "tpgCAN1");
            this.tpgCAN1.Name = "tpgCAN1";
            this.tpgCAN1.UseVisualStyleBackColor = true;
            // 
            // lbCAN1K
            // 
            resources.ApplyResources(this.lbCAN1K, "lbCAN1K");
            this.lbCAN1K.Name = "lbCAN1K";
            // 
            // tbxCAN1Channel
            // 
            resources.ApplyResources(this.tbxCAN1Channel, "tbxCAN1Channel");
            this.tbxCAN1Channel.Name = "tbxCAN1Channel";
            this.tbxCAN1Channel.ReadOnly = true;
            // 
            // tbxCAN1Name
            // 
            resources.ApplyResources(this.tbxCAN1Name, "tbxCAN1Name");
            this.tbxCAN1Name.Name = "tbxCAN1Name";
            // 
            // cbxCAN1RaudRate
            // 
            this.cbxCAN1RaudRate.FormattingEnabled = true;
            this.cbxCAN1RaudRate.Items.AddRange(new object[] {
            resources.GetString("cbxCAN1RaudRate.Items"),
            resources.GetString("cbxCAN1RaudRate.Items1"),
            resources.GetString("cbxCAN1RaudRate.Items2"),
            resources.GetString("cbxCAN1RaudRate.Items3"),
            resources.GetString("cbxCAN1RaudRate.Items4"),
            resources.GetString("cbxCAN1RaudRate.Items5"),
            resources.GetString("cbxCAN1RaudRate.Items6"),
            resources.GetString("cbxCAN1RaudRate.Items7"),
            resources.GetString("cbxCAN1RaudRate.Items8"),
            resources.GetString("cbxCAN1RaudRate.Items9"),
            resources.GetString("cbxCAN1RaudRate.Items10"),
            resources.GetString("cbxCAN1RaudRate.Items11"),
            resources.GetString("cbxCAN1RaudRate.Items12"),
            resources.GetString("cbxCAN1RaudRate.Items13"),
            resources.GetString("cbxCAN1RaudRate.Items14"),
            resources.GetString("cbxCAN1RaudRate.Items15")});
            resources.ApplyResources(this.cbxCAN1RaudRate, "cbxCAN1RaudRate");
            this.cbxCAN1RaudRate.Name = "cbxCAN1RaudRate";
            // 
            // lbCAN1BaudRate
            // 
            resources.ApplyResources(this.lbCAN1BaudRate, "lbCAN1BaudRate");
            this.lbCAN1BaudRate.Name = "lbCAN1BaudRate";
            // 
            // cbxCAN1Mode
            // 
            this.cbxCAN1Mode.FormattingEnabled = true;
            resources.ApplyResources(this.cbxCAN1Mode, "cbxCAN1Mode");
            this.cbxCAN1Mode.Name = "cbxCAN1Mode";
            // 
            // lbCAN1Mode
            // 
            resources.ApplyResources(this.lbCAN1Mode, "lbCAN1Mode");
            this.lbCAN1Mode.Name = "lbCAN1Mode";
            // 
            // lbCAN1Name
            // 
            resources.ApplyResources(this.lbCAN1Name, "lbCAN1Name");
            this.lbCAN1Name.Name = "lbCAN1Name";
            // 
            // lbCAN1Channel
            // 
            resources.ApplyResources(this.lbCAN1Channel, "lbCAN1Channel");
            this.lbCAN1Channel.Name = "lbCAN1Channel";
            // 
            // tpgCAN2
            // 
            this.tpgCAN2.Controls.Add(this.lbCAN2K);
            this.tpgCAN2.Controls.Add(this.tbxCAN2Channel);
            this.tpgCAN2.Controls.Add(this.tbxCAN2Name);
            this.tpgCAN2.Controls.Add(this.cbxCAN2BaudRate);
            this.tpgCAN2.Controls.Add(this.lbCAN2BaudRate);
            this.tpgCAN2.Controls.Add(this.cbxCAN2Mode);
            this.tpgCAN2.Controls.Add(this.lbCAN2Mode);
            this.tpgCAN2.Controls.Add(this.lbCAN2Name);
            this.tpgCAN2.Controls.Add(this.lbCAN2Channel);
            resources.ApplyResources(this.tpgCAN2, "tpgCAN2");
            this.tpgCAN2.Name = "tpgCAN2";
            this.tpgCAN2.UseVisualStyleBackColor = true;
            // 
            // lbCAN2K
            // 
            resources.ApplyResources(this.lbCAN2K, "lbCAN2K");
            this.lbCAN2K.Name = "lbCAN2K";
            // 
            // tbxCAN2Channel
            // 
            resources.ApplyResources(this.tbxCAN2Channel, "tbxCAN2Channel");
            this.tbxCAN2Channel.Name = "tbxCAN2Channel";
            this.tbxCAN2Channel.ReadOnly = true;
            // 
            // tbxCAN2Name
            // 
            resources.ApplyResources(this.tbxCAN2Name, "tbxCAN2Name");
            this.tbxCAN2Name.Name = "tbxCAN2Name";
            // 
            // cbxCAN2BaudRate
            // 
            this.cbxCAN2BaudRate.FormattingEnabled = true;
            this.cbxCAN2BaudRate.Items.AddRange(new object[] {
            resources.GetString("cbxCAN2BaudRate.Items"),
            resources.GetString("cbxCAN2BaudRate.Items1"),
            resources.GetString("cbxCAN2BaudRate.Items2"),
            resources.GetString("cbxCAN2BaudRate.Items3"),
            resources.GetString("cbxCAN2BaudRate.Items4"),
            resources.GetString("cbxCAN2BaudRate.Items5"),
            resources.GetString("cbxCAN2BaudRate.Items6"),
            resources.GetString("cbxCAN2BaudRate.Items7"),
            resources.GetString("cbxCAN2BaudRate.Items8"),
            resources.GetString("cbxCAN2BaudRate.Items9"),
            resources.GetString("cbxCAN2BaudRate.Items10"),
            resources.GetString("cbxCAN2BaudRate.Items11"),
            resources.GetString("cbxCAN2BaudRate.Items12"),
            resources.GetString("cbxCAN2BaudRate.Items13"),
            resources.GetString("cbxCAN2BaudRate.Items14"),
            resources.GetString("cbxCAN2BaudRate.Items15")});
            resources.ApplyResources(this.cbxCAN2BaudRate, "cbxCAN2BaudRate");
            this.cbxCAN2BaudRate.Name = "cbxCAN2BaudRate";
            // 
            // lbCAN2BaudRate
            // 
            resources.ApplyResources(this.lbCAN2BaudRate, "lbCAN2BaudRate");
            this.lbCAN2BaudRate.Name = "lbCAN2BaudRate";
            // 
            // cbxCAN2Mode
            // 
            this.cbxCAN2Mode.FormattingEnabled = true;
            resources.ApplyResources(this.cbxCAN2Mode, "cbxCAN2Mode");
            this.cbxCAN2Mode.Name = "cbxCAN2Mode";
            // 
            // lbCAN2Mode
            // 
            resources.ApplyResources(this.lbCAN2Mode, "lbCAN2Mode");
            this.lbCAN2Mode.Name = "lbCAN2Mode";
            // 
            // lbCAN2Name
            // 
            resources.ApplyResources(this.lbCAN2Name, "lbCAN2Name");
            this.lbCAN2Name.Name = "lbCAN2Name";
            // 
            // lbCAN2Channel
            // 
            resources.ApplyResources(this.lbCAN2Channel, "lbCAN2Channel");
            this.lbCAN2Channel.Name = "lbCAN2Channel";
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
            this.panelBottom.ResumeLayout(false);
            this.panelSelect.ResumeLayout(false);
            this.panelSelect.PerformLayout();
            this.panelList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevice)).EndInit();
            this.panelConfig.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tpgCAN1.ResumeLayout(false);
            this.tpgCAN1.PerformLayout();
            this.tpgCAN2.ResumeLayout(false);
            this.tpgCAN2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.FlowLayoutPanel panelBottom;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panelSelect;
        private System.Windows.Forms.Panel panelList;
        private System.Windows.Forms.Panel panelConfig;
        private System.Windows.Forms.Label lbSelectDevice;
        private System.Windows.Forms.ComboBox cbxSelectDevice;
        private System.Windows.Forms.Button btnOpenDevice;
        private System.Windows.Forms.DataGridView dgvDevice;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpgCAN1;
        private System.Windows.Forms.TextBox tbxCAN1Channel;
        private System.Windows.Forms.TextBox tbxCAN1Name;
        private System.Windows.Forms.ComboBox cbxCAN1RaudRate;
        private System.Windows.Forms.Label lbCAN1BaudRate;
        private System.Windows.Forms.ComboBox cbxCAN1Mode;
        private System.Windows.Forms.Label lbCAN1Mode;
        private System.Windows.Forms.Label lbCAN1Name;
        private System.Windows.Forms.Label lbCAN1Channel;
        private System.Windows.Forms.TabPage tpgCAN2;
        private System.Windows.Forms.TextBox tbxCAN2Channel;
        private System.Windows.Forms.TextBox tbxCAN2Name;
        private System.Windows.Forms.ComboBox cbxCAN2BaudRate;
        private System.Windows.Forms.Label lbCAN2BaudRate;
        private System.Windows.Forms.ComboBox cbxCAN2Mode;
        private System.Windows.Forms.Label lbCAN2Mode;
        private System.Windows.Forms.Label lbCAN2Name;
        private System.Windows.Forms.Label lbCAN2Channel;
        private System.Windows.Forms.DataGridViewTextBoxColumn cName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cHardware;
        private System.Windows.Forms.DataGridViewTextBoxColumn cID;
        private System.Windows.Forms.Label lbCAN1K;
        private System.Windows.Forms.Label lbCAN2K;
    }
}