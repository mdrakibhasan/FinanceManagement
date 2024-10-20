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
    public record UpdateAccountsHeadType(VmAccountsHeadType aVmAccountsHeadType,int id):IRequest<VmAccountsHeadType>;
    public class UpdateAccountsHeadTypeHandler : IRequestHandler<UpdateAccountsHeadType, VmAccountsHeadType>
    {
        private readonly IAccountsHeadTypeRepository _Repository;
        private readonly IMapper _mapper;
        private readonly UpdateAccountsHeadTypeValidation _validationRules;
        public UpdateAccountsHeadTypeHandler(IAccountsHeadTypeRepository AccountsHeadTypeRepository, IMapper mapper, UpdateAccountsHeadTypeValidation validationRules)
        {
            _Repository = AccountsHeadTypeRepository;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public async Task<VmAccountsHeadType> Handle(UpdateAccountsHeadType request, CancellationToken cancellationToken)
        {
            var validation = await _validationRules.ValidateAsync(request, cancellationToken);
            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }
            var result = await _Repository.Update(request.id,_mapper.Map<Model.AccountsHeadType>(request.aVmAccountsHeadType));
            return result;
        }
    }
    public class UpdateAccountsHeadTypeValidation : AbstractValidator<UpdateAccountsHeadType>
    {
        public UpdateAccountsHeadTypeValidation()
        {
            RuleFor(x => x.aVmAccountsHeadType.Name).NotEmpty().WithMessage("Name is Requrid .");
            RuleFor(x => x.aVmAccountsHeadType.Key).NotEmpty().WithMessage("Key is Requrid .");
        }
    }
}
