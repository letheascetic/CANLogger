namespace CL_Main
{
    partial class UCNormalSendMode
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
            this.lbSendMode = new System.Windows.Forms.Label();
            this.lbFrameType = new System.Windows.Forms.Label();
            this.lbFrameFormat = new System.Windows.Forms.Label();
            this.cbxSendMode = new System.Windows.Forms.ComboBox();
            this.cbxFrameType = new System.Windows.Forms.ComboBox();
            this.cbxFrameFormat = new System.Windows.Forms.ComboBox();
            this.pnl = new System.Windows.Forms.Panel();
            this.chbxIncData = new System.Windows.Forms.CheckBox();
            this.chbxIncID = new System.Windows.Forms.CheckBox();
            this.lbDesc = new System.Windows.Forms.Label();
            this.lbFrameID = new System.Windows.Forms.Label();
            this.lbSendNum = new System.Windows.Forms.Label();
            this.tbxFrameID = new System.Windows.Forms.TextBox();
            this.tbxSendNum = new System.Windows.Forms.TextBox();
            this.lbData = new System.Windows.Forms.Label();
            this.tbxFrameData = new System.Windows.Forms.TextBox();
            this.lbSendInterval = new System.Windows.Forms.Label();
            this.tbxSendInterval = new System.Windows.Forms.TextBox();
            this.lbSendIntervalDesc = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.pnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbSendMode
            // 
            this.lbSendMode.AutoSize = true;
            this.lbSendMode.Location = new System.Drawing.Point(4, 8);
            this.lbSendMode.Name = "lbSendMode";
            this.lbSendMode.Size = new System.Drawing.Size(73, 20);
            this.lbSendMode.TabIndex = 0;
            this.lbSendMode.Text = "发送方式:";
            // 
            // lbFrameType
            // 
            this.lbFrameType.AutoSize = true;
            this.lbFrameType.Location = new System.Drawing.Point(19, 41);
            this.lbFrameType.Name = "lbFrameType";
            this.lbFrameType.Size = new System.Drawing.Size(58, 20);
            this.lbFrameType.TabIndex = 1;
            this.lbFrameType.Text = "帧类型:";
            // 
            // lbFrameFormat
            // 
            this.lbFrameFormat.AutoSize = true;
            this.lbFrameFormat.Location = new System.Drawing.Point(19, 74);
            this.lbFrameFormat.Name = "lbFrameFormat";
            this.lbFrameFormat.Size = new System.Drawing.Size(58, 20);
            this.lbFrameFormat.TabIndex = 2;
            this.lbFrameFormat.Text = "帧格式:";
            // 
            // cbxSendMode
            // 
            this.cbxSendMode.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxSendMode.FormattingEnabled = true;
            this.cbxSendMode.Items.AddRange(new object[] {
            "正常发送",
            "单次发送"});
            this.cbxSendMode.Location = new System.Drawing.Point(83, 5);
            this.cbxSendMode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbxSendMode.Name = "cbxSendMode";
            this.cbxSendMode.Size = new System.Drawing.Size(103, 28);
            this.cbxSendMode.TabIndex = 3;
            // 
            // cbxFrameType
            // 
            this.cbxFrameType.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxFrameType.FormattingEnabled = true;
            this.cbxFrameType.Items.AddRange(new object[] {
            "数据帧"});
            this.cbxFrameType.Location = new System.Drawing.Point(83, 38);
            this.cbxFrameType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbxFrameType.Name = "cbxFrameType";
            this.cbxFrameType.Size = new System.Drawing.Size(103, 28);
            this.cbxFrameType.TabIndex = 4;
            // 
            // cbxFrameFormat
            // 
            this.cbxFrameFormat.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxFrameFormat.FormattingEnabled = true;
            this.cbxFrameFormat.Location = new System.Drawing.Point(83, 70);
            this.cbxFrameFormat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbxFrameFormat.Name = "cbxFrameFormat";
            this.cbxFrameFormat.Size = new System.Drawing.Size(103, 28);
            this.cbxFrameFormat.TabIndex = 5;
            // 
            // pnl
            // 
            this.pnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl.Controls.Add(this.chbxIncData);
            this.pnl.Controls.Add(this.chbxIncID);
            this.pnl.Controls.Add(this.lbDesc);
            this.pnl.Location = new System.Drawing.Point(248, 5);
            this.pnl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnl.Name = "pnl";
            this.pnl.Size = new System.Drawing.Size(545, 30);
            this.pnl.TabIndex = 6;
            // 
            // chbxIncData
            // 
            this.chbxIncData.AutoSize = true;
            this.chbxIncData.Location = new System.Drawing.Point(309, 3);
            this.chbxIncData.Name = "chbxIncData";
            this.chbxIncData.Size = new System.Drawing.Size(196, 24);
            this.chbxIncData.TabIndex = 9;
            this.chbxIncData.Text = "发送数据每发送一帧递增";
            this.chbxIncData.UseVisualStyleBackColor = true;
            // 
            // chbxIncID
            // 
            this.chbxIncID.AutoSize = true;
            this.chbxIncID.Location = new System.Drawing.Point(121, 3);
            this.chbxIncID.Name = "chbxIncID";
            this.chbxIncID.Size = new System.Drawing.Size(166, 24);
            this.chbxIncID.TabIndex = 8;
            this.chbxIncID.Text = "帧ID每发送一帧递增";
            this.chbxIncID.UseVisualStyleBackColor = true;
            // 
            // lbDesc
            // 
            this.lbDesc.AutoSize = true;
            this.lbDesc.Location = new System.Drawing.Point(16, 3);
            this.lbDesc.Name = "lbDesc";
            this.lbDesc.Size = new System.Drawing.Size(99, 20);
            this.lbDesc.TabIndex = 7;
            this.lbDesc.Text = "多次发送时：";
            // 
            // lbFrameID
            // 
            this.lbFrameID.AutoSize = true;
            this.lbFrameID.Location = new System.Drawing.Point(230, 44);
            this.lbFrameID.Name = "lbFrameID";
            this.lbFrameID.Size = new System.Drawing.Size(83, 20);
            this.lbFrameID.TabIndex = 7;
            this.lbFrameID.Text = "帧ID(HEX):";
            // 
            // lbSendNum
            // 
            this.lbSendNum.AutoSize = true;
            this.lbSendNum.Location = new System.Drawing.Point(240, 73);
            this.lbSendNum.Name = "lbSendNum";
            this.lbSendNum.Size = new System.Drawing.Size(73, 20);
            this.lbSendNum.TabIndex = 8;
            this.lbSendNum.Text = "发送次数:";
            // 
            // tbxFrameID
            // 
            this.tbxFrameID.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxFrameID.Location = new System.Drawing.Point(319, 39);
            this.tbxFrameID.MaxLength = 8;
            this.tbxFrameID.Name = "tbxFrameID";
            this.tbxFrameID.Size = new System.Drawing.Size(93, 27);
            this.tbxFrameID.TabIndex = 9;
            this.tbxFrameID.Text = "00000000";
            this.tbxFrameID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxFrameID_KeyPress);
            // 
            // tbxSendNum
            // 
            this.tbxSendNum.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxSendNum.Location = new System.Drawing.Point(319, 70);
            this.tbxSendNum.MaxLength = 9;
            this.tbxSendNum.Name = "tbxSendNum";
            this.tbxSendNum.Size = new System.Drawing.Size(93, 27);
            this.tbxSendNum.TabIndex = 10;
            this.tbxSendNum.Text = "1";
            this.tbxSendNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxSendNum_KeyPress);
            // 
            // lbData
            // 
            this.lbData.AutoSize = true;
            this.lbData.Location = new System.Drawing.Point(501, 44);
            this.lbData.Name = "lbData";
            this.lbData.Size = new System.Drawing.Size(83, 20);
            this.lbData.TabIndex = 11;
            this.lbData.Text = "数据(HEX):";
            // 
            // tbxFrameData
            // 
            this.tbxFrameData.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxFrameData.Location = new System.Drawing.Point(590, 38);
            this.tbxFrameData.Name = "tbxFrameData";
            this.tbxFrameData.Size = new System.Drawing.Size(203, 27);
            this.tbxFrameData.TabIndex = 12;
            this.tbxFrameData.Text = "00 01 02 03 04 05 06 07";
            this.tbxFrameData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxFrameData_KeyPress);
            // 
            // lbSendInterval
            // 
            this.lbSendInterval.AutoSize = true;
            this.lbSendInterval.Location = new System.Drawing.Point(480, 73);
            this.lbSendInterval.Name = "lbSendInterval";
            this.lbSendInterval.Size = new System.Drawing.Size(104, 20);
            this.lbSendInterval.TabIndex = 13;
            this.lbSendInterval.Text = "发送间隔(ms):";
            // 
            // tbxSendInterval
            // 
            this.tbxSendInterval.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxSendInterval.Location = new System.Drawing.Point(590, 71);
            this.tbxSendInterval.MaxLength = 10;
            this.tbxSendInterval.Name = "tbxSendInterval";
            this.tbxSendInterval.Size = new System.Drawing.Size(93, 27);
            this.tbxSendInterval.TabIndex = 14;
            this.tbxSendInterval.Text = "100";
            this.tbxSendInterval.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxSendInterval_KeyPress);
            // 
            // lbSendIntervalDesc
            // 
            this.lbSendIntervalDesc.AutoSize = true;
            this.lbSendIntervalDesc.Font = new System.Drawing.Font("微软雅黑", 6.6F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbSendIntervalDesc.Location = new System.Drawing.Point(685, 77);
            this.lbSendIntervalDesc.Name = "lbSendIntervalDesc";
            this.lbSendIntervalDesc.Size = new System.Drawing.Size(112, 16);
            this.lbSendIntervalDesc.TabIndex = 15;
            this.lbSendIntervalDesc.Text = "(发送最小间隔0.1ms)";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(888, 31);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(90, 30);
            this.btnSend.TabIndex = 17;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(888, 66);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(90, 30);
            this.btnStop.TabIndex = 18;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // UCNormalSendMode
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.lbSendIntervalDesc);
            this.Controls.Add(this.tbxSendInterval);
            this.Controls.Add(this.lbSendInterval);
            this.Controls.Add(this.tbxFrameData);
            this.Controls.Add(this.lbData);
            this.Controls.Add(this.tbxSendNum);
            this.Controls.Add(this.tbxFrameID);
            this.Controls.Add(this.lbSendNum);
            this.Controls.Add(this.lbFrameID);
            this.Controls.Add(this.pnl);
            this.Controls.Add(this.cbxFrameFormat);
            this.Controls.Add(this.cbxFrameType);
            this.Controls.Add(this.cbxSendMode);
            this.Controls.Add(this.lbFrameFormat);
            this.Controls.Add(this.lbFrameType);
            this.Controls.Add(this.lbSendMode);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UCNormalSendMode";
            this.Size = new System.Drawing.Size(985, 103);
            this.Load += new System.EventHandler(this.UCNormalSendMode_Load);
            this.pnl.ResumeLayout(false);
            this.pnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbSendMode;
        private System.Windows.Forms.Label lbFrameType;
        private System.Windows.Forms.Label lbFrameFormat;
        private System.Windows.Forms.ComboBox cbxSendMode;
        private System.Windows.Forms.ComboBox cbxFrameType;
        private System.Windows.Forms.ComboBox cbxFrameFormat;
        private System.Windows.Forms.Panel pnl;
        private System.Windows.Forms.Label lbDesc;
        private System.Windows.Forms.CheckBox chbxIncID;
        private System.Windows.Forms.CheckBox chbxIncData;
        private System.Windows.Forms.Label lbFrameID;
        private System.Windows.Forms.Label lbSendNum;
        private System.Windows.Forms.TextBox tbxFrameID;
        private System.Windows.Forms.TextBox tbxSendNum;
        private System.Windows.Forms.Label lbData;
        private System.Windows.Forms.TextBox tbxFrameData;
        private System.Windows.Forms.Label lbSendInterval;
        private System.Windows.Forms.TextBox tbxSendInterval;
        private System.Windows.Forms.Label lbSendIntervalDesc;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnStop;
    }
}
