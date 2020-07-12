using BUS_QuanLy;
using DTO_QuanLy;
using System;
using System.Windows.Forms;

namespace GUI_QuanLy
{
    public partial class GUI_DangNhap : Form
    {
        public GUI_DangNhap()
        {
            InitializeComponent();
        }
        private BUS_NhanVien _taikhoanBus = new BUS_NhanVien();
       
        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            string iduser = txt_iduser.Text;
            string password = txt_password.Text;
            var isOk = _taikhoanBus.CheckIsLogin(iduser, password);
            if (isOk)
            {
                DTO_NhanVien loginTaiKhoan = _taikhoanBus.GetTaiKhoanByID(iduser);

                GUI_Splash f = new GUI_Splash();
                this.Hide();
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Đăng nhập không thành công. Kiểm tra lại");
            }
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void GUI_DangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát?","Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK) 
            {
                e.Cancel = true;
            }
        }
    }
}
