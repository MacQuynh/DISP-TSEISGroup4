using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransactionService.Controllers.Requests
{
    public class TransactionRequest
    {
        public string BuyerId { get; set; }
        public string SellerId { get; set; }
        public string ShareId { get; set; }
        public double Tax { get; set; }
        public double ShareValue { get; set; }
        public double Price { get; set; }
    }
}
