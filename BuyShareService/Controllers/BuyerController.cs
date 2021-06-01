using BuyShareService.Clients;
using BuyShareService.Controllers.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace BuyShareService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyerController : Controller
    {
        private readonly BrokerClient _brokerClient;

        public BuyerController(BrokerClient brokerClient)
        {
            _brokerClient = brokerClient;
        }

        [HttpGet]
        public async Task<ActionResult<string>> Ping()
        {
            Console.WriteLine("You have now hit the Buyer Service");
            return Ok("You have now hit the Buyer Service");
        }

        [HttpGet("buy")]
        public async Task<ActionResult<string>> GetBroker()
        {
            var brokerResponse = await _brokerClient.brokerTesting();
            return brokerResponse;
        }

        [HttpPost("buyShare")]
        public async Task<ActionResult<BrokerRequest>> BuyShareRequester ([FromBody] BuyShareRequest request) 
        {

            // Making a request to broker: 
            try
            {

                var brokerRequest = new BrokerRequest
                {
                    BuyerId = request.BuyerId,
                    ShareId = request.ShareId
                };

                await _brokerClient.BuyingRequest(brokerRequest);

            }
            catch (Exception e)
            {

                Console.WriteLine("Exception: ", e);
            }

            var frontendRequest = new BrokerRequest { BuyerId = request.BuyerId, ShareId = request.ShareId };
            ActionResult<BrokerRequest> response = null;
            try
            {
                response = await _brokerClient.FrontendResponse(frontendRequest);
            }
            catch (Exception e)
            {

                Console.WriteLine("Exception caught: ", e); ;
            }

            return Ok(frontendRequest);

        }
    }
}
