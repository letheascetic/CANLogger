using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CL_Framework;

namespace CL_Main
{
    public partial class UCNormalSendMode : UserControl
    {
        private Channel channel;

        #region public apis

        public UCNormalSendMode(Channel channel)
        {
            InitializeComponent();
            this.channel = channel;
        }

        #endregion

        #region private functions

        private void Init()
        {
            BindingSource bsSendMode = new BindingSource();
            bsSendMode.DataSource = CAN.CAN_SEND_MODE_LIST.Keys;
            cbxSendMode.DataSource = bsSendMode;
            cbxSendMode.SelectedIndex = cbxSendMode.FindString(CAN.CAN_SEND_MODE_NORMAL);

            BindingSource bsFrameType = new BindingSource();
            bsFrameType.DataSource = CAN.CAN_FRAME_TYPE_LIST.Keys;
            cbxFrameType.DataSource = bsFrameType;
            cbxFrameType.SelectedIndex = cbxFrameType.FindString(CAN.CAN_FRAME_TYPE_DATA_FRAME);

            BindingSource bsFrameFormat = new BindingSource();
            bsFrameFormat.DataSource = CAN.CAN_FRAME_FORMAT_LIST.Keys;
            cbxFrameFormat.DataSource = bsFrameFormat;
            cbxFrameFormat.SelectedIndex = cbxFrameFormat.FindString(CAN.CAN_FRAME_FORMAT_STANDARD_FRAME);
        }

        #endregion

        #region events

        private void UCNormalSendMode_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void tbxSendNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbxSendInterval_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && e.KeyChar != '.' && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbxFrameID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if ((e.KeyChar >= 'a' && e.KeyChar <= 'f') || (e.KeyChar >= 'A' && e.KeyChar <= 'F')
                || (e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == '\b'))
            {
                e.Handled = false;
            }
        }

        #endregion
    }
}
