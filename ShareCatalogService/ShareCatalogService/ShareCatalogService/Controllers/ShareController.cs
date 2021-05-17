using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using ShareCatalogService.Clients;
using ShareCatalogService.Controllers.Requests;
using ShareCatalogService.Data;
using ShareCatalogService.Models;

namespace ShareCatalogService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ShareController: ControllerBase
	{
		private readonly ShareCatalogContext _context;
		//private readonly ITobinTaxingClient _tobinTaxingClient;
		private readonly TobinTaxingClient _tobinTaxingClient;

		public ShareController(ShareCatalogContext shareCatalogStore, TobinTaxingClient tobinTaxingClient)
		{
			_context = shareCatalogStore;
			_tobinTaxingClient = tobinTaxingClient;
		}

		// GET: api/Share
		[HttpGet]
		public async Task<ActionResult<ICollection<ShareCatalog>>> GetShares()
		{
			return await _context.Shares.ToListAsync();
		}


		[HttpGet("getShareInfo/{id}")]
		public async Task<ActionResult<ShareCatalog>> GetShare(string id)
		{
			var share = await _context.Shares.FindAsync(id);

			if (share == null)
			{
				return NotFound();
			}

			return share;
		}

		//Get all for sale shares HttpGet call
		[HttpGet("/forSale")]
		public async Task<ICollection<ShareCatalog>> GetSharesForSale()
		{
			return await _context.Shares
				.Where(s => s.ForSale == true)
				.ToListAsync();
		}

		// set share for Sale
		[HttpPut("updateShareForSale/{id}")]
		public async Task<IActionResult> UpdateShareForSale(string shareId)
		{
			var share = await GetShare(shareId);

			try
			{
				var tobinTaxingRequest = new TobinTaxingRequest
				{
					shareId = share.Value.Id,
					shareValue = share.Value.Value,
				};

				var taxResponse = await _tobinTaxingClient.GetTaxForShare(tobinTaxingRequest);
				share.Value.Tax = taxResponse.TaxValue;
				share.Value.ForSale = true;
				await _context.SaveChangesAsync();
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception caught: ", e);
			}

			return Ok();
		}

		//update owner HttpPut call
		[HttpPut("/updateShareOwner")]
		public async Task<IActionResult> UpdateShareOwner(string shareId, string buyerId)
		{
			try
			{
				// look up share with shareID
				var shareResponse = await GetShare(shareId);
				// set share.userId to buyerId
				shareResponse.Value.userId = buyerId;
				shareResponse.Value.ForSale = false;

				await _context.SaveChangesAsync();
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception caught: ", e);
			}

			return Ok();
		}

		

		private bool ShareExists(string id)
		{
			return _context.Shares.Any(share => share.Id == id);
		}
	}
}
