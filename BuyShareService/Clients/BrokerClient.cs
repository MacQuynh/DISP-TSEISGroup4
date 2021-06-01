using BuyShareService.Controllers.Request;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace BuyShareService.Clients
{
    public class BrokerClient
    {
        public HttpClient _client { get; }

        public BrokerClient(HttpClient client)
        {
            client.BaseAddress = new Uri("https://grp4broker-service:8888/api/broker"); //TODO: Update Path
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
            var reponseToFrontend = JsonConvert.DeserializeObject<BrokerRequest>(responseString.ToString());

            return reponseToFrontend;
        }

        public async Task<ActionResult<string>> brokerTesting()
        {
            var responseString = await _client.GetAsync(_client.BaseAddress);
            var responseFromBroker = responseString.ToString();

            return responseFromBroker;
        }
    }
}
