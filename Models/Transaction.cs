using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalesTracker.Models
{
    [Table("Transactions")]
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        public int TransactionType { get; set; }
        public string UserId { get; set; }
        public int KomId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Kombucha Kombucha { get; set; }
        
        public Transaction(int komId, string userId, int transactionType)
        {
            UserId = userId;
            KomId = komId;
            TransactionType = transactionType;

        }

        public Transaction()
        {

        }
        
    }
}
