using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QuanLy
{
    public partial class GUI_Main : Form
    {
        public GUI_Main()
        {
            InitializeComponent();
        }

        private void hostingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var hostingForm = new GUI_Hosting();
            hostingForm.Show();
        }

        private void domainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var domainForm = new GUI_Domain();
            domainForm.Show();
        }

        private void websiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var domainForm = new GUI_Website();
            domainForm.Show();
        }
    }
}
