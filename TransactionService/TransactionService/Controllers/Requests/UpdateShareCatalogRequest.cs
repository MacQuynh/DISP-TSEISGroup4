using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransactionService.Controllers.Requests
{
    public class UpdateShareCatalogRequest
    {
        public string ShareId { get; set; }
        public string NewOwnerId { get; set; }
    }
}
