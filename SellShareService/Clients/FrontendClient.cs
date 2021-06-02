using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SellShareService.Controllers.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SellShareService.Clients
{
    public class FrontendClient
    {
        public HttpClient _client { get; }
        public FrontendClient(HttpClient client)
        {
            client.BaseAddress = new Uri("https://XX:8888/api/frontend"); // --Insert the correct url
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
        }

        public async Task frontendResponse(FrontendResponse response)
        {
            var httpContent = new StringContent(JsonConvert.SerializeObject(response), Encoding.UTF8, "application/json");
            var reponseToFrontend = await _client.PostAsync(_client.BaseAddress + "/XX", httpContent);
        }
    }
}
