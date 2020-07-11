using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
   public class DTO_Domain
    {
        public long ID { get; set; }
        public string DomainName { get; set; }
        public string DomainType { get; set; }
        public long Price { get; set; }
    }
}
