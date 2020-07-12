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
    public partial class GUI_ChoThue : Form
    {
        public GUI_ChoThue()
        {
            InitializeComponent();
            LoadData();
            cbLoaiThue.SelectedIndex = 0;
        }
        private BUS_QuanLy.BUS_ChoThue _bus = new BUS_QuanLy.BUS_ChoThue();
        private BUS_QuanLy.BUS_KhachHang _busKhachHang = new BUS_QuanLy.BUS_KhachHang();
        private BUS_QuanLy.BUS_Hosting _busHosting = new BUS_QuanLy.BUS_Hosting();
        private BUS_QuanLy.BUS_Domain _busDomain = new BUS_QuanLy.BUS_Domain();
        private BUS_QuanLy.BUS_Website _busWebsite = new BUS_QuanLy.BUS_Website();
        private void LoadData()
        {
            gridData.DataSource = _bus.GetList();
            LoadCombobox();
        }
        private void LoadCombobox()
        {
            cbKhachHang.DataSource = _busKhachHang.GetList();
            cbKhachHang.ValueMember = "ID";
            cbKhachHang.DisplayMember = "HoTen";
        }
        private void LoadComboboxHosting()
        {
            cbIDThue.DataSource = _busHosting.GetList();
            cbIDThue.ValueMember = "ID";
            cbIDThue.DisplayMember = "HostAdress";
        }
        private void LoadComboboxDomain()
        {
            cbIDThue.DataSource = _busDomain.GetList();
            cbIDThue.ValueMember = "ID";
            cbIDThue.DisplayMember = "DomainName";
        }
        private void LoadComboboxWebsite()
        {
            cbIDThue.DataSource = _busWebsite.GetList();
            cbIDThue.ValueMember = "ID";
            cbIDThue.DisplayMember = "WebAdress";
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var _hostingDTO = new DTO_QuanLy.DTO_ChoThue()
            {
                CustomerId = long.Parse(cbKhachHang.SelectedValue.ToString()),
                HiringType = cbLoaiThue.Text,
                IDType = long.Parse(cbIDThue.SelectedValue.ToString()),
                HiringDate = dateTimeNgayThue.Value,
                ExpireDate = dateTimeNgayHetHan.Value,
                Price = long.Parse(txtGiaThue.Text),
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
            cbKhachHang.SelectedValue = long.Parse(gridData.Rows[indexrow].Cells[1].Value.ToString());
            cbLoaiThue.Text = gridData.Rows[indexrow].Cells[2].Value.ToString();
            cbLoaiThue_TextChanged(sender, e);
            cbIDThue.SelectedValue = long.Parse(gridData.Rows[indexrow].Cells[3].Value.ToString());
            dateTimeNgayThue.Value = DateTime.Parse(gridData.Rows[indexrow].Cells[4].Value.ToString());
            dateTimeNgayHetHan.Value = DateTime.Parse(gridData.Rows[indexrow].Cells[5].Value.ToString());
            txtGiaThue.Text = gridData.Rows[indexrow].Cells[6].Value.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_id == 0)
            {
                MessageBox.Show("Chưa chọn bản ghi để sửa");
                return;
            }
            var _hostingDTO = new DTO_QuanLy.DTO_ChoThue()
            {
                CustomerId = long.Parse(cbKhachHang.SelectedValue.ToString()),
                HiringType = cbLoaiThue.Text,
                IDType = long.Parse(cbIDThue.SelectedValue.ToString()),
                HiringDate = dateTimeNgayThue.Value,
                ExpireDate = dateTimeNgayHetHan.Value,
                Price = long.Parse(txtGiaThue.Text),
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

        private void cbLoaiThue_TextChanged(object sender, EventArgs e)
        {
            // load danh sach loai thue theo type
            if (cbLoaiThue.Text == Consts.HOST)
            {
                LoadComboboxHosting();
            }
            else if (cbLoaiThue.Text == Consts.DOMAIN)
            {
                LoadComboboxDomain();
            }
            else
            {
                LoadComboboxWebsite();
            }
        }
    }
}
