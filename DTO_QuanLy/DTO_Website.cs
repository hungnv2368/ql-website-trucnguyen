using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_Website
    {
        public long ID { get; set; }
        public string WebType { get; set; }
        public string WebAdress { get; set; }
        public long HostID { get; set; }
        public long DomainID { get; set; }
        public long Price { get; set; }
    }
}
