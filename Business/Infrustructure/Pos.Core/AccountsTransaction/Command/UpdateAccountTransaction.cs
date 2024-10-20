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
    public record UpdateAccountTransaction(VmAccountTransactionMst aVmAccountTransactionMst,int id):IRequest<VmAccountTransactionMst>;
    public class UpdateAccountTransactionHandler : IRequestHandler<UpdateAccountTransaction, VmAccountTransactionMst>
    {
        private readonly IAccountsTransactionRepository _Repository;
        private readonly IMapper _mapper;
        private readonly UpdateAccountTransactionValidation _validationRules;
        public UpdateAccountTransactionHandler(IAccountsTransactionRepository AccountTransactionRepository, IMapper mapper, UpdateAccountTransactionValidation validationRules)
        {
            _Repository = AccountTransactionRepository;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public async Task<VmAccountTransactionMst> Handle(UpdateAccountTransaction request, CancellationToken cancellationToken)
        {
            var validation = await _validationRules.ValidateAsync(request, cancellationToken);
            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }
            var result = await _Repository.Update(request.id,_mapper.Map<Model.AccountTransactionMst>(request.aVmAccountTransactionMst));
            return result;
        }
    }
    public class UpdateAccountTransactionValidation : AbstractValidator<UpdateAccountTransaction>
    {
        public UpdateAccountTransactionValidation()
        {
            RuleFor(x => x.aVmAccountTransactionMst.AccountsDtl).NotEmpty().WithMessage("Transaction Dtl Needed .");
            RuleFor(x => x.aVmAccountTransactionMst.AccountsDtl.Sum(a => a.CreditedAmount) != x.aVmAccountTransactionMst.CreditedAmount).NotEmpty().WithMessage("Credite Amount is Wrong .");
            RuleFor(x => x.aVmAccountTransactionMst.AccountsDtl.Sum(a => a.DebitedAmount) != x.aVmAccountTransactionMst.DebitedAmount).NotEmpty().WithMessage("Debite Amount is wrong.");


            RuleFor(x => x.aVmAccountTransactionMst.DebitedAmount != x.aVmAccountTransactionMst.CreditedAmount).NotEmpty().WithMessage("Debite and Credit Amount is not Same.");

            RuleFor(x => x.aVmAccountTransactionMst.VoucherDate).NotEmpty().WithMessage("Accounts Type is Requrid .");
            RuleFor(x => x.aVmAccountTransactionMst.VoucherNo).NotEmpty().WithMessage("Accounts Head Type is Requrid .");
            RuleFor(x => x.aVmAccountTransactionMst.CreditedAmount).NotEmpty().WithMessage("Accounts Credited Amount is Requrid .");
            RuleFor(x => x.aVmAccountTransactionMst.DebitedAmount).NotEmpty().WithMessage("Accounts Debited Amount is Requrid .");
            RuleFor(x => x.aVmAccountTransactionMst.TotalAmount).NotEmpty().WithMessage("Accounts Total Amount is Requrid .");
            RuleFor(x => x.aVmAccountTransactionMst.VoucherType).NotEmpty().WithMessage("Accounts Voucher Type is Requrid .");
        }
    }
}
