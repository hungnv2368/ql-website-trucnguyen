using DTO_QuanLy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QuanLy
{
    public class DAL_KhachHang
    {
        public bool Insert(DTO_KhachHang dtKhachHang)
        {
            string query = string.Format("INSERT KhachHang(MaKH,HoTen," +
                "NgaySinh,SoDT,DiaChi,Email)VALUES(N'{0}',N'{1}','{2}',N'{3}',N'{4}',N'{5}')",
                dtKhachHang.MaKH, dtKhachHang.HoTen, dtKhachHang.NgaySinh, dtKhachHang.SoDT,
                dtKhachHang.DiaChi, dtKhachHang.Email);

            int result = DAL_DBConnect.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public DataTable GetList()
        {
            return DAL_DBConnect.Instance.ExecuteQuery("SELECT * FROM KhachHang");
        }

        public bool Update(DTO_KhachHang dtKhachHang)
        {
            string query = string.Format("UPDATE KhachHang SET MaKH = N'{0}',HoTen=N'{1}',NgaySinh='{2}',SoDT=N'{3}'" +
                ",DiaChi=N'{4}',Email=N'{5}' WHERE ID='{10}'",
                dtKhachHang.MaKH,
                dtKhachHang.HoTen, dtKhachHang.NgaySinh,dtKhachHang.SoDT,
                dtKhachHang.DiaChi, dtKhachHang.Email, dtKhachHang.ID);
            int result = DAL_DBConnect.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool Delete(long userId)
        {
            int result = DAL_DBConnect.Instance.ExecuteNonQuery(string.Format("Delete KhachHang where ID = {0}", userId));

            return result > 0;
        }
        public DataTable TimKiem(string str)
        {
            var query = string.Format("SELECT * FROM KhachHang WHERE (MaKH like '%{0}%' OR HoTen like '%{0}%')", str);
            ; return DAL_DBConnect.Instance.ExecuteQuery(query);
        }

    }
}
