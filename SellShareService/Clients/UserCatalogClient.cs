using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SellShareService.Controllers.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SellShareService.Clients
{
    public class UserCatalogClient
    {
        public HttpClient _client { get; }

        public UserCatalogClient(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:44363/api/usercatalog"); 
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
        }

        public async Task ValidateSeller(UserCatalogRequest request)
        {
            var httpContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(_client.BaseAddress + "/validateseller", httpContent);
        }
    }
}
