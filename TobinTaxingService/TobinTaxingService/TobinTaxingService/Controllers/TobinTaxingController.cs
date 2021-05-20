using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TobinTaxingService.Controllers.Requests;
using TobinTaxingService.Controllers.Responses;
using TobinTaxingService.Models;

namespace TobinTaxingService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TobinTaxingController: ControllerBase
	{

		private readonly double _taxRate = 0.01;

		//public TobinTaxingController()
		//{
			
		//}

		[HttpGet]
		public ActionResult<TaxResponse> GetTax([FromBody] TaxRequest request)
		{

			TaxResponse taxResponse = new TaxResponse
			{
				ShareId = request.ShareId,
				TaxValue = request.ShareValue * _taxRate
			};
			
			//var response = JsonConvert.DeserializeObject<TaxResponse>(taxResponse.ToString());
			return taxResponse;
		}
	}
}
