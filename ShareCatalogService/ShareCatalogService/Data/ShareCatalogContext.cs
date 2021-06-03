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
				{Id = "123456", Name = "AP. Møller", UserId = "1", Value = 1000, ForSale = false, Tax = 0},
				new ShareCatalog
				{Id = "123457", Name = "AP. Møller", UserId = "2", Value = 1000, ForSale = false, Tax = 0},
				new ShareCatalog
				{Id = "123458", Name = "AP. Møller", UserId = "3", Value = 1000, ForSale = false, Tax = 0},
				new ShareCatalog
				{Id = "123459", Name = "AP. Møller", UserId = "4", Value = 1000, ForSale = false, Tax = 0},
				new ShareCatalog
				{Id = "123460", Name = "AP. Møller", UserId = "5", Value = 1000, ForSale = false, Tax = 0},
				new ShareCatalog
				{Id = "654321", Name = "Carlsberg", UserId = "6", Value = 100, ForSale = false, Tax = 0},
				new ShareCatalog
				{Id = "654322", Name = "Carlsberg", UserId = "7", Value = 100, ForSale = false, Tax = 0},
				new ShareCatalog
				{Id = "654323", Name = "Carlsberg", UserId = "8", Value = 100, ForSale = false, Tax = 0},
				new ShareCatalog
				{ Id = "654324", Name = "Carlsberg", UserId = "9", Value = 100, ForSale = false, Tax = 0},
				new ShareCatalog
					{Id = "162534", Name = "Salling Group", UserId = "10", Value = 340, ForSale = false, Tax = 0},
				new ShareCatalog
				{ Id = "162535",Name = "Salling Group",UserId = "1",Value = 340,ForSale = false,Tax = 0 },
				new ShareCatalog
				{ Id = "162536",Name = "Salling Group",UserId = "2",Value = 340,ForSale = false,Tax = 0 },
				new ShareCatalog
				{ Id = "162537",Name = "Salling Group",UserId = "3",Value = 340,ForSale = false,Tax = 0 },
				new ShareCatalog
				{ Id = "615243",Name = "Norwegian",UserId = "4",Value = 7,ForSale = false,Tax = 0 },
				new ShareCatalog
				{ Id = "615244",Name = "Norwegian",UserId = "5",Value = 7,ForSale = false,Tax = 0 },
				new ShareCatalog
				{ Id = "615245",Name = "Norwegian",UserId = "6",Value = 7,ForSale = false,Tax = 0 },
				new ShareCatalog
				{ Id = "615246",Name = "Norwegian",UserId = "7",Value = 7,ForSale = false,Tax = 0 }
			);
		}
	}
}
