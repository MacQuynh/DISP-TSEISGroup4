using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShareCatalogService.Clients;
using ShareCatalogService.Controllers.Requests;
using ShareCatalogService.Data;
using ShareCatalogService.Models;
using AutoMapper;

namespace ShareCatalogService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ShareCatalogController: ControllerBase
	{
		private readonly ShareCatalogContext _context;
		//private readonly ITobinTaxingClient _tobinTaxingClient;
		private readonly TobinTaxingClient _tobinTaxingClient;
		private IMapper _mapper;

		public ShareCatalogController(ShareCatalogContext shareCatalogStore, TobinTaxingClient tobinTaxingClient)
		{
			var config = new MapperConfiguration(cfg => cfg.CreateMap<ShareCatalogRequest, ShareCatalog>());
			_mapper = new Mapper(config);
			_context = shareCatalogStore;
			_tobinTaxingClient = tobinTaxingClient;
		}

		// GET: api/ShareCatalog
		[HttpGet("getShares")]
		public async Task<ActionResult<IReadOnlyCollection<ShareCatalog>>> GetShares()
		{
			return await Task.FromResult(_context.Shares.ToList());
		}


		[HttpGet("{id}")]
		public async Task<ActionResult<ShareCatalog>> GetShare([FromRoute] string id)
		{
			var share = await _context.Shares.FindAsync(id);

			if(share == null)
			{
				return NotFound();
			}

			return share;
		}

		//Get all for sale shares HttpGet call
		[HttpGet("forSale")]
		public async Task<ICollection<ShareCatalog>> GetSharesForSale()
		{
			return await _context.Shares
				.Where(s => s.ForSale == true)
				.ToListAsync();
		}

		// set share for Sale
		[HttpPut("updateShareForSale/{shareId}")]
		public async Task<IActionResult> UpdateShareForSale(string shareId)
		{
			var share = await _context.Shares.FindAsync(shareId);

			try
			{
				var tobinTaxingRequest = new TobinTaxingRequest
				{
					ShareId = share.Id,
					ShareValue = share.Value,
				};

				var taxResponse = await _tobinTaxingClient.CalculateTaxForShare(tobinTaxingRequest);

				share.Tax = (float)taxResponse.TaxValue;
				share.ForSale = true;
				await _context.SaveChangesAsync();
			}
			catch (Exception e)
			{
				throw new Exception("Exception caught: ", e);
			}

			return Ok();
		}

		//update owner HttpPut call
		[HttpPut("updateShareOwner")]
		public async Task<IActionResult> UpdateShareOwner([FromBody] ShareRequest request)
		{
			// look up share with shareID
			var share = await _context.Shares.FindAsync(request.ShareId);

			try
			{
				
				share.UserId = request.UserId;
				share.ForSale = false;

				await _context.SaveChangesAsync();
			}
			catch (Exception e)
			{
				throw new Exception("Exception caught: ",e);
			}

			return Ok();
		}

		

		private bool ShareExists(string id)
		{
			return _context.Shares.Any(share => share.Id == id);
		}
	}
}
