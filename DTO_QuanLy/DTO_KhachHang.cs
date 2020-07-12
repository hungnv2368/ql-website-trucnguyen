using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_KhachHang
    {
        public DTO_KhachHang()
        {

        }
        public long ID { get; set; }
        public string MaKH { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string SoDT { get; set; }
        public string DiaChi  { get; set; }
        public string Email { get; set; }
    }
}
