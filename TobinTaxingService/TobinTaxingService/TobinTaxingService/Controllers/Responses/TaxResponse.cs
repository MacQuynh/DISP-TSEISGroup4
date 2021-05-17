using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TobinTaxingService.Controllers.Responses
{
	public class TaxResponse
	{
		public string ShareId {get; set;}
		public double TaxValue {get; set;}
	}
}
