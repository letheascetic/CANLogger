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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.pnl = new System.Windows.Forms.Panel();
            this.chbxIncData = new System.Windows.Forms.CheckBox();
            this.chbxIncID = new System.Windows.Forms.CheckBox();
            this.lbDesc = new System.Windows.Forms.Label();
            this.lbFrameID = new System.Windows.Forms.Label();
            this.lbSendNum = new System.Windows.Forms.Label();
            this.tbxFrameID = new System.Windows.Forms.TextBox();
            this.tbxSendNum = new System.Windows.Forms.TextBox();
            this.lbData = new System.Windows.Forms.Label();
            this.tbxData = new System.Windows.Forms.TextBox();
            this.lbSendInterval = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbDesc2 = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.pnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbSendMode
            // 
            this.lbSendMode.AutoSize = true;
            this.lbSendMode.Location = new System.Drawing.Point(19, 7);
            this.lbSendMode.Name = "lbSendMode";
            this.lbSendMode.Size = new System.Drawing.Size(84, 20);
            this.lbSendMode.TabIndex = 0;
            this.lbSendMode.Text = "发送方式：";
            // 
            // lbFrameType
            // 
            this.lbFrameType.AutoSize = true;
            this.lbFrameType.Location = new System.Drawing.Point(19, 47);
            this.lbFrameType.Name = "lbFrameType";
            this.lbFrameType.Size = new System.Drawing.Size(69, 20);
            this.lbFrameType.TabIndex = 1;
            this.lbFrameType.Text = "帧类型：";
            // 
            // lbFrameFormat
            // 
            this.lbFrameFormat.AutoSize = true;
            this.lbFrameFormat.Location = new System.Drawing.Point(19, 87);
            this.lbFrameFormat.Name = "lbFrameFormat";
            this.lbFrameFormat.Size = new System.Drawing.Size(69, 20);
            this.lbFrameFormat.TabIndex = 2;
            this.lbFrameFormat.Text = "帧格式：";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("微软雅黑", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(109, 4);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(103, 27);
            this.comboBox1.TabIndex = 3;
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("微软雅黑", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(109, 44);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(103, 27);
            this.comboBox2.TabIndex = 4;
            // 
            // comboBox3
            // 
            this.comboBox3.Font = new System.Drawing.Font("微软雅黑", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(109, 83);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(103, 27);
            this.comboBox3.TabIndex = 5;
            // 
            // pnl
            // 
            this.pnl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl.Controls.Add(this.chbxIncData);
            this.pnl.Controls.Add(this.chbxIncID);
            this.pnl.Controls.Add(this.lbDesc);
            this.pnl.Location = new System.Drawing.Point(234, 4);
            this.pnl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnl.Name = "pnl";
            this.pnl.Size = new System.Drawing.Size(545, 36);
            this.pnl.TabIndex = 6;
            // 
            // chbxIncData
            // 
            this.chbxIncData.AutoSize = true;
            this.chbxIncData.Location = new System.Drawing.Point(311, 11);
            this.chbxIncData.Name = "chbxIncData";
            this.chbxIncData.Size = new System.Drawing.Size(196, 24);
            this.chbxIncData.TabIndex = 9;
            this.chbxIncData.Text = "发送数据每发送一帧递增";
            this.chbxIncData.UseVisualStyleBackColor = true;
            // 
            // chbxIncID
            // 
            this.chbxIncID.AutoSize = true;
            this.chbxIncID.Location = new System.Drawing.Point(121, 11);
            this.chbxIncID.Name = "chbxIncID";
            this.chbxIncID.Size = new System.Drawing.Size(166, 24);
            this.chbxIncID.TabIndex = 8;
            this.chbxIncID.Text = "帧ID每发送一帧递增";
            this.chbxIncID.UseVisualStyleBackColor = true;
            // 
            // lbDesc
            // 
            this.lbDesc.AutoSize = true;
            this.lbDesc.Location = new System.Drawing.Point(16, 12);
            this.lbDesc.Name = "lbDesc";
            this.lbDesc.Size = new System.Drawing.Size(99, 20);
            this.lbDesc.TabIndex = 7;
            this.lbDesc.Text = "多次发送时：";
            // 
            // lbFrameID
            // 
            this.lbFrameID.AutoSize = true;
            this.lbFrameID.Location = new System.Drawing.Point(229, 53);
            this.lbFrameID.Name = "lbFrameID";
            this.lbFrameID.Size = new System.Drawing.Size(94, 20);
            this.lbFrameID.TabIndex = 7;
            this.lbFrameID.Text = "帧ID(HEX)：";
            // 
            // lbSendNum
            // 
            this.lbSendNum.AutoSize = true;
            this.lbSendNum.Location = new System.Drawing.Point(229, 88);
            this.lbSendNum.Name = "lbSendNum";
            this.lbSendNum.Size = new System.Drawing.Size(84, 20);
            this.lbSendNum.TabIndex = 8;
            this.lbSendNum.Text = "发送次数：";
            // 
            // tbxFrameID
            // 
            this.tbxFrameID.Font = new System.Drawing.Font("微软雅黑", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxFrameID.Location = new System.Drawing.Point(329, 48);
            this.tbxFrameID.Name = "tbxFrameID";
            this.tbxFrameID.Size = new System.Drawing.Size(139, 25);
            this.tbxFrameID.TabIndex = 9;
            // 
            // tbxSendNum
            // 
            this.tbxSendNum.Font = new System.Drawing.Font("微软雅黑", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxSendNum.Location = new System.Drawing.Point(329, 81);
            this.tbxSendNum.Name = "tbxSendNum";
            this.tbxSendNum.Size = new System.Drawing.Size(89, 25);
            this.tbxSendNum.TabIndex = 10;
            // 
            // lbData
            // 
            this.lbData.AutoSize = true;
            this.lbData.Location = new System.Drawing.Point(491, 51);
            this.lbData.Name = "lbData";
            this.lbData.Size = new System.Drawing.Size(94, 20);
            this.lbData.TabIndex = 11;
            this.lbData.Text = "数据(HEX)：";
            // 
            // tbxData
            // 
            this.tbxData.Font = new System.Drawing.Font("微软雅黑", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxData.Location = new System.Drawing.Point(591, 48);
            this.tbxData.Name = "tbxData";
            this.tbxData.Size = new System.Drawing.Size(203, 25);
            this.tbxData.TabIndex = 12;
            // 
            // lbSendInterval
            // 
            this.lbSendInterval.AutoSize = true;
            this.lbSendInterval.Location = new System.Drawing.Point(470, 88);
            this.lbSendInterval.Name = "lbSendInterval";
            this.lbSendInterval.Size = new System.Drawing.Size(115, 20);
            this.lbSendInterval.TabIndex = 13;
            this.lbSendInterval.Text = "发送间隔(ms)：";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("微软雅黑", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(591, 81);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(89, 25);
            this.textBox1.TabIndex = 14;
            // 
            // lbDesc2
            // 
            this.lbDesc2.AutoSize = true;
            this.lbDesc2.Font = new System.Drawing.Font("微软雅黑", 6.6F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDesc2.Location = new System.Drawing.Point(695, 87);
            this.lbDesc2.Name = "lbDesc2";
            this.lbDesc2.Size = new System.Drawing.Size(112, 16);
            this.lbDesc2.TabIndex = 15;
            this.lbDesc2.Text = "(发送最小间隔0.1ms)";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(823, 37);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(90, 30);
            this.btnSend.TabIndex = 17;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(823, 77);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(90, 30);
            this.btnStop.TabIndex = 18;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            // 
            // UCNormalSendMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.lbDesc2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lbSendInterval);
            this.Controls.Add(this.tbxData);
            this.Controls.Add(this.lbData);
            this.Controls.Add(this.tbxSendNum);
            this.Controls.Add(this.tbxFrameID);
            this.Controls.Add(this.lbSendNum);
            this.Controls.Add(this.lbFrameID);
            this.Controls.Add(this.pnl);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lbFrameFormat);
            this.Controls.Add(this.lbFrameType);
            this.Controls.Add(this.lbSendMode);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UCNormalSendMode";
            this.Size = new System.Drawing.Size(924, 120);
            this.pnl.ResumeLayout(false);
            this.pnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbSendMode;
        private System.Windows.Forms.Label lbFrameType;
        private System.Windows.Forms.Label lbFrameFormat;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Panel pnl;
        private System.Windows.Forms.Label lbDesc;
        private System.Windows.Forms.CheckBox chbxIncID;
        private System.Windows.Forms.CheckBox chbxIncData;
        private System.Windows.Forms.Label lbFrameID;
        private System.Windows.Forms.Label lbSendNum;
        private System.Windows.Forms.TextBox tbxFrameID;
        private System.Windows.Forms.TextBox tbxSendNum;
        private System.Windows.Forms.Label lbData;
        private System.Windows.Forms.TextBox tbxData;
        private System.Windows.Forms.Label lbSendInterval;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lbDesc2;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnStop;
    }
}
