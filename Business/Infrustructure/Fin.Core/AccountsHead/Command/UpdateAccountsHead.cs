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
    public record UpdateAccountsHead(VmAccountsHead aVmAccountsHead,int id):IRequest<VmAccountsHead>;
    public class UpdateAccountsHeadHandler : IRequestHandler<UpdateAccountsHead, VmAccountsHead>
    {
        private readonly IAccountsHeadRepository _Repository;
        private readonly IMapper _mapper;
        private readonly UpdateAccountsHeadValidation _validationRules;
        public UpdateAccountsHeadHandler(IAccountsHeadRepository AccountsHeadRepository, IMapper mapper, UpdateAccountsHeadValidation validationRules)
        {
            _Repository = AccountsHeadRepository;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public async Task<VmAccountsHead> Handle(UpdateAccountsHead request, CancellationToken cancellationToken)
        {
            var validation = await _validationRules.ValidateAsync(request, cancellationToken);
            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }
            var result = await _Repository.Update(request.id,_mapper.Map<Model.AccountsHead>(request.aVmAccountsHead));
            return result;
        }
    }
    public class UpdateAccountsHeadValidation : AbstractValidator<UpdateAccountsHead>
    {
        public UpdateAccountsHeadValidation()
        {
            RuleFor(x => x.aVmAccountsHead.HeadName).NotEmpty().WithMessage("Name is Requrid .");
            RuleFor(x => x.aVmAccountsHead.AccountsHeadTypeId).NotEmpty().WithMessage("Accounts Type is Requrid .");
            RuleFor(x => x.aVmAccountsHead.HeadType).NotEmpty().WithMessage("Accounts Head Type is Requrid .");
            RuleFor(x => x.aVmAccountsHead.Code).NotEmpty().WithMessage("Accounts Code is Requrid ."); ;
        }
    }
}
