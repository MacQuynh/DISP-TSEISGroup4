using BuyShareService.Controllers.Request;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BuyShareService.Clients
{
    public class BrokerClient
    {
        public HttpClient _client;

        public BrokerClient(HttpClient client)
        {
            client.BaseAddress = new Uri("http://grp4broker-service:8888/api/broker"); //TODO: Update Path
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
        }

        //Init the transaction for buying
        public async Task BuyingRequest(BrokerRequest request)
        {
            var httpContent = new StringContent(JsonConvert.SerializeObject(request));
            await _client.PostAsync(_client.BaseAddress + "BuyingOfShare/", httpContent);

        }

        public async Task<ActionResult<BrokerRequest>> FrontendResponse(BrokerRequest response)
        {
            var httpContent = new StringContent(JsonConvert.SerializeObject(response));
            var responseString = await _client.PostAsync(_client.BaseAddress + "sendResponseToFrontend", httpContent);
            var reponseToFrontned = JsonConvert.DeserializeObject<BrokerRequest>(responseString.ToString());

            return reponseToFrontned;
        }

        public async Task<string> brokerTesting()
        {
            var requestString = await _client.GetAsync(_client.BaseAddress);
            var requestToBroker = JsonConvert.DeserializeObject<string>(requestString.ToString());

            return requestToBroker;
        }
    }
}
