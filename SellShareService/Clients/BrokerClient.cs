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
            client.BaseAddress = new Uri("http://grp4broker-service:8888/api/broker"); 
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
        }

        public async Task<ActionResult<string>> brokerRequest(string shareId)
        {
            var brokerRequest = await _client.PostAsync(_client.BaseAddress + "/sellShare/" + shareId, null);
            var request = brokerRequest.ToString();
            return request;

        }

    }
}
