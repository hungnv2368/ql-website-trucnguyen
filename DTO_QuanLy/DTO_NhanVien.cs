using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_NhanVien
    {
        public long UserId { get; set; }
        public string MaNguoiDung { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string SoDT { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string CMTND { get; set; }
        public string TheATM { get; set; }
        public string QuocTich { get; set; }
        public string UserType { get; set; }
        public string BoPhan { get; set; }
    }
}
