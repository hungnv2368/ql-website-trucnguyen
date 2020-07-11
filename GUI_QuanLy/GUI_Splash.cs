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
    public partial class GUI_Splash : Form
    {
        public GUI_Splash()
        {
            InitializeComponent();
        }
        private BUS_QuanLy.BUS_Hosting _hostingBUS = new BUS_QuanLy.BUS_Hosting();

        private void GUI_Splash_Load(object sender, EventArgs e)
        {
            var lstDt = _hostingBUS.GetList();
            var lenth = lstDt.Rows.Count + 1;
            progressBar1.Minimum = 0; //Đặt giá trị nhỏ nhất cho ProgressBar
            progressBar1.Maximum = lenth - 1; //Đặt giá trị lớn nhất cho ProgressBar
            for (var i = 0; i < lenth - 1; i++)
            {
                progressBar1.Value = i; //Gán giá trị cho ProgressBar
            }
            GUI_Main f = new GUI_Main();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
    }
}
