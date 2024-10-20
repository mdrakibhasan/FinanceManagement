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
using Pos.Repository.Repository;

namespace Pos.Core.Query
{
    public record GetByAccountTransactionAll() : IRequest<IEnumerable<VmAccountTransactionMst>>;
    public class GetAccountTransactionAllHandler : IRequestHandler<GetByAccountTransactionAll, IEnumerable<VmAccountTransactionMst>>
    {
		private readonly IAccountsTransactionRepository _sateRepository;
		public GetAccountTransactionAllHandler(IAccountsTransactionRepository sateRepository)
		{
			_sateRepository = sateRepository;
		}
		public async Task<IEnumerable<VmAccountTransactionMst>> Handle(GetByAccountTransactionAll request, CancellationToken cancellationToken)
		{
			var result = await _sateRepository.GetList();
			
			return result;
		}
	}
   
}
