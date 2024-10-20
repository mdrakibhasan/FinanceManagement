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

namespace Pos.Core.AccountsHead.Query
{
    public record GetAccountsHeadByRootId(int id) : IRequest<IEnumerable<VmAccountsHead>>;

    public class GetAccountsHeadByHandler : IRequestHandler<GetAccountsHeadByRootId, IEnumerable<VmAccountsHead>>
    {

        private readonly IAccountsHeadRepository _AccountsHeadRepository;

        private readonly IMapper _mapper;

        public GetAccountsHeadByHandler(IAccountsHeadRepository AccountsHeadRepository, IMapper mapper)
        {
            _AccountsHeadRepository = AccountsHeadRepository;
            _mapper = mapper;

        }
        public async Task<IEnumerable<VmAccountsHead>> Handle(GetAccountsHeadByRootId request, CancellationToken cancellationToken)
        {


            var result = await _AccountsHeadRepository.GetAccountsHEadByRootId(request.id);
            return result;

        }



    }
}
