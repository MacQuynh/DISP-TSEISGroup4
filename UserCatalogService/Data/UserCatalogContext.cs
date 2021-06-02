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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Share>().HasOne<UserCatalog>(q => q.UserCatalog)
            //    .WithMany(w => w.Shares)
            //    .HasForeignKey(y => y.UserCatalogId);

            //modelBuilder.Entity<UserCatalog>().HasMany(
            //     u => u.Shares
            //     ).WithOne(s => s.UserCatalog);


            modelBuilder.Entity<UserCatalog>().HasData(
               new UserCatalog
               {
                   Capital = 100.10,
                   Name = "Ida Hansen",
                   Id = "20",
                   ShareIds = "12224,12225"
               },
               new UserCatalog
               {
                   Capital = 200.10,
                   Name = "Trang",
                   Id = "1",
                   ShareIds = "12226,12227"
               },
               new UserCatalog
               {
                   Capital = 300.10,
                   Name = "Mads",
                   Id = "2",
                   ShareIds = "12228"
               },
               new UserCatalog
               {
                   Capital = 400.10,
                   Name = "Randi",
                   Id = "3",
                   ShareIds = "12229"
               }
               );

        }

    }
}
