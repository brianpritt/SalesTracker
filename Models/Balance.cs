using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalesTracker.Models
{
    [Table("Balances")]
    public class Balance
    {
        [Key]
        public int BalanceId { get; set; }
        public double Profit { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
