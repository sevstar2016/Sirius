using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BD.Models
{
    public class Purchase
    {
        public int id { get; set; }
        public int bouquetID { get; set; }
        public int customerID { get; set; }
        public decimal price { get; set; }
        public decimal income { get; set; }

        public virtual Bouquet Bouquet { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
