using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CL_Main
{
    public partial class FormDevice : Form
    {
        public FormDevice()
        {
            InitializeComponent();
        }

        public void SetLanguage(string language)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(language);
            System.ComponentModel.ComponentResourceManager resources = new ComponentResourceManager(this.GetType());

            resources.ApplyResources(this, "$this");

            resources.ApplyResources(this.btnStart, this.btnStart.Name);
            resources.ApplyResources(this.btnStop, this.btnStop.Name);
            resources.ApplyResources(this.btnClose, this.btnClose.Name);
            resources.ApplyResources(this.btnFilter, this.btnFilter.Name);

        }

    }
}
