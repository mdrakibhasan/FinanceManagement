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
    public record GetByAccountsReportSettingAll() : IRequest<IEnumerable<VmAccountsReportSetting>>;
 
    public class GetAccountsReportSettingAllHandler: IRequestHandler<GetByAccountsReportSettingAll, IEnumerable<VmAccountsReportSetting>>
    {
		
        private readonly IAccountsReportSettingRepository _sateRepository ;
		
        private readonly IMapper _mapper ;
        public GetAccountsReportSettingAllHandler(IAccountsReportSettingRepository sateRepository, IMapper mapper)
        {
            _sateRepository = sateRepository;
            _mapper = mapper;
        }

        [UsedImplicitly]
        public async Task<IEnumerable<VmAccountsReportSetting>> Handle(GetByAccountsReportSettingAll request, CancellationToken cancellationToken)
		{

            var data = await _sateRepository.GetList();

           return data;

          
        }

       
    }
   
}
