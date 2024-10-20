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

namespace Pos.Core.AccountsHead.Command
{
   
    public record DeleteAccountsHead(int id) : IRequest<VmAccountsHead>;



    public class DeleteAccountsHeadHandler : IRequestHandler<DeleteAccountsHead, VmAccountsHead>
    {

        private readonly IAccountsHeadRepository _AccountsHeadRepository;

        private readonly IMapper _mapper;

        public DeleteAccountsHeadHandler(IAccountsHeadRepository AccountsHeadRepository, IMapper mapper)
        {
            _AccountsHeadRepository = AccountsHeadRepository;
            _mapper = mapper;
           
        }
        public async Task<VmAccountsHead> Handle(DeleteAccountsHead request, CancellationToken cancellationToken)
        {

            
           
             await _AccountsHeadRepository.Delete(request.id);
            return new VmAccountsHead ();

        }        

       
    }
}
