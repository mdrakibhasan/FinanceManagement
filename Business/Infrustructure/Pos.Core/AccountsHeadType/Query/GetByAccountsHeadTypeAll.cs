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

namespace Pos.Core.Query
{
    public record GetByAccountsHeadTypeAll() : IRequest<IEnumerable<VmAccountsHeadType>>;
    public class GetAccountsHeadTypeAllHandler : IRequestHandler<GetByAccountsHeadTypeAll, IEnumerable<VmAccountsHeadType>>
    {
		private readonly IAccountsHeadTypeRepository _sateRepository;
		public GetAccountsHeadTypeAllHandler(IAccountsHeadTypeRepository sateRepository)
		{
			_sateRepository = sateRepository;
		}
		public async Task<IEnumerable<VmAccountsHeadType>> Handle(GetByAccountsHeadTypeAll request, CancellationToken cancellationToken)
		{
			var result = await _sateRepository.GetList();
			;
			return result;
		}
	}
   
}
