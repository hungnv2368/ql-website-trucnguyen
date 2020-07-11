using DAL_QuanLy;
using DTO_QuanLy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QuanLy
{
    public class BUS_TaiKhoan
    {
        private DAL_TaiKhoan _taiKhoanDAL;
        public BUS_TaiKhoan()
        {
            _taiKhoanDAL = new DAL_TaiKhoan();
        }
        public bool CheckIsLogin(string iduser, string password)
        {
            return _taiKhoanDAL.Login(iduser, password);
        }
        public DTO_TaiKhoan GetTaiKhoanByID(string iduser)
        {
            return _taiKhoanDAL.GetTaiKhoanByID(iduser);
        }
    }
}
