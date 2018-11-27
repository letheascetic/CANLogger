namespace CL_Main
{
    partial class UCStatus
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
            this.gbxControlStatus = new System.Windows.Forms.GroupBox();
            this.lbBusArbErr = new System.Windows.Forms.Label();
            this.lbBusDataErr = new System.Windows.Forms.Label();
            this.lbBufOV = new System.Windows.Forms.Label();
            this.lbErrWarn = new System.Windows.Forms.Label();
            this.lbSending = new System.Windows.Forms.Label();
            this.lbSendEmpty = new System.Windows.Forms.Label();
            this.lbReceiving = new System.Windows.Forms.Label();
            this.lbSendFinished = new System.Windows.Forms.Label();
            this.lbRcvOV = new System.Windows.Forms.Label();
            this.lbRcvFull = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.osBusDataErr = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.osBusArbErr = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.osSending = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.osErrWarn = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.osBufOV = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.osReceiving = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.osSendFinished = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.osSendEmpty = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.osRcvOV = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.osRcvFull = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.gbxBusStatus = new System.Windows.Forms.GroupBox();
            this.lbBusOff = new System.Windows.Forms.Label();
            this.lbActiveErr = new System.Windows.Forms.Label();
            this.lbPassiveErr = new System.Windows.Forms.Label();
            this.lbBusNormal = new System.Windows.Forms.Label();
            this.shapeContainer2 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.osActiveErr = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.osPassiveErr = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.osBusNormal = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.osBusOff = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.gbxBusErr = new System.Windows.Forms.GroupBox();
            this.lbSendErrNum = new System.Windows.Forms.Label();
            this.lbRcvErrNum = new System.Windows.Forms.Label();
            this.lbSendErr = new System.Windows.Forms.Label();
            this.lbRcvErr = new System.Windows.Forms.Label();
            this.gbxControlStatus.SuspendLayout();
            this.gbxBusStatus.SuspendLayout();
            this.gbxBusErr.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxControlStatus
            // 
            this.gbxControlStatus.Controls.Add(this.lbBusArbErr);
            this.gbxControlStatus.Controls.Add(this.lbBusDataErr);
            this.gbxControlStatus.Controls.Add(this.lbBufOV);
            this.gbxControlStatus.Controls.Add(this.lbErrWarn);
            this.gbxControlStatus.Controls.Add(this.lbSending);
            this.gbxControlStatus.Controls.Add(this.lbSendEmpty);
            this.gbxControlStatus.Controls.Add(this.lbReceiving);
            this.gbxControlStatus.Controls.Add(this.lbSendFinished);
            this.gbxControlStatus.Controls.Add(this.lbRcvOV);
            this.gbxControlStatus.Controls.Add(this.lbRcvFull);
            this.gbxControlStatus.Controls.Add(this.shapeContainer1);
            this.gbxControlStatus.Location = new System.Drawing.Point(2, 4);
            this.gbxControlStatus.Name = "gbxControlStatus";
            this.gbxControlStatus.Size = new System.Drawing.Size(247, 130);
            this.gbxControlStatus.TabIndex = 0;
            this.gbxControlStatus.TabStop = false;
            this.gbxControlStatus.Text = "控制状态";
            // 
            // lbBusArbErr
            // 
            this.lbBusArbErr.AutoSize = true;
            this.lbBusArbErr.Location = new System.Drawing.Point(145, 102);
            this.lbBusArbErr.Name = "lbBusArbErr";
            this.lbBusArbErr.Size = new System.Drawing.Size(99, 20);
            this.lbBusArbErr.TabIndex = 9;
            this.lbBusArbErr.Text = "总线仲裁错误";
            // 
            // lbBusDataErr
            // 
            this.lbBusDataErr.AutoSize = true;
            this.lbBusDataErr.Location = new System.Drawing.Point(145, 83);
            this.lbBusDataErr.Name = "lbBusDataErr";
            this.lbBusDataErr.Size = new System.Drawing.Size(99, 20);
            this.lbBusDataErr.TabIndex = 8;
            this.lbBusDataErr.Text = "总线数据错误";
            // 
            // lbBufOV
            // 
            this.lbBufOV.AutoSize = true;
            this.lbBufOV.Location = new System.Drawing.Point(145, 63);
            this.lbBufOV.Name = "lbBufOV";
            this.lbBufOV.Size = new System.Drawing.Size(84, 20);
            this.lbBufOV.TabIndex = 7;
            this.lbBufOV.Text = "缓存区溢出";
            // 
            // lbErrWarn
            // 
            this.lbErrWarn.AutoSize = true;
            this.lbErrWarn.Location = new System.Drawing.Point(145, 42);
            this.lbErrWarn.Name = "lbErrWarn";
            this.lbErrWarn.Size = new System.Drawing.Size(69, 20);
            this.lbErrWarn.TabIndex = 6;
            this.lbErrWarn.Text = "错误报警";
            // 
            // lbSending
            // 
            this.lbSending.AutoSize = true;
            this.lbSending.Location = new System.Drawing.Point(145, 23);
            this.lbSending.Name = "lbSending";
            this.lbSending.Size = new System.Drawing.Size(69, 20);
            this.lbSending.TabIndex = 5;
            this.lbSending.Text = "正在发送";
            // 
            // lbSendEmpty
            // 
            this.lbSendEmpty.AutoSize = true;
            this.lbSendEmpty.Location = new System.Drawing.Point(20, 63);
            this.lbSendEmpty.Name = "lbSendEmpty";
            this.lbSendEmpty.Size = new System.Drawing.Size(99, 20);
            this.lbSendEmpty.TabIndex = 2;
            this.lbSendEmpty.Text = "发送寄存器空";
            // 
            // lbReceiving
            // 
            this.lbReceiving.AutoSize = true;
            this.lbReceiving.Location = new System.Drawing.Point(20, 102);
            this.lbReceiving.Name = "lbReceiving";
            this.lbReceiving.Size = new System.Drawing.Size(69, 20);
            this.lbReceiving.TabIndex = 4;
            this.lbReceiving.Text = "正在接收";
            // 
            // lbSendFinished
            // 
            this.lbSendFinished.AutoSize = true;
            this.lbSendFinished.Location = new System.Drawing.Point(20, 83);
            this.lbSendFinished.Name = "lbSendFinished";
            this.lbSendFinished.Size = new System.Drawing.Size(69, 20);
            this.lbSendFinished.TabIndex = 3;
            this.lbSendFinished.Text = "发送结束";
            // 
            // lbRcvOV
            // 
            this.lbRcvOV.AutoSize = true;
            this.lbRcvOV.Location = new System.Drawing.Point(20, 42);
            this.lbRcvOV.Name = "lbRcvOV";
            this.lbRcvOV.Size = new System.Drawing.Size(99, 20);
            this.lbRcvOV.TabIndex = 1;
            this.lbRcvOV.Text = "接收寄存器溢";
            // 
            // lbRcvFull
            // 
            this.lbRcvFull.AutoSize = true;
            this.lbRcvFull.Location = new System.Drawing.Point(20, 20);
            this.lbRcvFull.Name = "lbRcvFull";
            this.lbRcvFull.Size = new System.Drawing.Size(99, 20);
            this.lbRcvFull.TabIndex = 0;
            this.lbRcvFull.Text = "接收寄存器满";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(3, 23);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.osBusDataErr,
            this.osBusArbErr,
            this.osSending,
            this.osErrWarn,
            this.osBufOV,
            this.osReceiving,
            this.osSendFinished,
            this.osSendEmpty,
            this.osRcvOV,
            this.osRcvFull});
            this.shapeContainer1.Size = new System.Drawing.Size(241, 104);
            this.shapeContainer1.TabIndex = 0;
            this.shapeContainer1.TabStop = false;
            // 
            // osBusDataErr
            // 
            this.osBusDataErr.BackColor = System.Drawing.Color.Gray;
            this.osBusDataErr.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.osBusDataErr.Location = new System.Drawing.Point(130, 65);
            this.osBusDataErr.Name = "osBusDataErr";
            this.osBusDataErr.Size = new System.Drawing.Size(10, 10);
            // 
            // osBusArbErr
            // 
            this.osBusArbErr.BackColor = System.Drawing.Color.Gray;
            this.osBusArbErr.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.osBusArbErr.Location = new System.Drawing.Point(130, 85);
            this.osBusArbErr.Name = "osBusArbErr";
            this.osBusArbErr.Size = new System.Drawing.Size(10, 10);
            // 
            // osSending
            // 
            this.osSending.BackColor = System.Drawing.Color.Gray;
            this.osSending.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.osSending.Location = new System.Drawing.Point(130, 5);
            this.osSending.Name = "osSending";
            this.osSending.Size = new System.Drawing.Size(10, 10);
            // 
            // osErrWarn
            // 
            this.osErrWarn.BackColor = System.Drawing.Color.Gray;
            this.osErrWarn.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.osErrWarn.Location = new System.Drawing.Point(130, 25);
            this.osErrWarn.Name = "osErrWarn";
            this.osErrWarn.Size = new System.Drawing.Size(10, 10);
            // 
            // osBufOV
            // 
            this.osBufOV.BackColor = System.Drawing.Color.Gray;
            this.osBufOV.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.osBufOV.Location = new System.Drawing.Point(130, 45);
            this.osBufOV.Name = "osBufOV";
            this.osBufOV.Size = new System.Drawing.Size(10, 10);
            // 
            // osReceiving
            // 
            this.osReceiving.BackColor = System.Drawing.Color.Gray;
            this.osReceiving.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.osReceiving.Location = new System.Drawing.Point(5, 85);
            this.osReceiving.Name = "osReceiving";
            this.osReceiving.Size = new System.Drawing.Size(10, 10);
            // 
            // osSendFinished
            // 
            this.osSendFinished.BackColor = System.Drawing.Color.Gray;
            this.osSendFinished.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.osSendFinished.Location = new System.Drawing.Point(5, 65);
            this.osSendFinished.Name = "osSendFinished";
            this.osSendFinished.Size = new System.Drawing.Size(10, 10);
            // 
            // osSendEmpty
            // 
            this.osSendEmpty.BackColor = System.Drawing.Color.Gray;
            this.osSendEmpty.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.osSendEmpty.Location = new System.Drawing.Point(5, 45);
            this.osSendEmpty.Name = "osSendEmpty";
            this.osSendEmpty.Size = new System.Drawing.Size(10, 10);
            // 
            // osRcvOV
            // 
            this.osRcvOV.BackColor = System.Drawing.Color.Gray;
            this.osRcvOV.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.osRcvOV.Location = new System.Drawing.Point(5, 25);
            this.osRcvOV.Name = "osRcvOV";
            this.osRcvOV.Size = new System.Drawing.Size(10, 10);
            // 
            // osRcvFull
            // 
            this.osRcvFull.BackColor = System.Drawing.Color.Gray;
            this.osRcvFull.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.osRcvFull.Location = new System.Drawing.Point(5, 5);
            this.osRcvFull.Name = "osRcvFull";
            this.osRcvFull.Size = new System.Drawing.Size(10, 10);
            // 
            // gbxBusStatus
            // 
            this.gbxBusStatus.Controls.Add(this.lbBusOff);
            this.gbxBusStatus.Controls.Add(this.lbActiveErr);
            this.gbxBusStatus.Controls.Add(this.lbPassiveErr);
            this.gbxBusStatus.Controls.Add(this.lbBusNormal);
            this.gbxBusStatus.Controls.Add(this.shapeContainer2);
            this.gbxBusStatus.Location = new System.Drawing.Point(252, 3);
            this.gbxBusStatus.Name = "gbxBusStatus";
            this.gbxBusStatus.Size = new System.Drawing.Size(95, 131);
            this.gbxBusStatus.TabIndex = 1;
            this.gbxBusStatus.TabStop = false;
            this.gbxBusStatus.Text = "总线状态";
            // 
            // lbBusOff
            // 
            this.lbBusOff.AutoSize = true;
            this.lbBusOff.Location = new System.Drawing.Point(20, 83);
            this.lbBusOff.Name = "lbBusOff";
            this.lbBusOff.Size = new System.Drawing.Size(69, 20);
            this.lbBusOff.TabIndex = 13;
            this.lbBusOff.Text = "总线关闭";
            // 
            // lbActiveErr
            // 
            this.lbActiveErr.AutoSize = true;
            this.lbActiveErr.Location = new System.Drawing.Point(20, 63);
            this.lbActiveErr.Name = "lbActiveErr";
            this.lbActiveErr.Size = new System.Drawing.Size(69, 20);
            this.lbActiveErr.TabIndex = 12;
            this.lbActiveErr.Text = "主动错误";
            // 
            // lbPassiveErr
            // 
            this.lbPassiveErr.AutoSize = true;
            this.lbPassiveErr.Location = new System.Drawing.Point(20, 42);
            this.lbPassiveErr.Name = "lbPassiveErr";
            this.lbPassiveErr.Size = new System.Drawing.Size(69, 20);
            this.lbPassiveErr.TabIndex = 11;
            this.lbPassiveErr.Text = "被动错误";
            // 
            // lbBusNormal
            // 
            this.lbBusNormal.AutoSize = true;
            this.lbBusNormal.Location = new System.Drawing.Point(20, 23);
            this.lbBusNormal.Name = "lbBusNormal";
            this.lbBusNormal.Size = new System.Drawing.Size(69, 20);
            this.lbBusNormal.TabIndex = 10;
            this.lbBusNormal.Text = "总线正常";
            // 
            // shapeContainer2
            // 
            this.shapeContainer2.Location = new System.Drawing.Point(3, 23);
            this.shapeContainer2.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer2.Name = "shapeContainer2";
            this.shapeContainer2.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.osActiveErr,
            this.osPassiveErr,
            this.osBusNormal,
            this.osBusOff});
            this.shapeContainer2.Size = new System.Drawing.Size(89, 105);
            this.shapeContainer2.TabIndex = 0;
            this.shapeContainer2.TabStop = false;
            // 
            // osActiveErr
            // 
            this.osActiveErr.BackColor = System.Drawing.Color.Gray;
            this.osActiveErr.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.osActiveErr.Location = new System.Drawing.Point(5, 45);
            this.osActiveErr.Name = "osActiveErr";
            this.osActiveErr.Size = new System.Drawing.Size(10, 10);
            // 
            // osPassiveErr
            // 
            this.osPassiveErr.BackColor = System.Drawing.Color.Gray;
            this.osPassiveErr.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.osPassiveErr.Location = new System.Drawing.Point(5, 25);
            this.osPassiveErr.Name = "osPassiveErr";
            this.osPassiveErr.Size = new System.Drawing.Size(10, 10);
            // 
            // osBusNormal
            // 
            this.osBusNormal.BackColor = System.Drawing.Color.Gray;
            this.osBusNormal.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.osBusNormal.Location = new System.Drawing.Point(5, 5);
            this.osBusNormal.Name = "osBusNormal";
            this.osBusNormal.Size = new System.Drawing.Size(10, 10);
            // 
            // osBusOff
            // 
            this.osBusOff.BackColor = System.Drawing.Color.Gray;
            this.osBusOff.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.osBusOff.Location = new System.Drawing.Point(5, 65);
            this.osBusOff.Name = "osBusOff";
            this.osBusOff.Size = new System.Drawing.Size(10, 10);
            // 
            // gbxBusErr
            // 
            this.gbxBusErr.Controls.Add(this.lbSendErrNum);
            this.gbxBusErr.Controls.Add(this.lbRcvErrNum);
            this.gbxBusErr.Controls.Add(this.lbSendErr);
            this.gbxBusErr.Controls.Add(this.lbRcvErr);
            this.gbxBusErr.Location = new System.Drawing.Point(350, 3);
            this.gbxBusErr.Name = "gbxBusErr";
            this.gbxBusErr.Size = new System.Drawing.Size(117, 131);
            this.gbxBusErr.TabIndex = 2;
            this.gbxBusErr.TabStop = false;
            this.gbxBusErr.Text = "总线错误计数";
            // 
            // lbSendErrNum
            // 
            this.lbSendErrNum.AutoSize = true;
            this.lbSendErrNum.Location = new System.Drawing.Point(77, 60);
            this.lbSendErrNum.Name = "lbSendErrNum";
            this.lbSendErrNum.Size = new System.Drawing.Size(18, 20);
            this.lbSendErrNum.TabIndex = 17;
            this.lbSendErrNum.Text = "0";
            // 
            // lbRcvErrNum
            // 
            this.lbRcvErrNum.AutoSize = true;
            this.lbRcvErrNum.Location = new System.Drawing.Point(77, 32);
            this.lbRcvErrNum.Name = "lbRcvErrNum";
            this.lbRcvErrNum.Size = new System.Drawing.Size(18, 20);
            this.lbRcvErrNum.TabIndex = 16;
            this.lbRcvErrNum.Text = "0";
            // 
            // lbSendErr
            // 
            this.lbSendErr.AutoSize = true;
            this.lbSendErr.Location = new System.Drawing.Point(6, 59);
            this.lbSendErr.Name = "lbSendErr";
            this.lbSendErr.Size = new System.Drawing.Size(73, 20);
            this.lbSendErr.TabIndex = 15;
            this.lbSendErr.Text = "发送错误:";
            // 
            // lbRcvErr
            // 
            this.lbRcvErr.AutoSize = true;
            this.lbRcvErr.Location = new System.Drawing.Point(6, 32);
            this.lbRcvErr.Name = "lbRcvErr";
            this.lbRcvErr.Size = new System.Drawing.Size(73, 20);
            this.lbRcvErr.TabIndex = 14;
            this.lbRcvErr.Text = "接收错误:";
            // 
            // UCStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.gbxBusErr);
            this.Controls.Add(this.gbxBusStatus);
            this.Controls.Add(this.gbxControlStatus);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UCStatus";
            this.Size = new System.Drawing.Size(470, 137);
            this.gbxControlStatus.ResumeLayout(false);
            this.gbxControlStatus.PerformLayout();
            this.gbxBusStatus.ResumeLayout(false);
            this.gbxBusStatus.PerformLayout();
            this.gbxBusErr.ResumeLayout(false);
            this.gbxBusErr.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxControlStatus;
        private System.Windows.Forms.GroupBox gbxBusStatus;
        private System.Windows.Forms.GroupBox gbxBusErr;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.OvalShape osRcvFull;
        private System.Windows.Forms.Label lbRcvFull;
        private System.Windows.Forms.Label lbReceiving;
        private System.Windows.Forms.Label lbSendFinished;
        private System.Windows.Forms.Label lbSendEmpty;
        private System.Windows.Forms.Label lbRcvOV;
        private Microsoft.VisualBasic.PowerPacks.OvalShape osReceiving;
        private Microsoft.VisualBasic.PowerPacks.OvalShape osSendFinished;
        private Microsoft.VisualBasic.PowerPacks.OvalShape osSendEmpty;
        private Microsoft.VisualBasic.PowerPacks.OvalShape osRcvOV;
        private Microsoft.VisualBasic.PowerPacks.OvalShape osBusDataErr;
        private Microsoft.VisualBasic.PowerPacks.OvalShape osBusArbErr;
        private Microsoft.VisualBasic.PowerPacks.OvalShape osSending;
        private Microsoft.VisualBasic.PowerPacks.OvalShape osErrWarn;
        private Microsoft.VisualBasic.PowerPacks.OvalShape osBufOV;
        private System.Windows.Forms.Label lbSending;
        private System.Windows.Forms.Label lbBusArbErr;
        private System.Windows.Forms.Label lbBusDataErr;
        private System.Windows.Forms.Label lbBufOV;
        private System.Windows.Forms.Label lbErrWarn;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer2;
        private Microsoft.VisualBasic.PowerPacks.OvalShape osActiveErr;
        private Microsoft.VisualBasic.PowerPacks.OvalShape osPassiveErr;
        private Microsoft.VisualBasic.PowerPacks.OvalShape osBusNormal;
        private Microsoft.VisualBasic.PowerPacks.OvalShape osBusOff;
        private System.Windows.Forms.Label lbBusNormal;
        private System.Windows.Forms.Label lbPassiveErr;
        private System.Windows.Forms.Label lbBusOff;
        private System.Windows.Forms.Label lbActiveErr;
        private System.Windows.Forms.Label lbSendErr;
        private System.Windows.Forms.Label lbRcvErr;
        private System.Windows.Forms.Label lbSendErrNum;
        private System.Windows.Forms.Label lbRcvErrNum;
    }
}