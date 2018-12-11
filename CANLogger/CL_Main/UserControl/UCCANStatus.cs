using CL_Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace CL_Main
{
    public partial class UCCANStatus : UserControl
    {
        private CANErrInfo pCANError = new CANErrInfo();
        private CANStatus pCANStatus = new CANStatus();
        private Channel channel = null;

        public UCCANStatus(Channel channel)
        {
            InitializeComponent();
            this.channel = channel;
            this.Name = channel.ChannelName;
            this.timer.Start();
        }

        public Channel GetChannel()
        {
            return channel;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (channel.IsInitialized)
            {
                //channel.ReadCanStatus(out this.pCANStatus);
                channel.ReadErrInfo(out this.pCANError);
            }
        }
    }
}
