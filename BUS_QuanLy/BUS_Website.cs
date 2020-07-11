using DAL_QuanLy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QuanLy
{
    public class BUS_Website
    {
        private DAL_QuanLy.DAL_Website _hostingDAL;
        public BUS_Website()
        {
            _hostingDAL = new DAL_Website();
        }
        public bool Insert(DTO_QuanLy.DTO_Website data)
        {
            return _hostingDAL.Insert(data);
        }
        public DataTable GetList()
        {
            return _hostingDAL.GetList();
        }

        public bool Update(DTO_QuanLy.DTO_Website data)
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
