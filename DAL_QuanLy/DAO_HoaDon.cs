using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QuanLy
{
    public class DAL_HoaDon
    {
        public bool Insert(DTO_QuanLy.DTO_HoaDon dtTour)
        {
            string query = string.Format("INSERT HoaDon(IdVe,UserIdKhachHang," +
                "UserIdNV,NgayThanhToan,TongTien,MaHD) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", dtTour.IdVe,
                dtTour.UserIdKhachHang, dtTour.UserIdNV, dtTour.NgayThanhToan, dtTour.TongTien,dtTour.MaHD);

            int result = DAL_DBConnect.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public System.Data.DataTable GetList()
        {
            return DAL_DBConnect.Instance.ExecuteQuery("SELECT * FROM HoaDon");
        }

        public bool Update(DTO_QuanLy.DTO_HoaDon dtTour)
        {
            string query = string.Format("UPDATE HoaDon SET IdVe = '{0}',UserIdKhachHang='{1}',UserIdNV='{2}',NgayThanhToan='{3}'," +
                "TongTien='{4}',MaHD='{5}' WHERE IdHoaDon='{6}'",
             dtTour.IdVe,
                dtTour.UserIdKhachHang, dtTour.UserIdNV, dtTour.NgayThanhToan, dtTour.TongTien,dtTour.MaHD, dtTour.IdHoaDon);
            int result = DAL_DBConnect.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool Delete(long tourId)
        {
            int result = DAL_DBConnect.Instance.ExecuteNonQuery(string.Format("Delete HoaDon where IdHoaDon = {0}", tourId));

            return result > 0;
        }
        public System.Data.DataTable TimHD(string str)
        {
            var query = string.Format("SELECT * FROM HoaDon WHERE MaHD like '%{0}%'", str);
            ; return DAL_DBConnect.Instance.ExecuteQuery(query);

        }
    }
}
