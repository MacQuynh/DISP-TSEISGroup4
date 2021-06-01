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
            client.BaseAddress = new Uri("http://grp4-sharecatalog-service:8888/api/ShareCatalog"); 
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
        }

        public async Task<ActionResult<ShareCatalogResponse>> GetShareInformation(string shareId)
        {
            var responseString = await _client.GetAsync(_client.BaseAddress + "/" + shareId);
            var result = responseString.Content.ReadAsStringAsync();
            var share = JsonConvert.DeserializeObject<ShareCatalogResponse>(result.Result);

            return share;
        }

        public async Task<ActionResult<string>> SetShareForSale(string shareId)
        {
            var responseString = await _client.PutAsync(_client.BaseAddress + "/updateShareForSale/" + shareId, null); 
            var share = responseString.ToString();

            return share;
        }
    }
}
