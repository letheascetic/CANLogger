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
        private bool isConfigured = false;


        public UCCANConfig(Channel channel)
        {
            InitializeComponent();
            this.channel = channel;
        }

        public bool ConfigAndSatrt()
        {
            ConfigCAN();
            return StartCAN();
        }

        public bool ConfigOnly()
        {
            return ConfigCAN();
        }

        private bool ConfigCAN()
        {
            InitConfig config = channel.Config;

            CANMode mode = (CANMode)Enum.ToObject(typeof(CANMode), this.cbxCANMode.SelectedIndex);
            int baudRate = Convert.ToInt32(cbxCANBaudRate.SelectedValue);

            if (isConfigured && mode == channel.Mode && baudRate == channel.BaudRate)
            {
                // already configured, no need to update
                return true;
            }

            Channel.ConfigMode(mode, ref config);
            Channel.ConfigBaudRate(baudRate, ref config);

            if (channel.InitCAN(baudRate, ref config) == CANResult.STATUS_ERR)
            {
                isConfigured = false;
                return false;
            }
            isConfigured = true;
            return true;
        }

        private bool StartCAN()
        {
            return channel.StartCAN() == CANResult.STATUS_OK ? true : false;
        }

        private void UCCANConfig_Load(object sender, EventArgs e)
        {
            string channelIndex = channel.ChannelIndex.ToString();

            this.Name = string.Concat("ucConfigCAN", channelIndex);
            this.lbCAN.Text = channelIndex;
            this.tbxCANIndex.Text = string.Concat("CAN", channelIndex);
            this.tbxCANName.Text = channel.ChannelName;

            this.cbxCANMode.SelectedIndex = (int)channel.Mode;
            this.cbxCANBaudRate.SelectedIndex = this.cbxCANBaudRate.FindString(channel.BaudRate.ToString());
        }

        private void btnCANConfig_Click(object sender, EventArgs e)
        {
            if (!ConfigCAN())
            {
                MessageBox.Show("配置失败。");
            }
        }
    }
}
