using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BrokerService.Controllers.Requests;
using BrokerService.Controllers.Responses;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BrokerService.Clients
{
    public class ShareCatalogClient
    {
        public HttpClient _client;

        public ShareCatalogClient(HttpClient client)
        {
            client.BaseAddress = new Uri("Skriv sti til client"); //TODO: update base address
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
        }

        public async Task<ActionResult<ShareCatalogResponse>> GetShareInformation(string shareId)
        {
            var httpContent = new StringContent(shareId);
            var responseString = await _client.GetAsync(_client.BaseAddress + "getShareInfo/" + httpContent); //TODO: skriv korrekt url!
            var share = JsonConvert.DeserializeObject<ShareCatalogResponse>(responseString.ToString());

            return share;
        }

        public async Task<ActionResult<ShareCatalogResponse>> SetShareForSale(ShareCatalogRequest request)
        {
            var httpContent = new StringContent(JsonConvert.SerializeObject(request));
            var responseString = await _client.PostAsync(_client.BaseAddress + "updateShare/", httpContent); //TODO: skriv korrekt url!
            var share = JsonConvert.DeserializeObject<ShareCatalogResponse>(responseString.ToString());

            return share;
        }
    }
}
