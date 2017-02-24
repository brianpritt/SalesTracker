using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalesTracker.Models
{
    [Table("Kombuchas")]
    public class Kombucha
    {
        [Key]
        public int KomId { get; set; }
        public string KomName { get; set; }
        public string KomDescription { get; set; }
        public double KomPrice { get; set; }
        public int KomQuantity { get; set; }
        public ICollection<Transaction> Transactions { get; set; }

        public Kombucha(string komName, string komDescription, double komPrice, int komId = 0)
        {
            KomName = komName;
            KomDescription = komDescription;
            KomPrice = komPrice;
            KomId = komId;
        }
        public Kombucha() { }
    }
}
