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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //Start Form Loading
            //FormLoading formLoading = new FormLoading();
            //formLoading.ShowDialog();




        }

        private void btnLanguage_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)e.ClickedItem;
            if (item.Checked)
            {
                return;
            }

            string language = (string)item.Tag;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(language);

            System.ComponentModel.ComponentResourceManager res = new ComponentResourceManager(this.GetType());
            foreach (Control ctl in Controls)
            {
                res.ApplyResources(ctl, ctl.Name);
            }
            this.ResumeLayout(false);
            this.PerformLayout();
            res.ApplyResources(this, "$this");
            
            int oldIndex = Convert.ToInt32(btnLanguage.Tag);
            ToolStripMenuItem oldItem = (ToolStripMenuItem)btnLanguage.DropDownItems[oldIndex];
            oldItem.Checked = false;

            item.Checked = true;
            int newIndex = btnLanguage.DropDownItems.IndexOf(item);
            btnLanguage.Tag = newIndex;
            
        }

    }
}
