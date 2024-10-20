using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pos.Service.Model;
using System.Threading;
using Pos.Repository.IRepository;
using JetBrains.Annotations;
using AutoMapper;
using System.Linq.Expressions;

namespace Pos.Core.Query
{
    public record GetByAccountsHeadAll() : IRequest<IEnumerable<VmAccountsHead>>;
 
    public class GetAccountsHeadAllHandler: IRequestHandler<GetByAccountsHeadAll, IEnumerable<VmAccountsHead>>
    {
		
        private readonly IAccountsHeadRepository _sateRepository ;
		
        private readonly IMapper _mapper ;
        public GetAccountsHeadAllHandler(IAccountsHeadRepository sateRepository, IMapper mapper)
        {
            _sateRepository = sateRepository;
            _mapper = mapper;
        }

        [UsedImplicitly]
        public async Task<IEnumerable<VmAccountsHead>> Handle(GetByAccountsHeadAll request, CancellationToken cancellationToken)
		{

            var data = await _sateRepository.GetList();

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
