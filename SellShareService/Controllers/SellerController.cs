using Microsoft.AspNetCore.Mvc;
using SellShareService.Clients;
using SellShareService.Controllers.Request;
using System;
using System.Threading.Tasks;

namespace SellShareService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly UserCatalogClient _userCatalogClient;
        private readonly BrokerClient _brokerClient;

        public SellerController(BrokerClient brokerClient, UserCatalogClient userCatalogClient)
        {
            _userCatalogClient = userCatalogClient;
            _brokerClient = brokerClient;
        }

        [HttpGet]
        public async Task<ActionResult<string>> Ping()
        {
            Console.WriteLine("You have now hit the Seller Service");
            return Ok("You have now hit the Seller Service");
        }


        [HttpPost]
        public async Task<ActionResult<string>> SellShareRequestToBroker([FromBody] UserCatalogRequest request)
        {
            ActionResult<string> response = "";
            try
            {
                var validateSellerRequest = new UserCatalogRequest
                {
                    SellerId = request.SellerId,
                    ShareId = request.ShareId
                };

                await _userCatalogClient.ValidateSeller(validateSellerRequest);

                response = await _brokerClient.brokerRequest(request.ShareId);

            }
            catch (Exception e)
            {
                throw new Exception("Exception: ", e);
            }
            return Ok(response);


        }
    }

}

