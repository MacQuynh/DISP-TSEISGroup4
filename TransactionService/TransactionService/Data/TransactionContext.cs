using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TransactionService.Model;

namespace TransactionService.Data
{
    public class TransactionContext : DbContext
    {
        public TransactionContext(DbContextOptions<TransactionContext> options)
            : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Transaction>().HasData(
                new Transaction
                {
                    BuyerId = "1", 
                    Id = "1", 
                    Price = 15.00,
                    SellerId = "2", 
                    ShareValue = 10.00, 
                    Tax = 5.00,
                    TimeOfTransaction = new DateTime(2021, 05, 06), 
                    ShareId = "1"
                }
            );
        }
    }
}
