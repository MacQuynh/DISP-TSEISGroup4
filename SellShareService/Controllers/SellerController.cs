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

        [HttpPost("validateSeller")]
        public async Task<ActionResult> validateSeller([FromBody] UserCatalogRequest request)
        {
            try
            {
                var validateSellerRequest = new UserCatalogRequest
                {
                    SellerId = request.SellerId,
                    ShareId = request.ShareId
                };

                await _userCatalogClient.ValidateSeller(validateSellerRequest);
            }
            catch (Exception e)
            {
                throw new Exception("Exception: ", e);
            }

            return Ok();
        }

        [HttpPost("{shareId}")]
        public async Task<ActionResult<string>> SellShareRequestToBroker([FromRoute] string shareId)
        {
            ActionResult<string> request = "";
            try
            {
                request = await _brokerClient.brokerRequest(shareId);

            }
            catch (Exception e)
            {
                throw new Exception("Exception: ", e);
            }
            return Ok(request);


        }
    }

}

