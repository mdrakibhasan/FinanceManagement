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
    public record CreateAccountsReportSetting(VmAccountsReportSetting aVmAccountsReportSetting) :IRequest<VmAccountsReportSetting>;
    public class CreateAccountsReportSettingHandler : IRequestHandler<CreateAccountsReportSetting, VmAccountsReportSetting>
    {
        private readonly IAccountsReportSettingRepository _Repository;
        private readonly IMapper _mapper;
        private readonly CreateAccountsReportSettingValidation _validationRules;
        public CreateAccountsReportSettingHandler(IAccountsReportSettingRepository aRepository, IMapper mapper, CreateAccountsReportSettingValidation validationRules)
        {
            _Repository = aRepository;
            _mapper = mapper;
            _validationRules = validationRules;
        }
        public async Task<VmAccountsReportSetting> Handle(CreateAccountsReportSetting request, CancellationToken cancellationToken)
        {
            var validation = await _validationRules.ValidateAsync(request, cancellationToken);

            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }
            
            var result = await _Repository.Add(_mapper.Map<Model.AccountsReportSetting>(request.aVmAccountsReportSetting));
           
            return result;
        }
    }

    public class CreateAccountsReportSettingValidation : AbstractValidator<CreateAccountsReportSetting>
    {
        public CreateAccountsReportSettingValidation()
        {
            RuleFor(x => x.aVmAccountsReportSetting.ReportName).NotEmpty().WithMessage("Name is Requrid .");
           
        }
    }
}
