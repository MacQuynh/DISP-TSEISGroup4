using System;
using System.Net.Http;
using System.Text;
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
            client.BaseAddress = new Uri("http://grp4transaction-service:8888/api/transactions"); 
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
        }

        public async Task MakeTransaction(TransactionRequest request)
        {
            var httpContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(_client.BaseAddress, httpContent); 
        }
    }
}
