using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("{id}")]
        public async Task<ActionResult<UserCatalog>> GetValidateBuyer(string id)
        {
            var buyer = await _context.UserCatalog.FindAsync(id);

            if (buyer == null)
            {
                return NotFound();
            }

            return buyer;


            //Should also handle validation of kapital. 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserCatalog>> GetValidateSeller(string id)
        {
            var seller = await _context.UserCatalog.FindAsync(id);

            if (seller == null)
            {
                return NotFound();
            }

            return seller;


            //Should also handle validation of the ownership of the stock. 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUpdateUser(string id, UserCatalog user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                if (!UserExist(id))
                {
                    return NotFound();
                }
                else { throw; }
            }

            return NoContent();
        }


        private bool UserExist(string id)
        {
            return _context.UserCatalog.Any(e => e.Id == id);
        }
    }
}
