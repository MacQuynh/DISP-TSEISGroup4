using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransactionService.Controllers.Requests
{
    public class UpdateUserCatalogRequest
    {
        public string UserId { get; set; }
        public string ShareId { get; set; }
        public double SharePrice { get; set; }
    }
}
