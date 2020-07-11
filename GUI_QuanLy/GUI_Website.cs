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
    public partial class GUI_Website : Form
    {
        public GUI_Website()
        {
            InitializeComponent();
            LoadData();

        }
        private BUS_QuanLy.BUS_Website _bus = new BUS_QuanLy.BUS_Website();
        private BUS_QuanLy.BUS_Hosting _busHosting = new BUS_QuanLy.BUS_Hosting();
        private BUS_QuanLy.BUS_Domain _bus_Domain = new BUS_QuanLy.BUS_Domain();
        private void LoadData()
        {
            gridData.DataSource = _bus.GetList();
            LoadCombobox();
        }
        private void LoadCombobox()
        {
            cbDomain.DataSource = _bus_Domain.GetList();
            cbDomain.ValueMember = "ID";
            cbDomain.DisplayMember = "DomainName";

            cbHosting.DataSource = _busHosting.GetList();
            cbHosting.ValueMember = "ID";
            cbHosting.DisplayMember = "HostAdress";
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var _hostingDTO = new DTO_QuanLy.DTO_Website()
            {
                WebAdress = txtWebsiteName.Text,
                WebType = txtWebsiteType.Text,
                Price = long.Parse(txtPrice.Text),
                HostID = long.Parse(cbHosting.SelectedValue.ToString()),
                DomainID = long.Parse(cbDomain.SelectedValue.ToString())
            };
            var isOk = _bus.Insert(_hostingDTO);
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
            txtWebsiteName.Text = gridData.Rows[indexrow].Cells[1].Value.ToString();
            txtWebsiteType.Text = gridData.Rows[indexrow].Cells[2].Value.ToString();
            cbHosting.SelectedValue = long.Parse(gridData.Rows[indexrow].Cells[3].Value.ToString());
            cbDomain.SelectedValue = long.Parse(gridData.Rows[indexrow].Cells[4].Value.ToString());
            txtPrice.Text = gridData.Rows[indexrow].Cells[5].Value.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_id == 0)
            {
                MessageBox.Show("Chua chon ban ghi de sua");
                return;
            }
            var _hostingDTO = new DTO_QuanLy.DTO_Website()
            {
                WebAdress = txtWebsiteName.Text,
                WebType = txtWebsiteType.Text,
                Price = long.Parse(txtPrice.Text),
                HostID = long.Parse(cbHosting.SelectedValue.ToString()),
                DomainID = long.Parse(cbDomain.SelectedValue.ToString()),
                ID = _id
            };
            var isOk = _bus.Update(_hostingDTO);
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
            var isOk = _bus.Delete(_id);
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
                gridData.DataSource = _bus.GetList();
                return;
            }
            var dtTimKiem = _bus.TimKiem(txtSearch.Text);
            gridData.DataSource = dtTimKiem;
        }
    }
}
