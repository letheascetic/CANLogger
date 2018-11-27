using CL_Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CL_Main.Dialog
{
    public partial class DialogDevice : Form
    {
        private Device device;

        public DialogDevice(string deviceID)
        {
            InitializeComponent();
        }

        private void InitLoadControls()
        {
            //load cbxSelectDevice data source
            BindingSource source = new BindingSource();
            source.DataSource = CL_Framework.Device.DeviceTypies;
            cbxSelectDevice.DataSource = source;
            cbxSelectDevice.ValueMember = "Value";
            cbxSelectDevice.DisplayMember = "Key";

            cbxSelectDevice.Enabled = device == null ? true : false;

            tabControl.Enabled = false;
            btnOK.Enabled = false;
        }

        private void DialogDevice_Load(object sender, EventArgs e)
        {
            InitLoadControls();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
