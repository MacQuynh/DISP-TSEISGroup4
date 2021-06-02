using System;
using System.Threading.Tasks;
using BrokerService.Clients;
using BrokerService.Controllers.Requests;
using Microsoft.AspNetCore.Mvc;

namespace BrokerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrokerController : Controller
    {
        private readonly ShareCatalogClient _shareCatalogClient;
        private readonly TransactionClient _transactionClient;

        public BrokerController(ShareCatalogClient shareCatalogClient, TransactionClient transactionClient)
        {
            _shareCatalogClient = shareCatalogClient;
            _transactionClient = transactionClient;
        }

        [HttpGet]
        public async Task<ActionResult<string>> Ping()
        {
            Console.WriteLine("You have now hit the Broker Service!");
            return Ok("You have now hit the Broker Service!");
        }

        [HttpPost("buyShare")]
        public async Task<ActionResult> BuyShareRequest([FromBody] BuyShareRequest request)
        {
            try
            {
                var shareResponse = await _shareCatalogClient.GetShareInformation(request.ShareId);
                if (!shareResponse.Value.ForSale)
                {
                    NotFound("The share is not for sale!");
                }

                var transactionRequest = new TransactionRequest
                {
                    BuyerId = request.BuyerId,
                    SellerId = shareResponse.Value.UserId,
                    ShareId = request.ShareId,
                    ShareValue = shareResponse.Value.Value,
                    Tax = shareResponse.Value.Tax,
                    Price = shareResponse.Value.Value + shareResponse.Value.Tax
                };

                await _transactionClient.MakeTransaction(transactionRequest);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught: ", e);
                throw new Exception("Exception caught: ", e);
            }

            return Ok();
        }

        [HttpPost("sellShare/{shareId}")]
        public async Task<IActionResult> SellShareRequest([FromRoute] string shareId)
        {
            try
            {
                await _shareCatalogClient.SetShareForSale(shareId);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught: ", e);
                throw new Exception("Exception caught: ", e);
            }

            return Ok();
        }
    }
}
