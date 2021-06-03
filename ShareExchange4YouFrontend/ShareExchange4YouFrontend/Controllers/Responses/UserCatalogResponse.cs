using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareExchange4YouFrontend.Controllers.Responses
{
    public class UserCatalogResponse
    {
        public double Capital { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public string ShareIds { get; set; }
    }
}
