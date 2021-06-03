using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserCatalogService.Controllers.Requests
{
    public class ValidateSellerRequest
    {
        public string SellerId { get; set; }
        public string ShareId { get; set; }
    }
}
