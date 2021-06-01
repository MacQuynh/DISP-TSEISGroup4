using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareExchange4YouFrontend.Controllers.Responses
{
    public class ShareResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public float Value { get; set; }
        public float Tax { get; set; }
        public bool ForSale { get; set; }
	}
}
