using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BrokerService.Controllers.Requests;
using Newtonsoft.Json;

namespace BrokerService.Clients
{
    public class SellShareClient
    {
        private readonly HttpClient _client;

        public SellShareClient(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:44358/api/seller"); 
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
        }
        public async Task TellSellerShareIsSold(ShareIsSoldRequest request)
        {
            var httpContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(_client.BaseAddress + "/shareSold", httpContent);
        }
    }
}
