using AutoMapper;
using FluentValidation;
using MediatR;
using Pos.IRepository;
using Pos.Repository.IRepository;
using Pos.Service.Model;
using System.Threading;    
using System.Threading.Tasks;

namespace Pos.Core.Query
{
    public record GetByAccountTransactionId(int id):IRequest<VmAccountTransactionMst>;
    

    
    public class GetByAccountTransactionIdHandler : IRequestHandler<GetByAccountTransactionId, VmAccountTransactionMst>
    {

        private readonly IAccountsTransactionRepository _AccountTransactionRepository;

        private readonly IMapper _mapper;

        public GetByAccountTransactionIdHandler(IAccountsTransactionRepository AccountTransactionRepository, IMapper mapper)
        {
            _AccountTransactionRepository = AccountTransactionRepository;
            _mapper = mapper;
           
        }
        public async Task<VmAccountTransactionMst> Handle(GetByAccountTransactionId request, CancellationToken cancellationToken)
        {

           
            var result = await _AccountTransactionRepository.GetTransactionDetails(request.id);
            return result;

        }

        
        
    }
}
