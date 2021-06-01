using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrokerService.Controllers.Requests
{
    public class ShareIsSoldRequest
    {
        public string ShareId { get; set; }
        public string BuyerId { get; set; }
        public string SellerId { get; set; }
        public double Price { get; set; }
    }
}
