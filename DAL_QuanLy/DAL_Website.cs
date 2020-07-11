using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QuanLy
{
   public class DAL_Website
    {
        public bool Insert(DTO_QuanLy.DTO_Website data)
        {
            string query = string.Format("INSERT Website(WebType,WebAdress," +
                "HostID,DomainID,Price)VALUES(N'{0}',N'{1}','{2}')", data.WebType,
                data.WebAdress, data.HostID,data.DomainID,data.Price);

            int result = DAL_DBConnect.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public DataTable GetList()
        {
            return DAL_DBConnect.Instance.ExecuteQuery("SELECT * FROM Website");
        }

        public bool Update(DTO_QuanLy.DTO_Website data)
        {
            string query = string.Format("UPDATE Website SET WebType = N'{0}',WebAdress=N'{1}',HostID='{2}'," +
                "DomainID='{3}',Price='{4}' WHERE ID='{5}'",
                data.WebType, data.WebAdress, data.HostID, data.DomainID,data.Price,data.ID);
            int result = DAL_DBConnect.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool Delete(long id)
        {
            int result = DAL_DBConnect.Instance.ExecuteNonQuery(string.Format("Delete Website where ID = {0}", id));
            return result > 0;
        }
        public DataTable TimKiem(string str)
        {
            var query = string.Format("SELECT * FROM Website WHERE (WebType like '%{0}%' OR WebAdress like '%{0}%')", str);
            return DAL_DBConnect.Instance.ExecuteQuery(query);
        }
    }
}
