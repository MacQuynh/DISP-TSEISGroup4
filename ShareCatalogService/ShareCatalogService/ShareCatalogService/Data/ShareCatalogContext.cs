using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShareCatalogService.Models;

namespace ShareCatalogService.Data
{
	public class ShareCatalogContext: DbContext
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
					Id = "123456", Name = "AP. Møller", UserId = "Mads Mikkelsen", Value = 1000, ForSale = false, Tax = 0
				},
				new ShareCatalog
				{
					Id = "123457", Name = "Carlsberg", UserId = "Mads Mikkelsen", Value = 100, ForSale = true, Tax = 1
				},
				new ShareCatalog
					{Id = "123357", Name = "AP. Møller", UserId = "Randi", Value = 1000, ForSale = true, Tax = 10},
				new ShareCatalog
					{Id = "122257", Name = "AP. Møller", UserId = "Trang", Value = 1000, ForSale = true, Tax = 10},
				new ShareCatalog
					{Id = "123227", Name = "Carlsberg", UserId = "Trang", Value = 100, ForSale = false, Tax = 0}
			);
		}
	}
}
