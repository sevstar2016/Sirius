using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BD.Models
{
    public class Customer
    {
        public int id { get; set; }
        public string name { get; set; }
        public string mail { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
