using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShareExchange4YouFrontend.Controllers.Responses;

namespace ShareExchange4YouFrontend.Clients
{
    public class UserCatalogClient
    {
        private readonly HttpClient _client;
        public UserCatalogClient(HttpClient client)
        {
            client.BaseAddress = new Uri("https://grp4usercatalog-service:8888/api/userCatalog");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
        }

        public async Task<IReadOnlyCollection<UserCatalogResponse>> GetUsers()
        {
            var responseString = await _client.GetAsync(_client.BaseAddress);
            var result = responseString.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<IReadOnlyCollection<UserCatalogResponse>>(result.Result);

            return users;
        }
    }
}
