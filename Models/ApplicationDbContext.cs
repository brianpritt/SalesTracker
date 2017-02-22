using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;



namespace SalesTracker.Models
{
         public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
        {
            public ApplicationDbContext()
            {

            }
            
            public ApplicationDbContext(DbContextOptions options) : base(options)
            {

            }

            protected override void OnModelCreating(ModelBuilder builder)
            {
                base.OnModelCreating(builder);

            }

            protected override void OnConfiguring(DbContextOptionsBuilder options)
            {
                options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=SalesTracker;integrated security=True");
            }

        }
    }

