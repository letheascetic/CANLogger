﻿using System;
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
    public partial class UCListSendMode : UserControl
    {
        private Channel channel;

        public UCListSendMode(Channel channel)
        {
            InitializeComponent();
            this.channel = channel;
        }
    }
}
