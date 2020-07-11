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
        public bool InsertKhachHang(DTO_KhachHang dtKhachHang)
        {
            string query = string.Format("INSERT NguoiDung(MaNguoiDung,HoTen," +
                "NgaySinh,GioiTinh,SoDT,DiaChi,Email,CMTND,TheATM," +
                "QuocTich,UserType,BoPhan)VALUES(N'{0}',N'{1}','{2}',N'{3}',N'{4}',N'{5}'," +
                "N'{6}',N'{7}',N'{8}',N'{9}',N'{10}',N'{11}')", dtKhachHang.MaNguoiDung,
                dtKhachHang.HoTen, dtKhachHang.NgaySinh, dtKhachHang.GioiTinh, dtKhachHang.SoDT,
                dtKhachHang.DiaChi, dtKhachHang.Email, dtKhachHang.CMTND, dtKhachHang.TheATM,
                dtKhachHang.QuocTich, "KH","KH");

            int result = DAL_DBConnect.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public DataTable GetListKhachHang()
        {
            return DAL_DBConnect.Instance.ExecuteQuery("SELECT UserId,MaNguoiDung,HoTen," +
                "NgaySinh,GioiTinh,SoDT,DiaChi,Email,CMTND,TheATM," +
                "QuocTich,UserType FROM NguoiDung WHERE UserType = 'KH'");
        }

        public bool UpdateKhachHang(DTO_KhachHang dtKhachHang)
        {
            string query = string.Format("UPDATE NguoiDung SET MaNguoiDung = N'{0}',HoTen=N'{1}',NgaySinh='{2}',GioiTinh=N'{3}'," +
                "SoDT=N'{4}',DiaChi=N'{5}',Email=N'{6}',CMTND='{7}',TheATM='{8}',QuocTich=N'{9}' WHERE UserId='{10}'",
                dtKhachHang.MaNguoiDung,
                dtKhachHang.HoTen, dtKhachHang.NgaySinh, dtKhachHang.GioiTinh, dtKhachHang.SoDT,
                dtKhachHang.DiaChi, dtKhachHang.Email, dtKhachHang.CMTND, dtKhachHang.TheATM,
                dtKhachHang.QuocTich, dtKhachHang.UserId);
            int result = DAL_DBConnect.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool DeleteKhachHang(long userId)
        {
            int result = DAL_DBConnect.Instance.ExecuteNonQuery(string.Format("Delete NguoiDung where UserId = {0}", userId));

            return result > 0;
        }
        public DataTable TimKhachHang(string str)
        {
            var query = string.Format("SELECT UserId,MaNguoiDung,HoTen," +
                "NgaySinh,GioiTinh,SoDT,DiaChi,Email,CMTND,TheATM," +
                "QuocTich,UserType FROM NguoiDung WHERE UserType = 'KH' AND (MaNguoiDung like '%{0}%' OR HoTen like '%{0}%')", str);
 ;            return DAL_DBConnect.Instance.ExecuteQuery(query);
        }
       
    }
}
