using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QuanLy
{
    public partial class GUI_Splash : Form
    {
        public GUI_Splash()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            timer1.Enabled = true;
        }
        private BUS_QuanLy.BUS_Hosting _hostingBUS = new BUS_QuanLy.BUS_Hosting();

        private void GUI_Splash_Load(object sender, EventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int i;

            progressBar1.Minimum = 0;
            progressBar1.Maximum = 200;

            for (i = 0; i <= 200; i++)
            {
                Thread.Sleep(10);
                progressBar1.Value = i;
            }
            timer1.Stop();

            GUI_Main f = new GUI_Main();
            this.Hide();
            f.ShowDialog();
            this.Show();

        }
    }
}
