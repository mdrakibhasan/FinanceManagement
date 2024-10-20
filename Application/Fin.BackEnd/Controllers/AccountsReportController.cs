using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pos.Core.Query;
using Pos.Service.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pos.BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountsReportController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AccountsReportController(IMediator mediator)
        {
            _mediator = mediator;

        }


        [HttpGet]
        [Route("TrialBalance")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<ActionResult<VmAccountsTrialBalanceSheet>> GetTrialBalance(int level,DateTime FromDate,DateTime EndDate)
        {
            return await _mediator.Send(new GetAccountsTrialbalance(level, FromDate, EndDate));
        }    
       
    }
}
