using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BrokerService.Clients;
using BrokerService.Controllers.Requests;
using BrokerService.Controllers.Responses;
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
        public async Task<ActionResult<StatusCodeResult>> BuyShareRequest([FromBody] BuyShareRequest request)
        {
            try
            {
                // look up share(s) with Id
                //response: share object
                var shareResponse = await _shareCatalogClient.GetShareInformation(request.ShareId);
                if (!shareResponse.Value.forSale)
                {
                    throw new Exception("The share is not for sale!");
                }

                //make transaction
                //ok respone
                var transactionRequest = new TransactionRequest
                {
                    BuyerId = request.BuyerId,
                    SellerId = shareResponse.Value.Owner.Id,
                    ShareId = request.ShareId,
                    ShareValue = shareResponse.Value.Value,
                    Tax = shareResponse.Value.Tax,
                    Price = shareResponse.Value.Value + shareResponse.Value.Tax
                };

                await _transactionClient.MakeTransaction(transactionRequest);

                //start event for seller to say share is sold
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught: ", e);
            }

            return Ok();
        }

        [HttpPost("sellShare/{shareId}")]
        public async Task<ActionResult<ShareCatalogResponse>> SellShareRequest([FromRoute] string shareId)
        {
            ActionResult<ShareCatalogResponse> response = null;
            try
            {
                response = await _shareCatalogClient.SetShareForSale(shareId);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught: ", e);
            }

            return Ok(response);
        }
    }
}
