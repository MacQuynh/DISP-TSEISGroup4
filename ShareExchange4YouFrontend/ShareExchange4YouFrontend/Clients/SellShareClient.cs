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
    public class SellShareClient
    {
        private readonly HttpClient _client;
        public SellShareClient(HttpClient client)
        {
            //client.BaseAddress = new Uri("https://localhost:44341/api/seller"); //TODO: Update
            client.BaseAddress = new Uri("http://grp4sellshare-service:8888/api/seller"); //TODO: Update
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
        }

        public async Task<ActionResult<SellShareResponse>> SellShare(SellShareRequest request)
        {
            var httpContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var responseString = await _client.PostAsync(_client.BaseAddress, httpContent);
            var result = responseString.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<SellShareResponse>(result.Result);

            return response;
        }
    }
}
