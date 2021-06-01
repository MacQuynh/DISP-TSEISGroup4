using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShareExchange4YouFrontend.Controllers.Responses;

namespace ShareExchange4YouFrontend.Clients
{
    public class ShareCatalogClient
    {
        private readonly HttpClient _client;

        public ShareCatalogClient(HttpClient client)
        {
            client.BaseAddress = new Uri("http://localhost:33567/api/grp4-sharecatalog-service");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client = client;
        }

        public async Task<IReadOnlyCollection<ShareResponse>> GetShares()
        {
            var responseString = await _client.GetAsync(_client.BaseAddress + "/getShares");
            var result = responseString.Content.ReadAsStringAsync();
            var shares = JsonConvert.DeserializeObject<IReadOnlyCollection<ShareResponse>>(result.Result);

            return shares;
        }
    }
}
