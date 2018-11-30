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
        private Channel channel = null;

        public UCCANStatus(Channel channel)
        {
            InitializeComponent();
            this.channel = channel;
        }

        public Channel GetChannel()
        {
            return channel;
        }

        private void UCCANStatus_Load(object sender, EventArgs e)
        {
            this.Name = channel.ChannelName;
        }
    }
}
