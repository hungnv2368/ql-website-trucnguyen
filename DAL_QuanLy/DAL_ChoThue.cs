using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QuanLy
{
    public class DAL_ChoThue
    {
        public bool Insert(DTO_QuanLy.DTO_ChoThue data)
        {
            string query = string.Format("INSERT Hiring(CustomerId,HiringType," +
                "IDType,HiringDate,ExpireDate,Price) VALUES(N'{0}',N'{1}','{2}','{3}','{4}','{5}')", data.CustomerId,
                data.HiringType, data.IDType, data.HiringDate, data.ExpireDate, data.Price);

            int result = DAL_DBConnect.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public DataTable GetList()
        {
            // viet lai cau join
            return DAL_DBConnect.Instance.ExecuteQuery("SELECT * FROM Hiring");
        }

        public bool Update(DTO_QuanLy.DTO_ChoThue data)
        {
            string query = string.Format("UPDATE Hiring SET CustomerId = N'{0}',HiringType=N'{1}',IDType='{2}'," +
                "HiringDate='{3}',ExpireDate='{4}',Price='{5}' WHERE ID='{6}'",
               data.CustomerId,
                data.HiringType, data.IDType, data.HiringDate, data.ExpireDate, data.Price, data.ID);
            int result = DAL_DBConnect.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool Delete(long id)
        {
            int result = DAL_DBConnect.Instance.ExecuteNonQuery(string.Format("Delete Hiring where ID = {0}", id));
            return result > 0;
        }
        public DataTable TimKiem(string str)
        {
            var query = string.Format("SELECT * FROM Hiring WHERE (HiringType like '%{0}%' " +
                "OR CustomerId IN (SELECT ID from KhachHang WHERE MaKH like '%{0}%' OR HoTen like '%{0}%'))", str);
         
            return DAL_DBConnect.Instance.ExecuteQuery(query);
        }
    }
}
