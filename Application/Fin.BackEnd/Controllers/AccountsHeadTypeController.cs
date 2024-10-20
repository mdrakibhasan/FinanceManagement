using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pos.Core.AccountsHeadType.Command;
using Pos.Core.Command;
using Pos.Core.Query;
using Pos.Service.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pos.BackEnd.Controllers
{
    [Route("api/AccountsHeadType")]
    [ApiController]

    [Authorize]
    public class AccountsHeadTypeController : Controller
    {
        private readonly IMediator _mediator;
        public AccountsHeadTypeController(IMediator mediator)
        {
            _mediator = mediator;

        }

        
        [HttpGet("{id}", Name = "GetById")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<ActionResult<VmAccountsHeadType>> GetById(int id)
        {
            return await _mediator.Send(new GetByAccountsHeadTypeId(id));
        }
        [HttpGet]
        
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IEnumerable<VmAccountsHeadType>> GetAccountsHeadTypeAll()
        {
            return await _mediator.Send(new GetByAccountsHeadTypeAll());
        }
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<ActionResult<VmAccountsHeadType>> Post([FromBody] VmAccountsHeadType aVmAccountsHeadType)
        {
            return await _mediator.Send(new CreateAccountsHeadType(aVmAccountsHeadType));
        }
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<ActionResult<VmAccountsHeadType>> Put([FromBody] VmAccountsHeadType aVmAccountsHeadType, int id)
        {
            return await _mediator.Send(new UpdateAccountsHeadType(aVmAccountsHeadType, id));
        }
        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> Delete( int id)
        {
            var ddd = await _mediator.Send(new DeleteAccountsHeadType(id));
            return Ok(1);
        }
    }
}
