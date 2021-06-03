using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellShareService.Controllers.Request
{
    public class UserCatalogRequest
    {
        public string SellerId { get; set; }
        public string ShareId { get; set; }
    }
}
