using DAL_QuanLy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QuanLy
{
   public class BUS_Domain
    {
        private DAL_QuanLy.DAL_Domain _domainDAL;
        public BUS_Domain()
        {
            _domainDAL = new DAL_Domain();
        }
        public bool Insert(DTO_QuanLy.DTO_Domain data)
        {
            return _domainDAL.Insert(data);
        }
        public DataTable GetList()
        {
            return _domainDAL.GetList();
        }

        public bool Update(DTO_QuanLy.DTO_Domain data)
        {
            return _domainDAL.Update(data);
        }
        public bool Delete(long id)
        {
            return _domainDAL.Delete(id);
        }
        public DataTable TimKiem(string str)
        {
            return _domainDAL.TimKiem(str);
        }
    }
}
