using DAL_QuanLy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QuanLy
{
    public class BUS_Hosting
    {
        private DAL_QuanLy.DAL_Hosting _hostingDAL;
        public BUS_Hosting()
        {
            _hostingDAL = new DAL_Hosting();
        }
        public bool Insert(DTO_QuanLy.DTO_Hosting data)
        {
            return _hostingDAL.Insert(data);
        }
        public DataTable GetList()
        {
            return _hostingDAL.GetList();
        }

        public bool Update(DTO_QuanLy.DTO_Hosting data)
        {
            return _hostingDAL.Update(data);
        }
        public bool Delete(long id)
        {
            return _hostingDAL.Delete(id);
        }
        public DataTable TimKiem(string str)
        {
            return _hostingDAL.TimKiem(str);
        }
    }
}
