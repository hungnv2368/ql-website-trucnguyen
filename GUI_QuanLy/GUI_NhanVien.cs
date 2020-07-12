﻿using DTO_QuanLy;
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
    public partial class GUI_NhanVien : Form
    {
        public GUI_NhanVien()
        {
            InitializeComponent();
            comboQuyen.SelectedIndex = 0;
            LoadData();
        }
        private BUS_QuanLy.BUS_NhanVien _bus = new BUS_QuanLy.BUS_NhanVien();
        private void LoadData()
        {
            gridData.DataSource = _bus.GetList();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var _hostingDTO = new DTO_NhanVien()
            {
                MaNV = txtMaNV.Text,
                HoTen = txtHoTen.Text,
                SoDT = txtSoDT.Text,
                NgaySinh = datePickerNgaySinh.Value,
                UserName = txtUserName.Text,
                Password = txtPassword.Text,
                Quyen = comboQuyen.SelectedText
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
            txtMaNV.Text = gridData.Rows[indexrow].Cells[1].Value.ToString();
            txtHoTen.Text = gridData.Rows[indexrow].Cells[2].Value.ToString();
            datePickerNgaySinh.Value = DateTime.Parse(gridData.Rows[indexrow].Cells[3].Value.ToString());
            txtSoDT.Text = gridData.Rows[indexrow].Cells[4].Value.ToString();
            txtUserName.Text = gridData.Rows[indexrow].Cells[5].Value.ToString();
            txtPassword.Text = gridData.Rows[indexrow].Cells[6].Value.ToString();
            comboQuyen.SelectedText = gridData.Rows[indexrow].Cells[7].Value.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_id == 0)
            {
                MessageBox.Show("Chua chon ban ghi de sua");
                return;
            }
            var _hostingDTO = new DTO_QuanLy.DTO_NhanVien()
            {
                MaNV = txtMaNV.Text,
                HoTen = txtHoTen.Text,
                SoDT = txtSoDT.Text,
                NgaySinh = datePickerNgaySinh.Value,
                UserName = txtUserName.Text,
                Password = txtPassword.Text,
                Quyen = comboQuyen.SelectedText,
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