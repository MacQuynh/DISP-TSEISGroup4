using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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
            client.BaseAddress = new Uri("http://grp4-sharecatalog-service:8888/api/sharecatalog"); 
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
        }

        public async Task UpdateOwner(UpdateShareCatalogRequest request)
        {
            var httpContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync(_client.BaseAddress + "/UpdateShareOwner", httpContent); 
        }
    }
}
