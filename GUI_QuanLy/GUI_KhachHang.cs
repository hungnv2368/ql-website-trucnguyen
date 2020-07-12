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
    public partial class GUI_KhachHang : Form
    {
        public GUI_KhachHang()
        {
            InitializeComponent();
            LoadData();
        }
        private BUS_QuanLy.BUS_KhachHang _bus = new BUS_QuanLy.BUS_KhachHang();
        private void LoadData()
        {
            gridData.DataSource = _bus.GetList();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var _hostingDTO = new DTO_QuanLy.DTO_KhachHang()
            {
                MaKH = txtMaKH.Text,
                HoTen = txtHoTen.Text,
                Email = txtEmail.Text,
                SoDT = txtSoDT.Text,
                DiaChi = txtDiaChi.Text,
                NgaySinh = datePickerNgaySinh.Value
            };
            var isOk = _bus.Insert(_hostingDTO);
            if (isOk)
            {
                MessageBox.Show("Thêm mới thành công!");
            }
            else
            {
                MessageBox.Show("Thêm mới không thành công");
            }
            LoadData();
        }
        private long _id = 0;
        private void gridData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexrow = e.RowIndex;
            if (indexrow < 0) return;
            _id = int.Parse(gridData.Rows[indexrow].Cells[0].Value.ToString());
            txtMaKH.Text = gridData.Rows[indexrow].Cells[1].Value.ToString();
            txtHoTen.Text = gridData.Rows[indexrow].Cells[2].Value.ToString();
            datePickerNgaySinh.Value = DateTime.Parse(gridData.Rows[indexrow].Cells[3].Value.ToString());
            txtSoDT.Text = gridData.Rows[indexrow].Cells[4].Value.ToString();
            txtDiaChi.Text = gridData.Rows[indexrow].Cells[5].Value.ToString();
            txtEmail.Text = gridData.Rows[indexrow].Cells[6].Value.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_id == 0)
            {
                MessageBox.Show("Chưa chọn bản ghi để sửa");
                return;
            }
            var _hostingDTO = new DTO_QuanLy.DTO_KhachHang()
            {
                MaKH = txtMaKH.Text,
                HoTen = txtHoTen.Text,
                Email = txtEmail.Text,
                SoDT = txtSoDT.Text,
                DiaChi = txtDiaChi.Text,
                NgaySinh = datePickerNgaySinh.Value,
                ID = _id
            };
            var isOk = _bus.Update(_hostingDTO);
            if (isOk)
            {
                MessageBox.Show("Cập nhật thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật không thành công");
            }
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_id == 0)
            {
                MessageBox.Show("Chưa chọn bản ghi để xóa");
                return;
            }
            var isOk = _bus.Delete(_id);
            if (isOk)
            {
                MessageBox.Show("Xóa thành công");
            }
            else
            {
                MessageBox.Show("Xóa không thành công");
            }
            LoadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                gridData.DataSource = _bus.GetList();
                return;
            }
            var dtTimKiem = _bus.TimKiem(txtSearch.Text);
            gridData.DataSource = dtTimKiem;
        }
    }
}
