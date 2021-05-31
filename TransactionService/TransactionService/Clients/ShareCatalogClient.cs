using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TransactionService.Controllers.Requests;

namespace TransactionService.Clients
{
    public class ShareCatalogClient
    {
        public HttpClient _client { get; }

        public ShareCatalogClient(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:44363/api/sharecatalog"); //TODO: update base address
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
        }

        public async Task SendUpdateOwnerToShareCatalog(UpdateShareCatalogRequest request)
        {
            var httpContent = new StringContent(JsonConvert.SerializeObject(request));
            await _client.PostAsync(_client.BaseAddress + "updateShare/", httpContent); //TODO: skriv korrekt url!
        }
    }
}
