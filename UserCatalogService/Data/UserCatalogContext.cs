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
                   Capital = 200.10,
                   Name = "Trang",
                   Id = "1",
                   ShareIds = "123456,162535"
               },
               new UserCatalog
               {
                   Capital = 300.10,
                   Name = "Mads",
                   Id = "2",
                   ShareIds = "123457,162536"
               },
               new UserCatalog
               {
                   Capital = 400.10,
                   Name = "Randi",
                   Id = "3",
                   ShareIds = "123458,162537"
               },
               new UserCatalog
               {
                   Capital = 100.10,
                   Name = "Alexander",
                   Id = "4",
                   ShareIds = "123459,615243"
               },
               new UserCatalog
               {
                   Capital = 50.10,
                   Name = "Jonas",
                   Id = "5",
                   ShareIds = "123460,615244"
               },
               new UserCatalog
               {
                   Capital = 700.60,
                   Name = "Thanh",
                   Id = "6",
                   ShareIds = "654321,615245"
               },
               new UserCatalog
               {
                   Capital = 1000.80,
                   Name = "Nikolaj",
                   Id = "7",
                   ShareIds = "654322,615246"
               }, 
               new UserCatalog
               {
                   Capital = 109.80,
                   Name = "Frank",
                   Id = "8",
                   ShareIds = "654323"
               },
               new UserCatalog
               {
                   Capital = 1650.77,
                   Name = "Poul",
                   Id = "9",
                   ShareIds = "654324"
               },
               new UserCatalog
               {
                   Capital = 980.60,
                   Name = "Jenny",
                   Id = "10",
                   ShareIds = "162534"
               }

               );

        }

    }
}
