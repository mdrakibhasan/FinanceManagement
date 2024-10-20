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
    public record CreateAccountsHead(VmAccountsHead aVmAccountsHead) :IRequest<VmAccountsHead>;
    public class CreateAccountsHeadHandler : IRequestHandler<CreateAccountsHead, VmAccountsHead>
    {
        private readonly IAccountsHeadRepository _Repository;
        private readonly IMapper _mapper;
        private readonly CreateAccountsHeadValidation _validationRules;
        public CreateAccountsHeadHandler(IAccountsHeadRepository aRepository, IMapper mapper, CreateAccountsHeadValidation validationRules)
        {
            _Repository = aRepository;
            _mapper = mapper;
            _validationRules = validationRules;
        }
        public async Task<VmAccountsHead> Handle(CreateAccountsHead request, CancellationToken cancellationToken)
        {
            var validation = await _validationRules.ValidateAsync(request, cancellationToken);

            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }
            
           /* if( await _Repository.GetAccountsCodeExist(request.aVmAccountsHead.Code,null))
            {
                return new { StatusCode = 402, Message = "Invalid Input Date" };

            }*/
            var result = await _Repository.Add(_mapper.Map<Model.AccountsHead>(request.aVmAccountsHead));
           
            return result;
        }
    }

    public class CreateAccountsHeadValidation : AbstractValidator<CreateAccountsHead>
    {
        public CreateAccountsHeadValidation()
        {
            RuleFor(x => x.aVmAccountsHead.HeadName).NotEmpty().WithMessage("Name is Requrid .");
            RuleFor(x => x.aVmAccountsHead.AccountsHeadTypeId).NotEmpty().WithMessage("Accounts Type is Requrid .");
            RuleFor(x => x.aVmAccountsHead.HeadType).NotEmpty().WithMessage("Accounts Head Type is Requrid .");
            RuleFor(x => x.aVmAccountsHead.Code).NotEmpty().WithMessage("Accounts Code is Requrid .");

        }
    }
}
