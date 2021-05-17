using ShareCatalogService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
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
			client.BaseAddress = new Uri("skriv til client"); // TODO update base address
			client.DefaultRequestHeaders.Add("Accept", "application/json");
			_client = client;
		}

		public async Task<TaxResponse> GetTaxForShare(TobinTaxingRequest request)
		{
			var httpContent = new StringContent(request.ToString());

			var responseString = await _client.GetStringAsync(_client.BaseAddress + "getTax/" + httpContent); // TODO: skriv korrekt url!
			var responseItem = JsonConvert.DeserializeObject<TaxResponse>(responseString);

			return responseItem;
			
		}

	}
}
