using DTO_QuanLy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QuanLy
{
    public class DAL_TaiKhoan
    {
        public bool Login(string iduser, string passWord)
        {
            string query = "USP_Login @iduser , @password ";

            DataTable result = DAL_DBConnect.Instance.ExecuteQuery(query, new object[] { iduser, passWord });

            return result.Rows.Count > 0;
        }
        public DTO_TaiKhoan GetTaiKhoanByID(string iduser)
        {
            DataTable data = DAL_DBConnect.Instance.ExecuteQuery("Select * from dbo.taikhoan where UserName = '" + iduser +  "'");

            foreach (DataRow item in data.Rows)
            {
                return new DTO_TaiKhoan(item);
            }
            return null;
        }
        public DataTable GetTaiKhoan()
        {
            return DAL_DBConnect.Instance.ExecuteQuery("Select * from taikhoan order by UserId desc ");
        }
        public bool UpdateMatKhau(string iduser, string passWord,string newpass)
        {

            int result = DAL_DBConnect.Instance.ExecuteNonQuery("exec USP_UpdateMatKhau @iduser , @password , @newpass ", new object[] { iduser, passWord, newpass });

            return result > 0;
        }

        public bool InsertTaiKhoan(string iduser, string passWord, string newpass)
        {
            int result = DAL_DBConnect.Instance.ExecuteNonQuery(string.Format("insert into dbo.taikhoan (iduser) values (N'{0}')", iduser));

            return result > 0;
        }
        public bool UpdateTaiKhoan(string iduser, int quyen)
        {

            int result = DAL_DBConnect.Instance.ExecuteNonQuery(String.Format("Update TaiKhoan set quyen = {0} where iduser = {1} ", quyen, iduser));

            return result > 0;
        }
        public bool ResetPass(string iduser)
        {

            int result = DAL_DBConnect.Instance.ExecuteNonQuery(String.Format("Update TaiKhoan set password = 1111 where iduser = {0} " , iduser));

            return result > 0;
        }
        public bool InsertTTTaiKhoan(string iduser, string quyen)
        {
            int result = DAL_DBConnect.Instance.ExecuteNonQuery(string.Format("insert into dbo.taikhoan (iduser) values (N'{0}')", iduser));

            return result > 0;
        }
    }
}
