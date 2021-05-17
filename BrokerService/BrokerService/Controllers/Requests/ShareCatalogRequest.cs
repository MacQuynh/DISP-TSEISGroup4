using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrokerService.Controllers.Requests
{
    public class ShareCatalogRequest
    {
        public string ShareId { get; set; }
        public string SellerId { get; set; }
    }
}
