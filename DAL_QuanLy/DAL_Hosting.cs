using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QuanLy
{
    public class DAL_Hosting
    {
        public bool Insert(DTO_QuanLy.DTO_Hosting data)
        {
            string query = string.Format("INSERT Hosting(HostAdress,HostType," +
                "Price)VALUES(N'{0}',N'{1}','{2}')", data.HostAdress,
                data.HostType, data.Price);

            int result = DAL_DBConnect.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public DataTable GetList()
        {
            return DAL_DBConnect.Instance.ExecuteQuery("SELECT * FROM Hosting");
        }

        public bool Update(DTO_QuanLy.DTO_Hosting data)
        {
            string query = string.Format("UPDATE Hosting SET HostAdress = N'{0}',HostType=N'{1}',Price='{2}' WHERE ID='{3}'",
                data.HostAdress, data.HostType, data.Price, data.ID);
            int result = DAL_DBConnect.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool Delete(long id)
        {
            int result = DAL_DBConnect.Instance.ExecuteNonQuery(string.Format("Delete Hosting where ID = {0}", id));
            return result > 0;
        }
        public DataTable TimKiem(string str)
        {
            var query = string.Format("SELECT * FROM Hosting WHERE (HostAdress like '%{0}%' OR HostType like '%{0}%')", str);
             return DAL_DBConnect.Instance.ExecuteQuery(query);
        }
    }
}
