using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserCatalogService.Controllers.Requests
{
    public class UpdateUserRequest
    {
        public string UserId { get; set; }
        public string ShareId { get; set; }
        public double Price { get; set; }
    }
}
