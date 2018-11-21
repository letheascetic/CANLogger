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
            this.panelConfig = new System.Windows.Forms.Panel();
            this.tpgCAN1 = new System.Windows.Forms.TabPage();
            this.lbCAN1Channel = new System.Windows.Forms.Label();
            this.lbCAN1Name = new System.Windows.Forms.Label();
            this.tbxCAN1Name = new System.Windows.Forms.TextBox();
            this.lbCAN1Mode = new System.Windows.Forms.Label();
            this.cbxCAN1Mode = new System.Windows.Forms.ComboBox();
            this.lbCAN1BaudRate = new System.Windows.Forms.Label();
            this.cbxCAN1RaudRate = new System.Windows.Forms.ComboBox();
            this.tbxCAN1Channel = new System.Windows.Forms.TextBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpgCAN2 = new System.Windows.Forms.TabPage();
            this.tbxCAN2Channel = new System.Windows.Forms.TextBox();
            this.tbxCAN2Name = new System.Windows.Forms.TextBox();
            this.cbxCAN2BaudRate = new System.Windows.Forms.ComboBox();
            this.lbCAN2BaudRate = new System.Windows.Forms.Label();
            this.cbxCAN2Mode = new System.Windows.Forms.ComboBox();
            this.lbCAN2Mode = new System.Windows.Forms.Label();
            this.lbCAN2Name = new System.Windows.Forms.Label();
            this.lbCAN2Channel = new System.Windows.Forms.Label();
            this.cName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cHardware = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelBottom.SuspendLayout();
            this.panelSelect.SuspendLayout();
            this.panelList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevice)).BeginInit();
            this.panelConfig.SuspendLayout();
            this.tpgCAN1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tpgCAN2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(482, 77);
            this.panelTop.TabIndex = 0;
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panelBottom.Controls.Add(this.btnCancel);
            this.panelBottom.Controls.Add(this.btnOK);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.panelBottom.Location = new System.Drawing.Point(0, 413);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(482, 40);
            this.panelBottom.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(399, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnCancel.Size = new System.Drawing.Size(80, 30);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnOK.Location = new System.Drawing.Point(313, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 30);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // panelSelect
            // 
            this.panelSelect.Controls.Add(this.btnOpenDevice);
            this.panelSelect.Controls.Add(this.cbxSelectDevice);
            this.panelSelect.Controls.Add(this.lbSelectDevice);
            this.panelSelect.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSelect.Location = new System.Drawing.Point(0, 77);
            this.panelSelect.Name = "panelSelect";
            this.panelSelect.Size = new System.Drawing.Size(482, 38);
            this.panelSelect.TabIndex = 2;
            // 
            // btnOpenDevice
            // 
            this.btnOpenDevice.Location = new System.Drawing.Point(303, 5);
            this.btnOpenDevice.Name = "btnOpenDevice";
            this.btnOpenDevice.Size = new System.Drawing.Size(100, 30);
            this.btnOpenDevice.TabIndex = 1;
            this.btnOpenDevice.Text = "打开设备";
            this.btnOpenDevice.UseVisualStyleBackColor = true;
            // 
            // cbxSelectDevice
            // 
            this.cbxSelectDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSelectDevice.FormattingEnabled = true;
            this.cbxSelectDevice.Items.AddRange(new object[] {
            "USBCAN-II"});
            this.cbxSelectDevice.Location = new System.Drawing.Point(144, 5);
            this.cbxSelectDevice.Name = "cbxSelectDevice";
            this.cbxSelectDevice.Size = new System.Drawing.Size(140, 28);
            this.cbxSelectDevice.TabIndex = 0;
            // 
            // lbSelectDevice
            // 
            this.lbSelectDevice.AutoSize = true;
            this.lbSelectDevice.Location = new System.Drawing.Point(24, 8);
            this.lbSelectDevice.Name = "lbSelectDevice";
            this.lbSelectDevice.Size = new System.Drawing.Size(114, 20);
            this.lbSelectDevice.TabIndex = 0;
            this.lbSelectDevice.Text = "选择设备类型：";
            // 
            // panelList
            // 
            this.panelList.Controls.Add(this.dgvDevice);
            this.panelList.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelList.Location = new System.Drawing.Point(0, 115);
            this.panelList.Name = "panelList";
            this.panelList.Size = new System.Drawing.Size(482, 111);
            this.panelList.TabIndex = 3;
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
            this.dgvDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDevice.Location = new System.Drawing.Point(0, 0);
            this.dgvDevice.Name = "dgvDevice";
            this.dgvDevice.ReadOnly = true;
            this.dgvDevice.RowTemplate.Height = 27;
            this.dgvDevice.Size = new System.Drawing.Size(482, 111);
            this.dgvDevice.TabIndex = 0;
            // 
            // panelConfig
            // 
            this.panelConfig.Controls.Add(this.tabControl);
            this.panelConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelConfig.Location = new System.Drawing.Point(0, 226);
            this.panelConfig.Name = "panelConfig";
            this.panelConfig.Size = new System.Drawing.Size(482, 187);
            this.panelConfig.TabIndex = 4;
            // 
            // tpgCAN1
            // 
            this.tpgCAN1.Controls.Add(this.tbxCAN1Channel);
            this.tpgCAN1.Controls.Add(this.tbxCAN1Name);
            this.tpgCAN1.Controls.Add(this.cbxCAN1RaudRate);
            this.tpgCAN1.Controls.Add(this.lbCAN1BaudRate);
            this.tpgCAN1.Controls.Add(this.cbxCAN1Mode);
            this.tpgCAN1.Controls.Add(this.lbCAN1Mode);
            this.tpgCAN1.Controls.Add(this.lbCAN1Name);
            this.tpgCAN1.Controls.Add(this.lbCAN1Channel);
            this.tpgCAN1.Location = new System.Drawing.Point(4, 29);
            this.tpgCAN1.Name = "tpgCAN1";
            this.tpgCAN1.Padding = new System.Windows.Forms.Padding(3);
            this.tpgCAN1.Size = new System.Drawing.Size(474, 154);
            this.tpgCAN1.TabIndex = 0;
            this.tpgCAN1.Text = "CAN1";
            this.tpgCAN1.UseVisualStyleBackColor = true;
            // 
            // lbCAN1Channel
            // 
            this.lbCAN1Channel.AutoSize = true;
            this.lbCAN1Channel.Location = new System.Drawing.Point(20, 15);
            this.lbCAN1Channel.Name = "lbCAN1Channel";
            this.lbCAN1Channel.Size = new System.Drawing.Size(54, 20);
            this.lbCAN1Channel.TabIndex = 0;
            this.lbCAN1Channel.Text = "通道：";
            // 
            // lbCAN1Name
            // 
            this.lbCAN1Name.AutoSize = true;
            this.lbCAN1Name.Location = new System.Drawing.Point(21, 49);
            this.lbCAN1Name.Name = "lbCAN1Name";
            this.lbCAN1Name.Size = new System.Drawing.Size(54, 20);
            this.lbCAN1Name.TabIndex = 1;
            this.lbCAN1Name.Text = "名称：";
            // 
            // tbxCAN1Name
            // 
            this.tbxCAN1Name.Location = new System.Drawing.Point(97, 46);
            this.tbxCAN1Name.Name = "tbxCAN1Name";
            this.tbxCAN1Name.Size = new System.Drawing.Size(200, 27);
            this.tbxCAN1Name.TabIndex = 2;
            // 
            // lbCAN1Mode
            // 
            this.lbCAN1Mode.AutoSize = true;
            this.lbCAN1Mode.Location = new System.Drawing.Point(20, 82);
            this.lbCAN1Mode.Name = "lbCAN1Mode";
            this.lbCAN1Mode.Size = new System.Drawing.Size(54, 20);
            this.lbCAN1Mode.TabIndex = 3;
            this.lbCAN1Mode.Text = "模式：";
            // 
            // cbxCAN1Mode
            // 
            this.cbxCAN1Mode.FormattingEnabled = true;
            this.cbxCAN1Mode.Location = new System.Drawing.Point(97, 79);
            this.cbxCAN1Mode.Name = "cbxCAN1Mode";
            this.cbxCAN1Mode.Size = new System.Drawing.Size(121, 28);
            this.cbxCAN1Mode.TabIndex = 4;
            // 
            // lbCAN1BaudRate
            // 
            this.lbCAN1BaudRate.AutoSize = true;
            this.lbCAN1BaudRate.Location = new System.Drawing.Point(22, 116);
            this.lbCAN1BaudRate.Name = "lbCAN1BaudRate";
            this.lbCAN1BaudRate.Size = new System.Drawing.Size(69, 20);
            this.lbCAN1BaudRate.TabIndex = 5;
            this.lbCAN1BaudRate.Text = "波特率：";
            // 
            // cbxCAN1RaudRate
            // 
            this.cbxCAN1RaudRate.FormattingEnabled = true;
            this.cbxCAN1RaudRate.Location = new System.Drawing.Point(97, 113);
            this.cbxCAN1RaudRate.Name = "cbxCAN1RaudRate";
            this.cbxCAN1RaudRate.Size = new System.Drawing.Size(121, 28);
            this.cbxCAN1RaudRate.TabIndex = 6;
            // 
            // tbxCAN1Channel
            // 
            this.tbxCAN1Channel.Location = new System.Drawing.Point(97, 12);
            this.tbxCAN1Channel.Name = "tbxCAN1Channel";
            this.tbxCAN1Channel.ReadOnly = true;
            this.tbxCAN1Channel.Size = new System.Drawing.Size(50, 27);
            this.tbxCAN1Channel.TabIndex = 7;
            this.tbxCAN1Channel.Text = "CAN1";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpgCAN1);
            this.tabControl.Controls.Add(this.tpgCAN2);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(482, 187);
            this.tabControl.TabIndex = 0;
            // 
            // tpgCAN2
            // 
            this.tpgCAN2.Controls.Add(this.tbxCAN2Channel);
            this.tpgCAN2.Controls.Add(this.tbxCAN2Name);
            this.tpgCAN2.Controls.Add(this.cbxCAN2BaudRate);
            this.tpgCAN2.Controls.Add(this.lbCAN2BaudRate);
            this.tpgCAN2.Controls.Add(this.cbxCAN2Mode);
            this.tpgCAN2.Controls.Add(this.lbCAN2Mode);
            this.tpgCAN2.Controls.Add(this.lbCAN2Name);
            this.tpgCAN2.Controls.Add(this.lbCAN2Channel);
            this.tpgCAN2.Location = new System.Drawing.Point(4, 29);
            this.tpgCAN2.Name = "tpgCAN2";
            this.tpgCAN2.Padding = new System.Windows.Forms.Padding(3);
            this.tpgCAN2.Size = new System.Drawing.Size(474, 154);
            this.tpgCAN2.TabIndex = 1;
            this.tpgCAN2.Text = "CAN2";
            this.tpgCAN2.UseVisualStyleBackColor = true;
            // 
            // tbxCAN2Channel
            // 
            this.tbxCAN2Channel.Location = new System.Drawing.Point(97, 12);
            this.tbxCAN2Channel.Name = "tbxCAN2Channel";
            this.tbxCAN2Channel.ReadOnly = true;
            this.tbxCAN2Channel.Size = new System.Drawing.Size(50, 27);
            this.tbxCAN2Channel.TabIndex = 15;
            this.tbxCAN2Channel.Text = "CAN2";
            // 
            // tbxCAN2Name
            // 
            this.tbxCAN2Name.Location = new System.Drawing.Point(97, 46);
            this.tbxCAN2Name.Name = "tbxCAN2Name";
            this.tbxCAN2Name.Size = new System.Drawing.Size(200, 27);
            this.tbxCAN2Name.TabIndex = 10;
            // 
            // cbxCAN2BaudRate
            // 
            this.cbxCAN2BaudRate.FormattingEnabled = true;
            this.cbxCAN2BaudRate.Location = new System.Drawing.Point(97, 113);
            this.cbxCAN2BaudRate.Name = "cbxCAN2BaudRate";
            this.cbxCAN2BaudRate.Size = new System.Drawing.Size(121, 28);
            this.cbxCAN2BaudRate.TabIndex = 14;
            // 
            // lbCAN2BaudRate
            // 
            this.lbCAN2BaudRate.AutoSize = true;
            this.lbCAN2BaudRate.Location = new System.Drawing.Point(22, 116);
            this.lbCAN2BaudRate.Name = "lbCAN2BaudRate";
            this.lbCAN2BaudRate.Size = new System.Drawing.Size(69, 20);
            this.lbCAN2BaudRate.TabIndex = 13;
            this.lbCAN2BaudRate.Text = "波特率：";
            // 
            // cbxCAN2Mode
            // 
            this.cbxCAN2Mode.FormattingEnabled = true;
            this.cbxCAN2Mode.Location = new System.Drawing.Point(97, 79);
            this.cbxCAN2Mode.Name = "cbxCAN2Mode";
            this.cbxCAN2Mode.Size = new System.Drawing.Size(121, 28);
            this.cbxCAN2Mode.TabIndex = 12;
            // 
            // lbCAN2Mode
            // 
            this.lbCAN2Mode.AutoSize = true;
            this.lbCAN2Mode.Location = new System.Drawing.Point(20, 82);
            this.lbCAN2Mode.Name = "lbCAN2Mode";
            this.lbCAN2Mode.Size = new System.Drawing.Size(54, 20);
            this.lbCAN2Mode.TabIndex = 11;
            this.lbCAN2Mode.Text = "模式：";
            // 
            // lbCAN2Name
            // 
            this.lbCAN2Name.AutoSize = true;
            this.lbCAN2Name.Location = new System.Drawing.Point(21, 49);
            this.lbCAN2Name.Name = "lbCAN2Name";
            this.lbCAN2Name.Size = new System.Drawing.Size(54, 20);
            this.lbCAN2Name.TabIndex = 9;
            this.lbCAN2Name.Text = "名称：";
            // 
            // lbCAN2Channel
            // 
            this.lbCAN2Channel.AutoSize = true;
            this.lbCAN2Channel.Location = new System.Drawing.Point(20, 15);
            this.lbCAN2Channel.Name = "lbCAN2Channel";
            this.lbCAN2Channel.Size = new System.Drawing.Size(54, 20);
            this.lbCAN2Channel.TabIndex = 8;
            this.lbCAN2Channel.Text = "通道：";
            // 
            // cName
            // 
            this.cName.HeaderText = "Name";
            this.cName.Name = "cName";
            this.cName.ReadOnly = true;
            this.cName.Width = 150;
            // 
            // cHardware
            // 
            this.cHardware.HeaderText = "Hardware";
            this.cHardware.Name = "cHardware";
            this.cHardware.ReadOnly = true;
            this.cHardware.Width = 120;
            // 
            // cID
            // 
            this.cID.HeaderText = "ID";
            this.cID.Name = "cID";
            this.cID.ReadOnly = true;
            this.cID.Width = 150;
            // 
            // DialogDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 453);
            this.Controls.Add(this.panelConfig);
            this.Controls.Add(this.panelList);
            this.Controls.Add(this.panelSelect);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DialogDevice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加设备";
            this.panelBottom.ResumeLayout(false);
            this.panelSelect.ResumeLayout(false);
            this.panelSelect.PerformLayout();
            this.panelList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevice)).EndInit();
            this.panelConfig.ResumeLayout(false);
            this.tpgCAN1.ResumeLayout(false);
            this.tpgCAN1.PerformLayout();
            this.tabControl.ResumeLayout(false);
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
    }
}