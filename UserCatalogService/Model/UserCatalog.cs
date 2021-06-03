using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace UserCatalogService.Model
{
    public class UserCatalog
    {
        public double Capital { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public string ShareIds { get; set; }
    }

    

}
