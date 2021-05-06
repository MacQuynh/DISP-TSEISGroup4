using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserCatalogService.Model
{
    public class UserCatalog
    {
        public float Capital { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public List<Stock> StockList { get; set; }
    }

    public class Stock
    {
        public string stockName { get; set; }
        public string Id { get; set; }
    }
}
