using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserCatalogService.Model;

namespace UserCatalogService.Data
{
    public class UserCatalogContext : DbContext
    {
      
        public UserCatalogContext (DbContextOptions<UserCatalogContext> options) 
            : base(options)
        {

        }

        public DbSet<UserCatalog> UserCatalog { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbBuilder)
        {
            //modelbBuilder.Entity<Share>().HasOne<UserCatalog>(q => q.UserCatalog)
            //    .WithMany(w => w.Shares)
            //    .HasForeignKey(y => y.UserCatalogId);

            modelbBuilder.Entity<UserCatalog>().HasMany(
                 u => u.Shares
                 ).WithOne(s => s.UserCatalog);

            modelbBuilder.Entity<UserCatalog>().HasData(
               new UserCatalog
               {
                   Capital = 100.10,
                   Name = "Ida Hansen",
                   Id = "20"
               }
               );

            modelbBuilder.Entity<Share>().HasData(
                new Share { Id = "AAPL", UserCatalogId = "20" }
                );

        }

    }
}
