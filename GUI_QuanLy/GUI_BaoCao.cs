using System;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;

namespace GUI_QuanLy
{
    public partial class GUI_BaoCao : Form
    {
        public GUI_BaoCao()
        {
            InitializeComponent();
        }
        BUS_QuanLy.BUS_ChoThue choThueBus = new BUS_QuanLy.BUS_ChoThue();

        private void ChartBieuDoDoanhThu_Load(object sender, EventArgs e)
        {

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            var list = choThueBus.GetListByDateTime(dateTimeStart.Value, dateTimeEnd.Value);
            if (list != null && list.Rows.Count <= 0)
            {
                MessageBox.Show("Không có dữ liệu");
                return;
            }
            MessageBox.Show("Lấy xong dữ liệu");
            var dicItem = new Dictionary<int, long>();
            foreach (var row in list.Rows)
            {
                var dtRow = row as DataRow;
                var month = int.Parse(dtRow[0].ToString());
                var price = long.Parse(dtRow[1].ToString());
                if (!dicItem.ContainsKey(month))
                    dicItem[month] = 0;
                dicItem[month] += price;
            }
            int j = 0;
            foreach (var item in dicItem)
            {
                chartDoanhThu.Series["ChartDoanhThu"].Points.Add(item.Value);
                chartDoanhThu.Series["ChartDoanhThu"].Points[j].Label = item.Value.ToString();
                chartDoanhThu.Series["ChartDoanhThu"].Points[j].AxisLabel = "Tháng " + item.Key;
                j++;
            }
        }


    }
}
