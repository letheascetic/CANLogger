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
            this.panelBottom.SuspendLayout();
            this.panelSelect.SuspendLayout();
            this.panelList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevice)).BeginInit();
            this.panelConfig.SuspendLayout();
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
            this.dgvDevice.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dgvDevice.BorderStyle = System.Windows.Forms.BorderStyle.None;
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
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn cName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cHardware;
        private System.Windows.Forms.DataGridViewTextBoxColumn cID;
        private System.Windows.Forms.TabControl tabControl;
    }
}