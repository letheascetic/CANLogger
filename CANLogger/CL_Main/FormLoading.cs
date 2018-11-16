using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CL_Main
{
    public partial class FormLoading : Form
    {
        int count = 0;
        int opacity = 100;

        public FormLoading()
        {
            InitializeComponent();
        }


        private void FormLoading_Load(object sender, EventArgs e)
        {
            this.timer1.Start();
            this.timer1.Interval = 30;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            count++;
            opacity--;
            this.Opacity = opacity / 50.0;
            if (count == 100)
            {
                this.Close();
            }
        }

        private void FormLoading_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.timer1.Stop();
        }
    }
}
