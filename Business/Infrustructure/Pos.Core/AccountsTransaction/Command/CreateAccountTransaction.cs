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
    public record CreateAccountTransaction(VmAccountTransactionMst aVmAccountTransactionMst) : IRequest<VmAccountTransactionMst>;
    public class CreateAccountTransactionHandler : IRequestHandler<CreateAccountTransaction, VmAccountTransactionMst>
    {
        private readonly IAccountsTransactionRepository _Repository;
        private readonly IMapper _mapper;
        private readonly CreateAccountTransactionValidation _validationRules;
        public CreateAccountTransactionHandler(IAccountsTransactionRepository aRepository, IMapper mapper, CreateAccountTransactionValidation validationRules)
        {
            _Repository = aRepository;
            _mapper = mapper;
            _validationRules = validationRules;
        }
        public async Task<VmAccountTransactionMst> Handle(CreateAccountTransaction request, CancellationToken cancellationToken)
        {
            var validation = await _validationRules.ValidateAsync(request, cancellationToken);

            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }

            var result = await _Repository.Add(_mapper.Map<Model.AccountTransactionMst>(request.aVmAccountTransactionMst));

            return result;
        }
    }

    public class CreateAccountTransactionValidation : AbstractValidator<CreateAccountTransaction>
    {

        public CreateAccountTransactionValidation()
        {
            RuleFor(x => x.aVmAccountTransactionMst.VoucherDate).NotEmpty().WithMessage("Accounts Type is Requrid .");
            //RuleFor(x => x.aVmAccountTransactionMst.VoucherNo).NotEmpty().WithMessage("Accounts Head Type is Requrid .");
            RuleFor(x => x.aVmAccountTransactionMst.CreditedAmount).NotEmpty().WithMessage("Accounts Credited Amount is Requrid .");
            RuleFor(x => x.aVmAccountTransactionMst.DebitedAmount).NotEmpty().WithMessage("Accounts Debited Amount is Requrid .");
            RuleFor(x => x.aVmAccountTransactionMst.TotalAmount).NotEmpty().WithMessage("Accounts Total Amount is Requrid .");
            RuleFor(x => x.aVmAccountTransactionMst.VoucherType).NotEmpty().WithMessage("Accounts Voucher Type is Requrid .");

            RuleFor(x => x.aVmAccountTransactionMst.AccountsDtl)
    .Must(accountsDtl => accountsDtl != null && accountsDtl.Count > 0)
    .WithMessage("Transaction Dtl Needed.");
            RuleFor(x => x.aVmAccountTransactionMst.AccountsDtl.Sum(a => a.CreditedAmount))
    .Equal(x => x.aVmAccountTransactionMst.CreditedAmount)
    .WithMessage("Credited Amount is Wrong.");
            RuleFor(x => x.aVmAccountTransactionMst.AccountsDtl.Sum(a => a.DebitedAmount))
    .Equal(x => x.aVmAccountTransactionMst.DebitedAmount)
    .WithMessage("Debite Amount is Wrong.");

            RuleFor(x => x.aVmAccountTransactionMst.AccountsDtl.Sum(a => a.CreditedAmount))
    .Equal(x => x.aVmAccountTransactionMst.AccountsDtl.Sum(a => a.DebitedAmount)).WithMessage("Debite and Credit Amount is not Same.");

         
       
        }
    }
}
