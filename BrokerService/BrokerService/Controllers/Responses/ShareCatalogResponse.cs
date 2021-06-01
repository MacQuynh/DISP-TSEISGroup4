using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrokerService.Controllers.Responses
{
    public class ShareCatalogResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public double Value { get; set; }
        public int Tax { get; set; }
        public bool ForSale { get; set; }
    }

    public class Owner
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
