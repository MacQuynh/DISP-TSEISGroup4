using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IUserCatalogService _userCatalogClient;
        private IMapper _mapper;

        public TransactionsController(TransactionContext context, IUserCatalogService userCatalogClient)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TransactionRequest, Transaction>());
            _mapper = new Mapper(config);
            _context = context;
            _userCatalogClient = userCatalogClient;
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
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();

            //send request to User Catalog to update buyer and seller
            //--Buyer: update ownerships and capital
            //--Seller: update ownerships and capital

            var response = _userCatalogClient.SendUpdateForBuyerToUSerCatalog(transaction.BuyerId);

            // send request to Share Catalog to update share
            //--Update owner and for sale

            return Ok(transaction);
        }

    }
}
