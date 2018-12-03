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
            //cbxSendMode.DataSource = Channel.CAN_SEND_MODE_LIST;
        }

        #endregion

        #region events

        private void UCNormalSendMode_Load(object sender, EventArgs e)
        {
            Init();
        }

        #endregion

    }
}
