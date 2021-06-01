using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.StaticFiles.Infrastructure;

namespace TransactionService.Model
{
    public class Transaction
    {
        public string Id { get; set; }
        public string BuyerId { get; set; }
        public string SellerId { get; set; }
        public DateTime TimeOfTransaction { get; set; }
        public string ShareId { get; set; }
        public double Tax { get; set; }
        public double ShareValue { get; set; }
        public double Price { get; set; }
    }
}
