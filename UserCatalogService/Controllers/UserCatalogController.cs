using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UserCatalogService.Controllers.Requests;
using UserCatalogService.Data;
using UserCatalogService.Model;

namespace UserCatalogService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCatalogController : ControllerBase
    {
        private readonly UserCatalogContext _context;

        public UserCatalogController(UserCatalogContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IReadOnlyCollection<UserCatalog>> GetUsers()
        {
            var users = await Task.FromResult(_context.UserCatalog.ToList());
            return users;
        }

        [HttpGet("validatebuyer/{id}")]
        public async Task<ActionResult<UserCatalog>> GetValidateBuyer([FromRoute]string id)
        {
            var buyer = await Task.FromResult(_context.UserCatalog
              .Where(i => i.Id==id)
              .FirstOrDefault());

            if ( buyer == null)
            {
                return NotFound();
            }

            return buyer;

            //Should also handle validation of kapital. 

        }

        [HttpPost("validateseller")]
        public async Task<ActionResult<UserCatalog>> GetValidateSeller([FromBody] ValidateSellerRequest request)
        {
            var seller = await Task.FromResult(_context.UserCatalog
              .Where(i => i.Id == request.SellerId)
              .FirstOrDefault());

            if (seller == null)
            {
                return NotFound();
            }

            var shareList = seller.ShareIds.Split(",");
            if (!shareList.Contains(request.ShareId))
            {
                return NotFound("Seller does not own the requested shareId");
            }

            return seller;
        }

        [HttpPut("updateBuyer")]
        public async Task<IActionResult> PutBuyer([FromBody] UpdateUserRequest request)
        {
            var buyerToUpdate = await _context.UserCatalog
                .FirstOrDefaultAsync(i => i.Id == request.UserId);

            if (buyerToUpdate == null)
            {
                return NotFound();
            }

            buyerToUpdate.Capital -= request.Price;
            
            var newStrings = buyerToUpdate.ShareIds + "," + request.ShareId;
            buyerToUpdate.ShareIds = newStrings;
            
            try
            {
                _context.UserCatalog.Update(buyerToUpdate);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught: ", e);
                throw new Exception("Exception caught: ", e);
            }
            return Ok(buyerToUpdate);
        }

        [HttpPut("updateSeller")]
        public async Task<IActionResult> PutUpdateSeller([FromBody] UpdateUserRequest request) 
        {
            var sellerToUpdate = await _context.UserCatalog
                .FirstOrDefaultAsync(i => i.Id == request.UserId);

            if (sellerToUpdate == null)
            {
                return NotFound();
            }

            sellerToUpdate.Capital += request.Price;

            var shareList= sellerToUpdate.ShareIds.Split(",");
            var sharesToKeep = shareList.Where(x => x != request.ShareId);

            sellerToUpdate.ShareIds = String.Join(",", sharesToKeep);

            try
            {
                _context.Update(sellerToUpdate);
                await _context.SaveChangesAsync();
            } 
            catch (Exception e)
            {
                Console.WriteLine("Exception caught: ", e);
            }
            return Ok(sellerToUpdate);
        }
    }
}
