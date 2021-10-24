using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BD.Models
{
    public class Bouquet
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public string linkPhoto { get; set; }
        public long sID { get; set; }

        public virtual Seller seller { get; set; }
    }
}
