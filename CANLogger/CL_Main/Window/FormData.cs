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
using WeifenLuo.WinFormsUI.Docking;

namespace CL_Main
{
    public partial class FormData : DockContent
    {
        public FormData()
        {
            InitializeComponent();
        }

        public void SetLanguage(string language)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(language);
            System.ComponentModel.ComponentResourceManager resources = new ComponentResourceManager(this.GetType());

            resources.ApplyResources(this, "$this");

            resources.ApplyResources(this.btnContinueShow, this.btnContinueShow.Name);
            resources.ApplyResources(this.btnStopShow, this.btnStopShow.Name);
            resources.ApplyResources(this.btnShowMode, this.btnShowMode.Name);
            resources.ApplyResources(this.btnFilter, this.btnFilter.Name);

        }

    }
}
