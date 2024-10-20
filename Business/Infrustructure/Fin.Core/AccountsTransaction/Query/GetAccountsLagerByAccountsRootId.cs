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

namespace Pos.Core.AccountsTransaction.Query
{
    
    public record GetAccountsLagerByAccountsRootId(int id, DateTime FromDate, DateTime ToDate) : IRequest<VmAccountsHead>;

    public class GetAccountsLagerByAccountsRootIdHandler : IRequestHandler<GetAccountsLagerByAccountsRootId, VmAccountsHead>
    {

        private readonly IAccountsReportReposity _AccountTransactionRepository;

        private readonly IMapper _mapper;

        public GetAccountsLagerByAccountsRootIdHandler(IAccountsReportReposity AccountTransactionRepository, IMapper mapper)
        {
            _AccountTransactionRepository = AccountTransactionRepository;
            _mapper = mapper;

        }
        public async Task<VmAccountsHead> Handle(GetAccountsLagerByAccountsRootId request, CancellationToken cancellationToken)
        {


            var result = await _AccountTransactionRepository.GetAccountsLadgerByRootId(request.id, request.FromDate, request.ToDate);
            return result;

        }


    }
}
