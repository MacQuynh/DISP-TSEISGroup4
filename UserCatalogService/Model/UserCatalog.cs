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
        public List<Share> Shares { get; set; }
    }

    public class Share
    {
        public string Id { get; set; }
        public string UserCatalogId { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public UserCatalog UserCatalog { get; set; }
    }

}
