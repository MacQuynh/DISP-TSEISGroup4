using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyShareService.Controllers.Request
{
    public class BrokerRequest
    {
        public string ShareId { get; set; }
        public string BuyerId { get; set; }
    }
}
