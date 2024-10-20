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
    public record CreateAccountsHeadType(VmAccountsHeadType aVmAccountsHeadType) :IRequest<VmAccountsHeadType>;
    public class CreateAccountsHeadTypeHandler : IRequestHandler<CreateAccountsHeadType, VmAccountsHeadType>
    {
        private readonly IAccountsHeadTypeRepository _Repository;
        private readonly IMapper _mapper;
        private readonly CreateAccountsHeadTypeValidation _validationRules;
        public CreateAccountsHeadTypeHandler(IAccountsHeadTypeRepository aRepository, IMapper mapper, CreateAccountsHeadTypeValidation validationRules)
        {
            _Repository = aRepository;
            _mapper = mapper;
            _validationRules = validationRules;
        }
        public async Task<VmAccountsHeadType> Handle(CreateAccountsHeadType request, CancellationToken cancellationToken)
        {
            var validation = await _validationRules.ValidateAsync(request, cancellationToken);

            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }
            
            var result = await _Repository.Add(_mapper.Map<Model.AccountsHeadType>(request.aVmAccountsHeadType));
           
            return result;
        }
    }

    public class CreateAccountsHeadTypeValidation : AbstractValidator<CreateAccountsHeadType>
    {
        public CreateAccountsHeadTypeValidation()
        {
            RuleFor(x => x.aVmAccountsHeadType.Name).NotEmpty().WithMessage("Name is Requrid .");
            RuleFor(x => x.aVmAccountsHeadType.Key).NotEmpty().WithMessage("Key is Requrid .");
        }
    }
}
