using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalesTracker.Models
{
    [Table("Inventories")]
    public class Inventory
    {
        [Key]
        public int QuantityId { get; set; }
        public int Quantitiy { get; set; }
        public virtual ICollection<Kombucha> Kombuchas { get; set; }

        

    }
}
