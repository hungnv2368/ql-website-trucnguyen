using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QuanLy
{
    public class BUS_ChoThue
    {
        private DAL_QuanLy.DAL_ChoThue _taiKhoanDAL;
        public BUS_ChoThue()
        {
            _taiKhoanDAL = new DAL_QuanLy.DAL_ChoThue();
        }
        public bool Insert(DTO_QuanLy.DTO_ChoThue data)
        {
            return _taiKhoanDAL.Insert(data);
        }
        public DataTable GetList()
        {
            return _taiKhoanDAL.GetList();
        }

        public bool Update(DTO_QuanLy.DTO_ChoThue data)
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
        public DataTable GetListByDateTime(DateTime start, DateTime end)
        {
            return _taiKhoanDAL.GetListByDateTime(start, end);
        }
    }
}
