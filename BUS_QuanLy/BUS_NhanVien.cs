using DAL_QuanLy;
using DTO_QuanLy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QuanLy
{
    public class BUS_NhanVien
    {
        private DAL_NhanVien _taiKhoanDAL;
        public BUS_NhanVien()
        {
            _taiKhoanDAL = new DAL_NhanVien();
        }
        public bool CheckIsLogin(string iduser, string password)
        {
            return _taiKhoanDAL.Login(iduser, password);
        }
        public DTO_NhanVien GetTaiKhoanByID(string iduser)
        {
            return _taiKhoanDAL.GetTaiKhoanByID(iduser);
        }
        public bool Insert(DTO_QuanLy.DTO_NhanVien data)
        {
            return _taiKhoanDAL.Insert(data);
        }
        public DataTable GetList()
        {
            return _taiKhoanDAL.GetList();
        }

        public bool Update(DTO_QuanLy.DTO_NhanVien data)
        {
            return _taiKhoanDAL.Update(data);
        }
        public bool Delete(long id)
        {
            return _taiKhoanDAL.Delete(id);
        }
        public DataTable TimKiem(string str)
        {
            return _taiKhoanDAL.TimKiem(str);
        }
    }
}
