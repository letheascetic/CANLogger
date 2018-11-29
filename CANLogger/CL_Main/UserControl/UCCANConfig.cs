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
    public partial class UCCANConfig : UserControl
    {
        private Channel channel = null;

        public UCCANConfig(Channel channel)
        {
            InitializeComponent();
            this.channel = channel;
        }

        private void UCCANConfig_Load(object sender, EventArgs e)
        {
            this.Name = string.Concat("ucConfigCAN", channel.ChannelIndex.ToString());
            this.tbxCANIndex.Text = string.Concat("CAN", channel.ChannelIndex.ToString());
            this.tbxCANName.Text = channel.ChannelName;
            


        }
    }
}
