using BuyShareService.Clients;
using BuyShareService.Controllers.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BuyShareService.Properties
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

        [HttpPost("/buyShare")]
        public async Task<ActionResult<BrokerRequest>> BuyShareRequester (string buyerId, string shareId) 
        {

            // Making a request to broker: 
            try
            {

                var brokerRequest = new BrokerRequest
                {
                    BuyerId = buyerId,
                    ShareId = shareId
                };

                await _brokerClient.BuyingRequest(brokerRequest);

            }
            catch (Exception e)
            {

                Console.WriteLine("Exception: ", e);
            }

            var frontendRequest = new BrokerRequest { BuyerId = buyerId, ShareId = shareId };
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
