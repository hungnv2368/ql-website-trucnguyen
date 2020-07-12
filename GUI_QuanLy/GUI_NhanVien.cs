using DTO_QuanLy;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
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
                Quyen = comboQuyen.Text
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
            txtMaNV.Text = gridData.Rows[indexrow].Cells[1].Value.ToString();
            txtHoTen.Text = gridData.Rows[indexrow].Cells[2].Value.ToString();
            if (!string.IsNullOrEmpty(gridData.Rows[indexrow].Cells[3].Value.ToString()))
                datePickerNgaySinh.Value = DateTime.Parse(gridData.Rows[indexrow].Cells[3].Value.ToString());
            txtSoDT.Text = gridData.Rows[indexrow].Cells[4].Value.ToString();
            txtUserName.Text = gridData.Rows[indexrow].Cells[5].Value.ToString();
            txtPassword.Text = gridData.Rows[indexrow].Cells[6].Value.ToString();
            comboQuyen.Text = gridData.Rows[indexrow].Cells[7].Value.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_id == 0)
            {
                MessageBox.Show("Chưa chọn bản ghi để sửa");
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
                Quyen = comboQuyen.Text,
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

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            string filePath = "";
            // tạo SaveFileDialog để lưu file excel
            SaveFileDialog dialog = new SaveFileDialog();

            // chỉ lọc ra các file có định dạng Excel
            dialog.Filter = "Excel | *.xlsx | Excel 2003 | *.xls";

            // Nếu mở file và chọn nơi lưu file thành công sẽ lưu đường dẫn lại dùng
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                filePath = dialog.FileName;
            }

            // nếu đường dẫn null hoặc rỗng thì báo không hợp lệ và return hàm
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Đường dẫn báo cáo không hợp lệ");
                return;
            }

            try
            {
                GenerateExcel(_bus.GetList(), filePath);
                MessageBox.Show("Xuất excel thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi lưu file! " + ex.ToString());
            }
        }
        public static void GenerateExcel(DataTable dataTable, string path)
        {

            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(dataTable);
            // create a excel app along side with workbook and worksheet and give a name to it
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook excelWorkBook = excelApp.Workbooks.Add();
            Excel._Worksheet xlWorksheet = excelWorkBook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;
            foreach (DataTable table in dataSet.Tables)
            {
                //Add a new worksheet to workbook with the Datatable name
                Excel.Worksheet excelWorkSheet = excelWorkBook.Sheets.Add();
                excelWorkSheet.Name = table.TableName;
                // add all the columns
                for (int i = 1; i < table.Columns.Count + 1; i++)
                {
                    excelWorkSheet.Cells[1, i] = table.Columns[i - 1].ColumnName;
                }
                // add all the rows
                for (int j = 0; j < table.Rows.Count; j++)
                {
                    for (int k = 0; k < table.Columns.Count; k++)
                    {
                        excelWorkSheet.Cells[j + 2, k + 1] = table.Rows[j].ItemArray[k].ToString();
                    }
                }
            }
            excelWorkBook.SaveAs(path); // -> this will do the custom
            excelWorkBook.Close();
            excelApp.Quit();
        }
    }
}
