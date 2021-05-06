using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserCatalogService.Model;

namespace UserCatalogService.Data
{
    public class UserCatalogContext : DbContext
    {
        public UserCatalogContext (DbContextOptions<UserCatalogContext> options) 
            : base(options)
        {

        }

        public DbSet<Model.UserCatalog> UserCatalog { get; set; }
        public DbSet<Model.Stock> Stock { get; set; }

    }
}
