using AutoMapper;
using FluentValidation;
using MediatR;
using Pos.IRepository;
using Pos.Repository;
using Pos.Repository.IRepository;
using Pos.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pos.Core.Command
{
    public record UpdateAccountsReportSetting(VmAccountsReportSetting aVmAccountsReportSetting,int id):IRequest<VmAccountsReportSetting>;
    public class UpdateAccountsReportSettingHandler : IRequestHandler<UpdateAccountsReportSetting, VmAccountsReportSetting>
    {
        private readonly IAccountsReportSettingRepository _Repository;
        private readonly IMapper _mapper;
        private readonly UpdateAccountsReportSettingValidation _validationRules;
        public UpdateAccountsReportSettingHandler(IAccountsReportSettingRepository AccountsReportSettingRepository, IMapper mapper, UpdateAccountsReportSettingValidation validationRules)
        {
            _Repository = AccountsReportSettingRepository;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public async Task<VmAccountsReportSetting> Handle(UpdateAccountsReportSetting request, CancellationToken cancellationToken)
        {
            var validation = await _validationRules.ValidateAsync(request, cancellationToken);
            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }
            var result = await _Repository.Update(request.id,_mapper.Map<Model.AccountsReportSetting>(request.aVmAccountsReportSetting));
            return result;
        }
    }
    public class UpdateAccountsReportSettingValidation : AbstractValidator<UpdateAccountsReportSetting>
    {
        public UpdateAccountsReportSettingValidation()
        {
            RuleFor(x => x.aVmAccountsReportSetting.ReportName).NotEmpty().WithMessage("Name is Requrid .");
           
        }
    }
}
