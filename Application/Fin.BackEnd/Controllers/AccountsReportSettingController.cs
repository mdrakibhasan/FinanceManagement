using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pos.Core.AccountsReport.Query;
using Pos.Core.AccountsReportSetting.Command;
using Pos.Core.Command;
using Pos.Core.Query;
using Pos.Service.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pos.BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsReportSettingController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AccountsReportSettingController(IMediator mediator)
        {
            _mediator = mediator;

        }



        [HttpGet("{id}", Name = "GetByAccountsReportSettingId")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<ActionResult<VmAccountsReportSetting>> GetByAccountsReportSettingId(int id)
        {
            return await _mediator.Send(new GetByAccountsReportSettingId(id));
        }
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IEnumerable<VmAccountsReportSetting>> GetAll()
        {
            var gg = await _mediator.Send(new GetByAccountsReportSettingAll());
            return gg;
        }
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<ActionResult<VmAccountsReportSetting>> Post([FromBody] VmAccountsReportSetting aVmAccountsReportSetting)
        {
            return await _mediator.Send(new CreateAccountsReportSetting(aVmAccountsReportSetting));
        }
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<ActionResult<VmAccountsReportSetting>> Put([FromBody] VmAccountsReportSetting aVmAccountsReportSetting, int id)
        {
            return await _mediator.Send(new UpdateAccountsReportSetting(aVmAccountsReportSetting, id));
        }
        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> Delete(int id)
        {
            var ddd = await _mediator.Send(new DeleteAccountsReportSetting(id));
            return Ok(1);
        }

        [HttpGet]
        [Route("GetAccountsReportSettingData")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<ActionResult<VmAccountsReportSetting>> GetTrialBalance(int ReportSettingId, DateTime FromDate, DateTime EndDate)
        {
            return await _mediator.Send(new GetAccountsReportSettingData(ReportSettingId, FromDate, EndDate));
        }
    }
}
