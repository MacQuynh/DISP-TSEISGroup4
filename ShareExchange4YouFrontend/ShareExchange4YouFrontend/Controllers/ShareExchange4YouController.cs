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
    [Route("api/[Controller]")]
    [ApiController]
    public class ShareExchange4YouController : Controller
    {
        private readonly ShareCatalogClient _shareCatalogClient;
        private readonly BuyShareClient _buyShareClient;
        private readonly UserCatalogClient _userCatalogClient;
        private readonly SellShareClient _sellShareClient;

        public ShareExchange4YouController(ShareCatalogClient shareCatalogClient, BuyShareClient buyShareClient, UserCatalogClient userCatalogClient, SellShareClient sellShareClient)
        {
            _shareCatalogClient = shareCatalogClient;
            _buyShareClient = buyShareClient;
            _userCatalogClient = userCatalogClient;
            _sellShareClient = sellShareClient;
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

        [HttpPost("SellShare")]
        public async Task<ActionResult<SellShareResponse>> SellShare([FromBody] SellShareRequest request)
        {
	        var response = await _sellShareClient.SellShare(request);
	        return response;
        }

        [HttpGet("GetSharesForsale")]
        public async Task<IReadOnlyCollection<ShareResponse>> GetSharesForsale()
        {
	        var shares = await _shareCatalogClient.GetSharesForsale();
	        return shares;
        }

    }
}
