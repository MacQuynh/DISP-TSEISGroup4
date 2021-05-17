using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TobinTaxingService.Controllers.Responses;
using TobinTaxingService.Models;

namespace TobinTaxingService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TobinTaxingController: ControllerBase
	{

		private readonly double _taxRate = 0.01; 

		[HttpGet("getTax")]
		public ActionResult<TaxResponse> GetTax(Share share)
		{
			var taxResponse = new TaxResponse
			{
				ShareId = share.ShareId,
				TaxValue = (share.ShareValue *_taxRate),
			};

			return taxResponse;
		}
	}
}
