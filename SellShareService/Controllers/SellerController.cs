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
        private readonly BrokerClient _brokerClient;
        private readonly FrontendClient _frontendClient;

        public SellerController(BrokerClient brokerClient, FrontendClient frontendClient)
        {
            _brokerClient = brokerClient;
            _frontendClient = frontendClient;
        }

        [HttpGet]
        public async Task<ActionResult<string>> Ping()
        {
            Console.WriteLine("You have now hit the Seller Service");
            return Ok("You have now hit the Seller Service");
        }

        [HttpPost("{shareId}")]
        public async Task<ActionResult<BrokerClient>> SellShareRequestToBroker([FromRoute]string shareId)
        {
            try
            {
                await _brokerClient.brokerRequest(shareId);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: ", e);
            }

            return Ok();

        }

        [HttpPost("frontendResponse")]
        public async Task<ActionResult<StatusCodeResult>> sellerShareResponseToFrontend([FromBody] BrokerRequest response)
        {
            try
            {
                //var brokerResponse = await _brokerClient.GetResponseFromBroker(response);

                //if (brokerResponse == null)
                //{
                //    throw new Exception("The share is not for sale!");
                //}

                var sendingResponseToFrontend = new FrontendResponse
                {
                    ShareId = response.ShareId,
                    SellerId = response.SellerId,
                    BuyerId = response.BuyerId,
                    Price = response.Price

                };

                await _frontendClient.frontendResponse(sendingResponseToFrontend);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: ", e);
            }

            return Ok();
        }
    }

}

