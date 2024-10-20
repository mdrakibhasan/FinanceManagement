using AutoMapper;
using MediatR;
using Pos.Core.Query;
using Pos.Repository.IRepository;
using Pos.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pos.Core.AccountsTransaction.Query
{
    public record GetAccountsLadger(int id, DateTime FromDate, DateTime ToDate) : IRequest<List<VmAccountLadger>>;

    public class GetAccountsLadgerHandler : IRequestHandler<GetAccountsLadger, List<VmAccountLadger>>
    {

        private readonly IAccountsReportReposity _AccountTransactionRepository;

        private readonly IMapper _mapper;

        public GetAccountsLadgerHandler(IAccountsReportReposity AccountTransactionRepository, IMapper mapper)
        {
            _AccountTransactionRepository = AccountTransactionRepository;
            _mapper = mapper;

        }
        public async Task<List<VmAccountLadger>> Handle(GetAccountsLadger request, CancellationToken cancellationToken)
        {


            var result = await _AccountTransactionRepository.GetAccountsLadger(request.id, request.FromDate, request.ToDate);
            return result;

        }

       
    }
}
