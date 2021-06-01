using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TransactionService.Controllers.Requests;
using TransactionService.Model;

namespace TransactionService.Clients
{
    public class UserCatalogClient 
    {
        public HttpClient _client { get; }

        public UserCatalogClient(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:44363/api/usercatalog"); //TODO: Update baseaddress
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
        }

        public async Task SendUpdateForBuyerToUserCatalog(UpdateUserCatalogRequest request)
        {
            var httpContent = new StringContent(JsonConvert.SerializeObject(request)); 
            await _client.PostAsync(_client.BaseAddress + "validatebuyer/", httpContent); //TODO: skriv korrekt url!
        }

        public async Task SendUpdateForSellerToUserCatalog(UpdateUserCatalogRequest request)
        {
            var httpContent = new StringContent(JsonConvert.SerializeObject(request));
            await _client.PostAsync(_client.BaseAddress + "validatebuyer/", httpContent); //TODO: skriv korrekt url!
        }


    }
}
