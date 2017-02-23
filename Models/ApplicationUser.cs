using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SalesTracker.Models
{
    public class ApplicationUser : IdentityUser
    {
        public double Commission { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
