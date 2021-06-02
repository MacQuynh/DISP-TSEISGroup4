using BuyShareService.Controllers.Request;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BuyShareService.Clients
{
    public class BrokerClient
    {
        public HttpClient _client { get; }

        public BrokerClient(HttpClient client)
        {
            client.BaseAddress = new Uri("http://localhost:44350/api/broker");
            //client.BaseAddress = new Uri("http://grp4broker-service:8888/api/broker"); 
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
        }

        //Init the transaction for buying
        public async Task<ActionResult<string>> BuyingRequest(BrokerRequest request)
        {
            var httpContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(_client.BaseAddress + "/buyShare", httpContent);
            var result = response.Content.ReadAsStringAsync().Result;

            return result;
        }


        public async Task<ActionResult<string>> brokerTesting()
        {
            var responseString = await _client.GetAsync(_client.BaseAddress);
            var responseFromBroker = responseString.ToString();

            return responseFromBroker;
        }
    }
}
