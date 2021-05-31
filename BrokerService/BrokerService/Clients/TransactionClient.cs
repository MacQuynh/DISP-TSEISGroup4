using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BrokerService.Controllers.Requests;
using Newtonsoft.Json;

namespace BrokerService.Clients
{
    public class TransactionClient
    {
        public HttpClient _client;

        public TransactionClient(HttpClient client)
        {
            client.BaseAddress = new Uri("https://grp4transaction-service:8888/api/transactions"); //TODO: update base address
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
        }

        public async Task MakeTransaction(TransactionRequest request)
        {
            var httpContent = new StringContent(JsonConvert.SerializeObject(request));
            await _client.PostAsync(_client.BaseAddress + "TransactionOfShare/", httpContent); 
        }
    }
}
