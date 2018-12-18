using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CL_Main
{
    public partial class DisplayConfigDialog : Form
    {
        private DISPLAY_FRAME p_DisplayFrame;

        public DisplayConfigDialog(DISPLAY_FRAME pDisplayFrame)
        {
            InitializeComponent();
            this.p_DisplayFrame = pDisplayFrame;
        }

        public DISPLAY_FRAME DisplayFrame
        { get { return this.p_DisplayFrame; } }

        private void Init()
        {
            rbRolling.Checked = p_DisplayFrame.DisplayMode == DISPLAY_MODE.ROLLING ? true : false;
            chbxSendFrame.Checked = p_DisplayFrame.ShowSendFrame;
            chbxErrorFrame.Checked = p_DisplayFrame.ShowErrorFrame;
            chbxLocalTime.Checked = p_DisplayFrame.ShowLocalTime;
            chbxInterval.Checked = p_DisplayFrame.ShowFrameInterval;
        }

        private void DisplayConfigDialog_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            p_DisplayFrame.DisplayMode = DISPLAY_MODE.ROLLING;
            p_DisplayFrame.ShowSendFrame = chbxSendFrame.Checked;
            p_DisplayFrame.ShowErrorFrame = chbxErrorFrame.Checked;
            p_DisplayFrame.ShowLocalTime = chbxLocalTime.Checked;
            p_DisplayFrame.ShowFrameInterval = chbxInterval.Checked;
            this.DialogResult = DialogResult.OK;
        }
    }
}
