using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_HoaDon
    {
        public long IdHoaDon { get; set; }
        public long IdVe { get; set; }
        public long UserIdKhachHang { get; set; }
        public long UserIdNV { get; set; }
        public DateTime NgayThanhToan { get; set; }
        public decimal TongTien { get; set; }

        public string MaHD { get; set; }
    }
}
