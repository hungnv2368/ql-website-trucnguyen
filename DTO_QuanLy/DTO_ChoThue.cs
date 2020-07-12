using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_ChoThue
    {
        public long ID { get; set; }
        public long CustomerId { get; set; }
        public string HiringType { get; set; }
        public long IDType { get; set; }
        public DateTime HiringDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public long Price { get; set; }
    }
}
