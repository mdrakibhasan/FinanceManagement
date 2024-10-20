using AutoMapper;
using JetBrains.Annotations;
using MediatR;
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
    public record GetAccountsTreeList : IRequest<IEnumerable<VmAccountsHead>>;
   
    public class GetAccountsTreeListHandler : IRequestHandler<GetAccountsTreeList, IEnumerable<VmAccountsHead>>
    {

        private readonly IAccountsHeadRepository _sateRepository;

        private readonly IMapper _mapper;
        public GetAccountsTreeListHandler(IAccountsHeadRepository sateRepository, IMapper mapper)
        {
            _sateRepository = sateRepository;
            _mapper = mapper;
        }

        [UsedImplicitly]
        public async Task<IEnumerable<VmAccountsHead>> Handle(GetAccountsTreeList request, CancellationToken cancellationToken)
        {

            var data = await _sateRepository.GetAccountsType();

            return data;

            // var result = await _sateRepository.GetPageAsync(0, 10, p => p.Where(a => a.RootId == null).OrderBy(a => a.Id), d => d.Root);


            // //var result = await _sateRepository.GetAccountsType();

            // var data = _mapper.Map<List<VmAccountsHead>>(result.Data);
            // var result = await _sateRepository.GetList();

            //// return result;
            // return result switch
            // {
            //     not null => new QueryResult<Paging<VmAccountsHead>>(result, QueryResultTypeEnum.Success),
            //     _ => new QueryResult<Paging<VmAccountsHead>>(null, QueryResultTypeEnum.NotFound)
            // };
        }


    }
}
