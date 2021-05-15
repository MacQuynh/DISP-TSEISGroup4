using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransactionService.Clients;
using TransactionService.Controllers.Requests;
using TransactionService.Data;
using TransactionService.Model;

namespace TransactionService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly TransactionContext _context;
        private readonly UserCatalogClient _userCatalogClient;
        private readonly ShareCatalogClient _shareCatalogClient;
        private IMapper _mapper;

        public TransactionsController(TransactionContext context, UserCatalogClient userCatalogClient, ShareCatalogClient shareCatalogClient)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TransactionRequest, Transaction>());
            _mapper = new Mapper(config);
            _context = context;
            _userCatalogClient = userCatalogClient;
            _shareCatalogClient = shareCatalogClient;
        }

        // GET: api/Transactions
        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<Transaction>>> GetTransactions()
        {
            return await Task.FromResult(_context.Transactions.ToList());
        }

        [HttpPost]
        public async Task<ActionResult<Transaction>> BuyOfShare([FromBody] TransactionRequest transactionRequest)
        {
            var newId = Guid.NewGuid().ToString();
            var transaction = _mapper.Map<Transaction>(transactionRequest);
            transaction.Id = newId;
            transaction.TimeOfTransaction = DateTime.Now;
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            
            var shareUpdateRequest = new UpdateShareCatalogRequest
            {
                ShareId = transaction.ShareId,
                NewOwnerId = transaction.BuyerId
            };
            var buyerUpdateRequest = new UpdateUserCatalogRequest
            {
                UserId = transaction.BuyerId, ShareId = transaction.ShareId, SharePrice = transaction.Price
            };
            var sellerUpdateRequest = new UpdateUserCatalogRequest
            {
                UserId = transaction.SellerId, ShareId = transaction.ShareId, SharePrice = transaction.Price
            };

            try
            {
                //send request to User Catalog to update buyer and seller
                //--Buyer: update ownerships and capital
                //--Seller: update ownerships and capital
                await _userCatalogClient.SendUpdateForBuyerToUserCatalog(buyerUpdateRequest);
               await _userCatalogClient.SendUpdateForSellerToUserCatalog(sellerUpdateRequest);
               // send request to Share Catalog to update share
               //--Update owner and for sale
                await _shareCatalogClient.SendUpdateToUserCatalog(shareUpdateRequest);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Exception caught: ", e);
            }

            return Ok(transaction);
        }

    }
}
