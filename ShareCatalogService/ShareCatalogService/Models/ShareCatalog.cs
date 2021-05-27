using System;
using Microsoft.AspNetCore.Identity;

namespace ShareCatalogService.Models
{
	public class ShareCatalog
	{

		public string Id {get; set;}

		public string Name { get; set; }

		public string UserId {get; set;}

		public float Value {get; set;}

		public float Tax {get; set;}

		public bool ForSale {get; set;}

	}

}
