using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QuanLy
{
    public class DAL_Domain
    {
        public bool Insert(DTO_QuanLy.DTO_Domain data)
        {
            string query = string.Format("INSERT Domain(DomainName,DomainType," +
                "Price)VALUES(N'{0}',N'{1}','{2}')", data.DomainName,
                data.DomainType, data.Price);

            int result = DAL_DBConnect.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public DataTable GetList()
        {
            return DAL_DBConnect.Instance.ExecuteQuery("SELECT * FROM Domain");
        }

        public bool Update(DTO_QuanLy.DTO_Domain data)
        {
            string query = string.Format("UPDATE Domain SET DomainName = N'{0}',DomainType=N'{1}',Price='{2}' WHERE ID='{3}'",
                data.DomainName, data.DomainType, data.Price, data.ID);
            int result = DAL_DBConnect.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool Delete(long id)
        {
            int result = DAL_DBConnect.Instance.ExecuteNonQuery(string.Format("Delete Domain where ID = {0}", id));
            return result > 0;
        }
        public DataTable TimKiem(string str)
        {
            var query = string.Format("SELECT * FROM Domain WHERE (DomainName like '%{0}%' OR DomainType like '%{0}%')", str);
             return DAL_DBConnect.Instance.ExecuteQuery(query);
        }
    }
}
