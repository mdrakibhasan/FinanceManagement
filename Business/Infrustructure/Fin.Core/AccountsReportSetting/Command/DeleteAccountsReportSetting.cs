using AutoMapper;
using FluentValidation;
using MediatR;
using Pos.IRepository;
using Pos.Repository.IRepository;
using Pos.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pos.Core.AccountsReportSetting.Command
{
   
    public record DeleteAccountsReportSetting(int id) : IRequest<VmAccountsReportSetting>;



    public class DeleteAccountsReportSettingHandler : IRequestHandler<DeleteAccountsReportSetting, VmAccountsReportSetting>
    {

        private readonly IAccountsReportSettingRepository _AccountsReportSettingRepository;

        private readonly IMapper _mapper;

        public DeleteAccountsReportSettingHandler(IAccountsReportSettingRepository AccountsReportSettingRepository, IMapper mapper)
        {
            _AccountsReportSettingRepository = AccountsReportSettingRepository;
            _mapper = mapper;
           
        }
        public async Task<VmAccountsReportSetting> Handle(DeleteAccountsReportSetting request, CancellationToken cancellationToken)
        {

            
           
             await _AccountsReportSettingRepository.Delete(request.id);
            return new VmAccountsReportSetting ();

        }        

       
    }
}
