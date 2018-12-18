namespace CL_Main
{
    partial class DisplayConfigDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisplayConfigDialog));
            this.rbRolling = new System.Windows.Forms.RadioButton();
            this.rbStatistical = new System.Windows.Forms.RadioButton();
            this.gbxStatistical = new System.Windows.Forms.GroupBox();
            this.chbxData = new System.Windows.Forms.CheckBox();
            this.chbxType = new System.Windows.Forms.CheckBox();
            this.chbxFormat = new System.Windows.Forms.CheckBox();
            this.chbxID = new System.Windows.Forms.CheckBox();
            this.chbxName = new System.Windows.Forms.CheckBox();
            this.lbStatistical = new System.Windows.Forms.Label();
            this.chbxSendFrame = new System.Windows.Forms.CheckBox();
            this.chbxErrorFrame = new System.Windows.Forms.CheckBox();
            this.chbxLocalTime = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chbxInterval = new System.Windows.Forms.CheckBox();
            this.gbxStatistical.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbRolling
            // 
            this.rbRolling.AutoSize = true;
            this.rbRolling.Location = new System.Drawing.Point(28, 12);
            this.rbRolling.Name = "rbRolling";
            this.rbRolling.Size = new System.Drawing.Size(90, 24);
            this.rbRolling.TabIndex = 0;
            this.rbRolling.TabStop = true;
            this.rbRolling.Text = "滚动模式";
            this.rbRolling.UseVisualStyleBackColor = true;
            // 
            // rbStatistical
            // 
            this.rbStatistical.AutoSize = true;
            this.rbStatistical.Location = new System.Drawing.Point(133, 12);
            this.rbStatistical.Name = "rbStatistical";
            this.rbStatistical.Size = new System.Drawing.Size(90, 24);
            this.rbStatistical.TabIndex = 1;
            this.rbStatistical.TabStop = true;
            this.rbStatistical.Text = "统计模式";
            this.rbStatistical.UseVisualStyleBackColor = true;
            // 
            // gbxStatistical
            // 
            this.gbxStatistical.Controls.Add(this.chbxData);
            this.gbxStatistical.Controls.Add(this.chbxType);
            this.gbxStatistical.Controls.Add(this.chbxFormat);
            this.gbxStatistical.Controls.Add(this.chbxID);
            this.gbxStatistical.Controls.Add(this.chbxName);
            this.gbxStatistical.Controls.Add(this.lbStatistical);
            this.gbxStatistical.Location = new System.Drawing.Point(23, 54);
            this.gbxStatistical.Name = "gbxStatistical";
            this.gbxStatistical.Size = new System.Drawing.Size(367, 137);
            this.gbxStatistical.TabIndex = 2;
            this.gbxStatistical.TabStop = false;
            this.gbxStatistical.Text = "统计模式显示规则";
            // 
            // chbxData
            // 
            this.chbxData.AutoSize = true;
            this.chbxData.Location = new System.Drawing.Point(28, 94);
            this.chbxData.Name = "chbxData";
            this.chbxData.Size = new System.Drawing.Size(76, 24);
            this.chbxData.TabIndex = 5;
            this.chbxData.Text = "帧数据";
            this.chbxData.UseVisualStyleBackColor = true;
            // 
            // chbxType
            // 
            this.chbxType.AutoSize = true;
            this.chbxType.Location = new System.Drawing.Point(274, 64);
            this.chbxType.Name = "chbxType";
            this.chbxType.Size = new System.Drawing.Size(76, 24);
            this.chbxType.TabIndex = 4;
            this.chbxType.Text = "帧类型";
            this.chbxType.UseVisualStyleBackColor = true;
            // 
            // chbxFormat
            // 
            this.chbxFormat.AutoSize = true;
            this.chbxFormat.Location = new System.Drawing.Point(192, 64);
            this.chbxFormat.Name = "chbxFormat";
            this.chbxFormat.Size = new System.Drawing.Size(76, 24);
            this.chbxFormat.TabIndex = 3;
            this.chbxFormat.Text = "帧格式";
            this.chbxFormat.UseVisualStyleBackColor = true;
            // 
            // chbxID
            // 
            this.chbxID.AutoSize = true;
            this.chbxID.Location = new System.Drawing.Point(110, 64);
            this.chbxID.Name = "chbxID";
            this.chbxID.Size = new System.Drawing.Size(61, 24);
            this.chbxID.TabIndex = 2;
            this.chbxID.Text = "帧ID";
            this.chbxID.UseVisualStyleBackColor = true;
            // 
            // chbxName
            // 
            this.chbxName.AutoSize = true;
            this.chbxName.Location = new System.Drawing.Point(28, 64);
            this.chbxName.Name = "chbxName";
            this.chbxName.Size = new System.Drawing.Size(76, 24);
            this.chbxName.TabIndex = 1;
            this.chbxName.Text = "帧名称";
            this.chbxName.UseVisualStyleBackColor = true;
            // 
            // lbStatistical
            // 
            this.lbStatistical.AutoSize = true;
            this.lbStatistical.Location = new System.Drawing.Point(24, 32);
            this.lbStatistical.Name = "lbStatistical";
            this.lbStatistical.Size = new System.Drawing.Size(159, 20);
            this.lbStatistical.TabIndex = 0;
            this.lbStatistical.Text = "以下选择按与关系统计";
            // 
            // chbxSendFrame
            // 
            this.chbxSendFrame.AutoSize = true;
            this.chbxSendFrame.Location = new System.Drawing.Point(28, 209);
            this.chbxSendFrame.Name = "chbxSendFrame";
            this.chbxSendFrame.Size = new System.Drawing.Size(106, 24);
            this.chbxSendFrame.TabIndex = 6;
            this.chbxSendFrame.Text = "显示发送帧";
            this.chbxSendFrame.UseVisualStyleBackColor = true;
            // 
            // chbxErrorFrame
            // 
            this.chbxErrorFrame.AutoSize = true;
            this.chbxErrorFrame.Location = new System.Drawing.Point(28, 239);
            this.chbxErrorFrame.Name = "chbxErrorFrame";
            this.chbxErrorFrame.Size = new System.Drawing.Size(106, 24);
            this.chbxErrorFrame.TabIndex = 7;
            this.chbxErrorFrame.Text = "显示错误帧";
            this.chbxErrorFrame.UseVisualStyleBackColor = true;
            // 
            // chbxLocalTime
            // 
            this.chbxLocalTime.AutoSize = true;
            this.chbxLocalTime.Location = new System.Drawing.Point(187, 209);
            this.chbxLocalTime.Name = "chbxLocalTime";
            this.chbxLocalTime.Size = new System.Drawing.Size(136, 24);
            this.chbxLocalTime.TabIndex = 8;
            this.chbxLocalTime.Text = "显示帧本地时间";
            this.chbxLocalTime.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(225, 274);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 32);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(315, 274);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 32);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chbxInterval
            // 
            this.chbxInterval.AutoSize = true;
            this.chbxInterval.Location = new System.Drawing.Point(187, 239);
            this.chbxInterval.Name = "chbxInterval";
            this.chbxInterval.Size = new System.Drawing.Size(136, 24);
            this.chbxInterval.TabIndex = 11;
            this.chbxInterval.Text = "显示帧时间间隔";
            this.chbxInterval.UseVisualStyleBackColor = true;
            // 
            // DisplayConfigDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 313);
            this.Controls.Add(this.chbxInterval);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.chbxLocalTime);
            this.Controls.Add(this.chbxErrorFrame);
            this.Controls.Add(this.chbxSendFrame);
            this.Controls.Add(this.gbxStatistical);
            this.Controls.Add(this.rbStatistical);
            this.Controls.Add(this.rbRolling);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DisplayConfigDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "显示模式";
            this.Load += new System.EventHandler(this.DisplayConfigDialog_Load);
            this.gbxStatistical.ResumeLayout(false);
            this.gbxStatistical.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbRolling;
        private System.Windows.Forms.RadioButton rbStatistical;
        private System.Windows.Forms.GroupBox gbxStatistical;
        private System.Windows.Forms.Label lbStatistical;
        private System.Windows.Forms.CheckBox chbxName;
        private System.Windows.Forms.CheckBox chbxData;
        private System.Windows.Forms.CheckBox chbxType;
        private System.Windows.Forms.CheckBox chbxFormat;
        private System.Windows.Forms.CheckBox chbxID;
        private System.Windows.Forms.CheckBox chbxSendFrame;
        private System.Windows.Forms.CheckBox chbxErrorFrame;
        private System.Windows.Forms.CheckBox chbxLocalTime;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chbxInterval;
    }
}