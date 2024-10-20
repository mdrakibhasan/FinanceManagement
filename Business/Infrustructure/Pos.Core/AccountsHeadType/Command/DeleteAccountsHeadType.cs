using AutoMapper;
using FluentValidation;
using MediatR;
using Pos.IRepository;
using Pos.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pos.Core.AccountsHeadType.Command
{
   
    public record DeleteAccountsHeadType(int id) : IRequest<VmAccountsHeadType>;



    public class DeleteAccountsHeadTypeHandler : IRequestHandler<DeleteAccountsHeadType, VmAccountsHeadType>
    {

        private readonly IAccountsHeadTypeRepository _AccountsHeadTypeRepository;

        private readonly IMapper _mapper;

        public DeleteAccountsHeadTypeHandler(IAccountsHeadTypeRepository AccountsHeadTypeRepository, IMapper mapper)
        {
            _AccountsHeadTypeRepository = AccountsHeadTypeRepository;
            _mapper = mapper;
           
        }
        public async Task<VmAccountsHeadType> Handle(DeleteAccountsHeadType request, CancellationToken cancellationToken)
        {

            
           
             await _AccountsHeadTypeRepository.Delete(request.id);
            return new VmAccountsHeadType ();

        }        

       
    }
}
