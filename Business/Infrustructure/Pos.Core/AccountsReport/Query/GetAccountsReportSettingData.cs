using AutoMapper;
using MediatR;
using Pos.Repository.IRepository;
using Pos.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pos.Core.AccountsReport.Query
{
    
    public record GetAccountsReportSettingData(int AccountsReportSettingId, DateTime fromdate, DateTime EndDate) : IRequest<VmAccountsReportSetting>;
    public class GetCcountsTrialbalanceHandler : IRequestHandler<GetAccountsReportSettingData, VmAccountsReportSetting>
    {

        private readonly IAccountsReportReposity _AccountsHeadRepository;

        private readonly IMapper _mapper;

        public GetCcountsTrialbalanceHandler(IAccountsReportReposity AccountsHeadRepository, IMapper mapper)
        {
            _AccountsHeadRepository = AccountsHeadRepository;
            _mapper = mapper;

        }
        public async Task<VmAccountsReportSetting> Handle(GetAccountsReportSettingData request, CancellationToken cancellationToken)
        {


            var result = await _AccountsHeadRepository.GetAccountsReportSettingsReport(request.AccountsReportSettingId, request.fromdate, request.EndDate);
            return result;

        }

    }
}
