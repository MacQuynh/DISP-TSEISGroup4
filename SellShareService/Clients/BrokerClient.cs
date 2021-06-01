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
    public class BrokerClient
    {
        public HttpClient _client { get; }

        public BrokerClient(HttpClient client)
        {
            client.BaseAddress = new Uri("https://grp4broker-service:8888/api/broker"); 
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
        }

        /*Insert the request to BrokerClient*/
        public async Task<ActionResult<BrokerClient>> brokerRequest(string shareId)
        {
            var brokerRequest = await _client.PostAsync(_client.BaseAddress + "/"+ shareId, null);
            var request = JsonConvert.DeserializeObject<BrokerClient>(brokerRequest.ToString());

            return request;

        }

        //internal Task GetResponseFromBroker(BrokerRequest response)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
