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
    public record GetByAccountsHeadId(int id):IRequest<VmAccountsHead>;
    

    
    public class GetByAccountsHeadIdHandler : IRequestHandler<GetByAccountsHeadId, VmAccountsHead>
    {

        private readonly IAccountsHeadRepository _AccountsHeadRepository;

        private readonly IMapper _mapper;

        public GetByAccountsHeadIdHandler(IAccountsHeadRepository AccountsHeadRepository, IMapper mapper)
        {
            _AccountsHeadRepository = AccountsHeadRepository;
            _mapper = mapper;
           
        }
        public async Task<VmAccountsHead> Handle(GetByAccountsHeadId request, CancellationToken cancellationToken)
        {

           
            var result = await _AccountsHeadRepository.GetById(request.id);
            return result;

        }

        
        
    }
}
