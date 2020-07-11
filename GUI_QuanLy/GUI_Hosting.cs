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
    public partial class GUI_Hosting : Form
    {
        public GUI_Hosting()
        {
            InitializeComponent();
            LoadData();
        }
        private BUS_QuanLy.BUS_Hosting _hostingBUS = new BUS_QuanLy.BUS_Hosting();
        private void LoadData()
        {
            gridData.DataSource = _hostingBUS.GetList();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var _hostingDTO = new DTO_QuanLy.DTO_Hosting()
            {
                HostAdress = txtHostAdress.Text,
                HostType = txtHostType.Text,
                Price = long.Parse(txtPrice.Text)
            };
            var isOk = _hostingBUS.Insert(_hostingDTO);
            if (isOk)
            {
                MessageBox.Show("Them moi thanh cong");
            }
            else
            {
                MessageBox.Show("Them moi loi");
            }
            LoadData();
        }
        private long _id = 0;
        private void gridData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexrow = e.RowIndex;
            if (indexrow < 0) return;
            _id = int.Parse(gridData.Rows[indexrow].Cells[0].Value.ToString());
            txtHostAdress.Text = gridData.Rows[indexrow].Cells[1].Value.ToString();
            txtHostType.Text = gridData.Rows[indexrow].Cells[2].Value.ToString();
            txtPrice.Text = gridData.Rows[indexrow].Cells[3].Value.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_id == 0)
            {
                MessageBox.Show("Chua chon ban ghi de sua");
                return;
            }
            var _hostingDTO = new DTO_QuanLy.DTO_Hosting()
            {
                HostAdress = txtHostAdress.Text,
                HostType = txtHostType.Text,
                Price = long.Parse(txtPrice.Text),
                ID = _id
            };
            var isOk = _hostingBUS.Update(_hostingDTO);
            if (isOk)
            {
                MessageBox.Show("Cap nhat thanh cong");
            }
            else
            {
                MessageBox.Show("Cap nhat loi");
            }
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_id == 0)
            {
                MessageBox.Show("Chua chon ban ghi de xoa");
                return;
            }
            var isOk = _hostingBUS.Delete(_id);
            if (isOk)
            {
                MessageBox.Show("Xoa thanh cong");
            }
            else
            {
                MessageBox.Show("Xoa loi");
            }
            LoadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                gridData.DataSource = _hostingBUS.GetList();
                return;
            }
            var dtTimKiem = _hostingBUS.TimKiem(txtSearch.Text);
            gridData.DataSource = dtTimKiem;
        }
    }
}
