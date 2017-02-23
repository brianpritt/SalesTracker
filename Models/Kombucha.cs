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
        public ICollection<Transaction> Transactions { get; set; }

    }
}
