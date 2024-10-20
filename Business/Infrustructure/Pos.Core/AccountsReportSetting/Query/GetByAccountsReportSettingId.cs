using AutoMapper;
using FluentValidation;
using MediatR;
using Pos.IRepository;
using Pos.Repository.IRepository;
using Pos.Service.Model;
using System.Threading;    
using System.Threading.Tasks;

namespace Pos.Core.Query
{
    public record GetByAccountsReportSettingId(int id):IRequest<VmAccountsReportSetting>;
    

    
    public class GetByAccountsReportSettingIdHandler : IRequestHandler<GetByAccountsReportSettingId, VmAccountsReportSetting>
    {

        private readonly IAccountsReportSettingRepository _AccountsReportSettingRepository;

        private readonly IMapper _mapper;

        public GetByAccountsReportSettingIdHandler(IAccountsReportSettingRepository AccountsReportSettingRepository, IMapper mapper)
        {
            _AccountsReportSettingRepository = AccountsReportSettingRepository;
            _mapper = mapper;
           
        }
        public async Task<VmAccountsReportSetting> Handle(GetByAccountsReportSettingId request, CancellationToken cancellationToken)
        {

           
            var result = await _AccountsReportSettingRepository.GetById(request.id);
            return result;

        }

        
        
    }
}
