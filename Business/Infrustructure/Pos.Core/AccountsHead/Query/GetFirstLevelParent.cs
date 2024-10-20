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

namespace Pos.Core.AccountsHead.Query
{
    
  
        public record GetFirstLevelParent: IRequest<IEnumerable<VmAccountsHead>>;

        public class GetFirstLevelParentHandler : IRequestHandler<GetFirstLevelParent, IEnumerable<VmAccountsHead>>
        {

            private readonly IAccountsHeadRepository _AccountsHeadRepository;

            private readonly IMapper _mapper;

            public GetFirstLevelParentHandler(IAccountsHeadRepository AccountsHeadRepository, IMapper mapper)
            {
                _AccountsHeadRepository = AccountsHeadRepository;
                _mapper = mapper;

            }
            public async Task<IEnumerable<VmAccountsHead>> Handle(GetFirstLevelParent request, CancellationToken cancellationToken)
            {


                var result = await _AccountsHeadRepository.GEtFirstLevelPArent();
                return result;

            }



        }
    }


