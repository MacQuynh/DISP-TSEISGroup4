using ShareCatalogService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Text.Json;
using ShareCatalogService.Controllers.Requests;
using ShareCatalogService.Controllers.Responses;


namespace ShareCatalogService.Clients
{
	public class TobinTaxingClient
	{
		private readonly HttpClient _client;

		public TobinTaxingClient(HttpClient client)
		{
			client.BaseAddress = new Uri("https://localhost:44387/api/TobinTaxing"); // TODO update base address
			client.DefaultRequestHeaders.Add("Accept","application/json");
			_client = client;
		}

		public async Task<TaxResponse> CalculateTaxForShare(TobinTaxingRequest request)
		{
			var httpContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
			//var httpContent = JsonConvert.SerializeObject(request);

			var response = await _client.PostAsync(_client.BaseAddress + "/calculateTax", httpContent); // TODO: skriv korrekt url!
			string result = response.Content.ReadAsStringAsync().Result;

			var responseItem = JsonConvert.DeserializeObject<TaxResponse>(result);
			return responseItem;
		}

	}
}
