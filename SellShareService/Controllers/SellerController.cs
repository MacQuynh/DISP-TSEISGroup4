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
        private readonly FrontendClient _frontendClient;

        public SellerController(BrokerClient brokerClient, FrontendClient frontendClient, UserCatalogClient userCatalogClient)
        {
            _userCatalogClient = userCatalogClient;
            _brokerClient = brokerClient;
            _frontendClient = frontendClient;
        }

        [HttpGet]
        public async Task<ActionResult<string>> Ping()
        {
            Console.WriteLine("You have now hit the Seller Service");
            return Ok("You have now hit the Seller Service");
        }

        [HttpGet("validateSeller")]
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
                Console.WriteLine("Exception: ", e);
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
                Console.WriteLine("Exception: ", e);
            }
            return Ok(request);


        }

        [HttpPost("shareSold")]
        public async Task<ActionResult> sellerShareResponseToFrontend([FromBody] BrokerRequest response)
        {
            try
            {
                var sendingResponseToFrontend = new FrontendResponse
                {
                    ShareId = response.ShareId,
                    SellerId = response.SellerId,
                    BuyerId = response.BuyerId,
                    Price = response.Price

                };

                await _frontendClient.frontendResponse(sendingResponseToFrontend);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: ", e);
            }

            return Ok();
        }
    }

}

