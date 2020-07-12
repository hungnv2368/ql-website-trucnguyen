using DTO_QuanLy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QuanLy
{
    public class DAL_NhanVien
    {
        public bool Login(string iduser, string passWord)
        {
            string query = "USP_Login @iduser , @password ";

            DataTable result = DAL_DBConnect.Instance.ExecuteQuery(query, new object[] { iduser, passWord });

            return result.Rows.Count > 0;
        }
        public DTO_NhanVien GetTaiKhoanByID(string iduser)
        {
            DataTable data = DAL_DBConnect.Instance.ExecuteQuery("Select * from NhanVien where UserName = '" + iduser + "'");

            foreach (DataRow item in data.Rows)
            {
                return new DTO_NhanVien(item);
            }
            return null;
        }

        public bool Insert(DTO_QuanLy.DTO_NhanVien dtKhachHang)
        {
            string query = string.Format("INSERT NhanVien(MaNV,HoTen," +
                "NgaySinh,SoDT,UserName,Password,Quyen) VALUES(N'{0}',N'{1}','{2}',N'{3}',N'{4}',N'{5}',N'{6}')",
                dtKhachHang.MaNV, dtKhachHang.HoTen, dtKhachHang.NgaySinh, dtKhachHang.SoDT,
                dtKhachHang.UserName, dtKhachHang.Password, dtKhachHang.Quyen);

            int result = DAL_DBConnect.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public DataTable GetList()
        {
            return DAL_DBConnect.Instance.ExecuteQuery("SELECT * FROM NhanVien");
        }

        public bool Update(DTO_QuanLy.DTO_NhanVien dtKhachHang)
        {
            string query = string.Format("UPDATE NhanVien SET MaNV = N'{0}',HoTen=N'{1}',NgaySinh='{2}',SoDT=N'{3}'," +
                "UserName='{4}',Password='{5}',Quyen=N'{6}' WHERE ID='{7}'",
                dtKhachHang.MaNV, dtKhachHang.HoTen, dtKhachHang.NgaySinh, dtKhachHang.SoDT,
                dtKhachHang.UserName, dtKhachHang.Password, dtKhachHang.Quyen, dtKhachHang.ID);
            int result = DAL_DBConnect.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool Delete(long userId)
        {
            var result = DAL_DBConnect.Instance.ExecuteNonQuery(string.Format("Delete NhanVien where ID = {0}", userId));
            return result > 0;
        }
        public DataTable TimKiem(string str)
        {
            var query = string.Format("SELECT * FROM NhanVien WHERE (MaNV like '%{0}%' OR HoTen like '%{0}%')", str);
            ; return DAL_DBConnect.Instance.ExecuteQuery(query);
        }
    }
}
