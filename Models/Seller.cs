using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BD.Models
{
    public class Seller
    {
        public int id { get; set; }
        public string shopName { get; set; }
        public string linkPhoto { get; set; }
        public DateTime dateOfCreation { get; set; }
        public int selledBouquets { get; set; }
        public virtual ICollection<Bouquet> bouquets { get; set; }
    }
}
