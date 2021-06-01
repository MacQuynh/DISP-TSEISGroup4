using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShareExchange4YouFrontend.Clients;
using ShareExchange4YouFrontend.Controllers.Requests;
using ShareExchange4YouFrontend.Controllers.Responses;

namespace ShareExchange4YouFrontend.Controllers
{
    public class ShareExchange4YouController : Controller
    {
        private readonly ShareCatalogClient _shareCatalogClient;
        private readonly BuyShareClient _buyShareClient;
        private readonly UserCatalogClient _userCatalogClient;

        public ShareExchange4YouController(ShareCatalogClient shareCatalogClient, BuyShareClient buyShareClient, UserCatalogClient userCatalogClient)
        {
            _shareCatalogClient = shareCatalogClient;
            _buyShareClient = buyShareClient;
            _userCatalogClient = userCatalogClient;
        }

        [HttpGet("GetShares")]
        public async Task<IReadOnlyCollection<ShareResponse>> GetShares()
        {
            var shares = await _shareCatalogClient.GetShares();
            return shares;
        }

        [HttpGet("GetUsers")]
        public async Task<IReadOnlyCollection<UserCatalogResponse>> GetUsers()
        {
            var users = await _userCatalogClient.GetUsers();
            return users;
        }

        [HttpPost("BuyShare")]
        public async Task<ActionResult<BuyShareResponse>> BuyShare([FromBody] BuyShareRequest request)
        {
            var response = await _buyShareClient.BuyShare(request);
            return response;
        }

        //TODO: make endpoint for sellShare
    }
}
