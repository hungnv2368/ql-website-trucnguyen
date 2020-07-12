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
        public long ID { get; set; }
        public string MaNV { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string SoDT { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Quyen { get; set; }
        public DTO_NhanVien()
        {

        }
        public DTO_NhanVien(DataRow row)
        {
            ID = long.Parse(row["ID"].ToString());
            MaNV = row["MaNV"].ToString();
            HoTen = row["HoTen"].ToString();
            if (row["NgaySinh"] != null && !string.IsNullOrEmpty(row["NgaySinh"].ToString()))
            {
                NgaySinh = DateTime.Parse(row["NgaySinh"].ToString());
            }
            SoDT = row["SoDT"].ToString();
            UserName = row["UserName"].ToString();
            Password = row["Password"].ToString();
            Quyen = row["Quyen"].ToString();
        }
    }
}
