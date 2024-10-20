using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pos.Core.AccountsTransaction.Query;
using Pos.Core.AccountTransaction.Command;
using Pos.Core.Command;
using Pos.Core.Query;
using Pos.Service.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pos.BackEnd.Controllers
{
    [Route("api/AccountTransaction")]
    [ApiController]
    [Authorize]
    public class AccountsTransactionController : Controller
    {
        private readonly IMediator _mediator;
        public AccountsTransactionController(IMediator mediator)
        {
            _mediator = mediator;

        }



        [HttpGet("{id}", Name = "GetByAccountsTransactionId")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<ActionResult<VmAccountTransactionMst>> GetByAccountsTransactionId(int id)
        {
            return await _mediator.Send(new GetByAccountTransactionId(id));
        }
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IEnumerable<VmAccountTransactionMst>> GetAll()
        {
            return await _mediator.Send(new GetByAccountTransactionAll());
        }

        [Route("AccountLadger/{AccountsHeadId}")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<List<VmAccountLadger>> GetAccountLadger(int AccountsHeadId, DateTime FromDate, DateTime ToDate)
        {
            var fff= await _mediator.Send(new GetAccountsLadger(AccountsHeadId,  FromDate,  ToDate));
            return  fff;
        }

        [Route("AccountHeadLadger/{AccountsHeadId}")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<VmAccountsHead> AccountHeadLadger(int AccountsHeadId, DateTime FromDate, DateTime ToDate)
        {
            var fff = await _mediator.Send(new GetAccountsLagerByAccountsRootId(AccountsHeadId, FromDate, ToDate));
            return fff;
        }


        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<ActionResult<VmAccountTransactionMst>> Post([FromBody] VmAccountTransactionMst aVmAccountTransactionMst)
        {
            return await _mediator.Send(new CreateAccountTransaction(aVmAccountTransactionMst));
        }
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<ActionResult<VmAccountTransactionMst>> Put([FromBody] VmAccountTransactionMst aVmAccountTransactionMst, int id)
        {
            return await _mediator.Send(new UpdateAccountTransaction(aVmAccountTransactionMst, id));
        }
        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> Delete(int id)
        {
            var ddd = await _mediator.Send(new DeleteAccountTransaction(id));
            return Ok(1);
        }
    }
}
