using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShareCatalogService.Models;

namespace ShareCatalogService.Data
{
	public class ShareCatalogContext : DbContext
	{
		public ShareCatalogContext(DbContextOptions<ShareCatalogContext> options)
			: base(options)
		{
		}

		public DbSet<ShareCatalog> Shares {get; set;}


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ShareCatalog>().HasData(
				new ShareCatalog
				{
					Id = "123456",
					Name = "AP. Møller",
					userId = "Mads Mikkelsen", 
					Value = 100, 
					ForSale = false,
					Tax = 1,
				});
		}
	}
}
