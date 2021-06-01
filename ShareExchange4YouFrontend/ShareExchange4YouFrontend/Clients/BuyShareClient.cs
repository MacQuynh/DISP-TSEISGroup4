using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShareExchange4YouFrontend.Controllers.Requests;
using ShareExchange4YouFrontend.Controllers.Responses;

namespace ShareExchange4YouFrontend.Clients
{
    public class BuyShareClient
    {
        private readonly HttpClient _client;
        public BuyShareClient(HttpClient client)
        {
            client.BaseAddress = new Uri("https://buyservice-service:8888/api/buyer");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
        }

        public async Task<ActionResult<BuyShareResponse>> BuyShare(BuyShareRequest request)
        {
            var httpContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var responseString = await _client.PostAsync(_client.BaseAddress + "/buyShare", httpContent);
            var result = responseString.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<BuyShareResponse>(result.Result);

            return response;
        }
    }
}
 