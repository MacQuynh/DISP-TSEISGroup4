using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TobinTaxingService.Controllers.Requests
{
	public class TaxRequest
	{
		public string ShareId {get; set;}

		public double ShareValue {get; set;}
	}
}
