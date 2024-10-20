using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pos.Repository;
using Pos.Service.Model;
using System.Threading;
using Pos.Repository.IRepository;
using Pos.IRepository;
using AutoMapper;

namespace Pos.Core.Query
{
    public record GetAccountsTrialbalance(int Level,DateTime fromdate,DateTime EndDate) : IRequest<VmAccountsTrialBalanceSheet>;
    public class GetCcountsTrialbalanceHandler : IRequestHandler<GetAccountsTrialbalance, VmAccountsTrialBalanceSheet>
    {

        private readonly IAccountsReportReposity _AccountsHeadRepository;

        private readonly IMapper _mapper;

        public GetCcountsTrialbalanceHandler(IAccountsReportReposity AccountsHeadRepository, IMapper mapper)
        {
            _AccountsHeadRepository = AccountsHeadRepository;
            _mapper = mapper;

        }
        public async Task<VmAccountsTrialBalanceSheet> Handle(GetAccountsTrialbalance request, CancellationToken cancellationToken)
        {


            var result = await _AccountsHeadRepository.GetTrialBalance(request.Level, request.fromdate, request.EndDate);
            return result;

        }

    }

}
