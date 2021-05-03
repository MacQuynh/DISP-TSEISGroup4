using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareCatalogService.Model
{
	public class ShareCatalog
	{

		public string Name { get; set; }

		public string Id {get; set;}

		public User Owner {get; set;}

		public float Value {get; set;}

		public float Tax {get; set;}

		public bool ForSale {get; set;}

	}


	public class User
	{
		public string Id {get; set;}

		public string Name {get; set;}

	}
}
