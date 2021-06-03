using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TransactionService.Controllers.Requests;
using TransactionService.Model;

namespace TransactionService.Clients
{
    public class UserCatalogClient
    {
        public HttpClient _client;

        public UserCatalogClient(HttpClient client)
        {
            client.BaseAddress = new Uri("https://grp4usercatalog-service:8888/api/usercatalog"); 
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
        }

        public async Task<ActionResult<string>> UpdateBuyer(UpdateUserCatalogRequest request)
        {
            var httpContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync(_client.BaseAddress + "/updateBuyer", httpContent); 
            var result = response.Content.ReadAsStringAsync().Result;

            return result;
        }

        public async Task<ActionResult<string>> UpdateSeller(UpdateUserCatalogRequest request)
        {
            var httpContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync(_client.BaseAddress + "/updateSeller", httpContent); 
            var result = response.Content.ReadAsStringAsync().Result;

            return result;
        }


    }
}
