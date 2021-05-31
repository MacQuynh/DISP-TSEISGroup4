using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpGet("validatebuyer/{id}")]
        public async Task<ActionResult<UserCatalog>> GetValidateBuyer([FromRoute]string id)
        {
            var buyer = await Task.FromResult(_context.UserCatalog
              .Where(i => i.Id==id)
              .Include(s => s.Shares)
              .FirstOrDefault());

            if ( buyer == null)
            {
                return NotFound();
            }

            return buyer;

            //Should also handle validation of kapital. 

        }

        [HttpGet("validateseller/{id}")]
        public async Task<ActionResult<UserCatalog>> GetValidateSeller(string id)
        {
            var seller = await Task.FromResult(_context.UserCatalog
              .Where(i => i.Id == id)
              .Include(s => s.Shares)
              .FirstOrDefault());

            if (seller == null)
            {
                return NotFound();
            }

            return seller;


            //Should also handle validation of the ownership of the stock. 
        }

        [HttpPut("updateBuyer/{id}")]
        public async Task<IActionResult> PutBuyer(string id, UserCatalog buyer)
        {

            if (id != buyer.Id)
            {
                return BadRequest();
            }

            //_context.UserCatalog.Update(buyer.Capital);
            //await _context.SaveChangesAsync();
            //_context.Entry(buyer).State = EntityState.Modified;
            var buyerToUpdate = await _context.UserCatalog.FirstOrDefaultAsync(i => i.Id == id);
            if(await TryUpdateModelAsync<UserCatalog>(buyerToUpdate, "", c => c.Capital)) // Just add more here if needed.
            try
            {
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExist(id))
                {
                    return NotFound();
                }
            }
            return (IActionResult)buyerToUpdate;
        }

        [HttpPut("updateSeller/{id}")]
        public async Task<IActionResult> PutUpdateSeller(string id, UserCatalog seller) 
        {
            if (id != seller.Id)
            {
                return BadRequest();
            }

            var sellerToUpdate = await _context.UserCatalog.FirstOrDefaultAsync(i => i.Id == id);
            if (await TryUpdateModelAsync<UserCatalog>(sellerToUpdate, "", c => c.Capital)) // Just add more here if needed.

                _context.Entry(seller).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExist(id))
                {
                    return NotFound();
                }
            }
            return (IActionResult)sellerToUpdate;
        }

        private bool UserExist(string id)
        {
            return _context.UserCatalog.Any(e => e.Id == id);
        }
    }
}
