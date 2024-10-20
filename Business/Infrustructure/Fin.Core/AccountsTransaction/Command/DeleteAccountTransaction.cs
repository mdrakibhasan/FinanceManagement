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

namespace Pos.Core.AccountTransaction.Command
{
   
    public record DeleteAccountTransaction(int id) : IRequest<VmAccountTransactionMst>;



    public class DeleteAccountTransactionHandler : IRequestHandler<DeleteAccountTransaction, VmAccountTransactionMst>
    {

        private readonly IAccountsTransactionRepository _AccountTransactionRepository;

        private readonly IMapper _mapper;

        public DeleteAccountTransactionHandler(IAccountsTransactionRepository AccountTransactionRepository, IMapper mapper)
        {
            _AccountTransactionRepository = AccountTransactionRepository;
            _mapper = mapper;
           
        }
        public async Task<VmAccountTransactionMst> Handle(DeleteAccountTransaction request, CancellationToken cancellationToken)
        {

            
           
             await _AccountTransactionRepository.Delete(request.id);
            return new VmAccountTransactionMst ();

        }        

       
    }
}
