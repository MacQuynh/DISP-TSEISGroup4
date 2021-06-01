using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SellShareService.Controllers.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SellShareService.Clients
{
    public class FrontendClient
    {
        public HttpClient _client { get; }
        public FrontendClient(HttpClient client)
        {
            client.BaseAddress = new Uri("https://XX:8888/api/broker");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
        }

        public async Task<ActionResult<FrontendResponse>> frontendResponse(FrontendResponse response)
        {
            var httpContent = new StringContent(JsonConvert.SerializeObject(response));
            var responseString = await _client.PostAsync(_client.BaseAddress + "ResponseToFrontend", httpContent);
            var reponseToFrontend = JsonConvert.DeserializeObject<FrontendResponse>(responseString.ToString());

            return reponseToFrontend;
        }
    }
}
