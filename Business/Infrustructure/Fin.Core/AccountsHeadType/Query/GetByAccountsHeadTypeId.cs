using AutoMapper;
using FluentValidation;
using MediatR;
using Pos.IRepository;
using Pos.Service.Model;
using System.Threading;    
using System.Threading.Tasks;

namespace Pos.Core.Query
{
    public record GetByAccountsHeadTypeId(int id):IRequest<VmAccountsHeadType>;
    

    
    public class GetByAccountsHeadTypeIdHandler : IRequestHandler<GetByAccountsHeadTypeId, VmAccountsHeadType>
    {

        private readonly IAccountsHeadTypeRepository _AccountsHeadTypeRepository;

        private readonly IMapper _mapper;

        public GetByAccountsHeadTypeIdHandler(IAccountsHeadTypeRepository AccountsHeadTypeRepository, IMapper mapper)
        {
            _AccountsHeadTypeRepository = AccountsHeadTypeRepository;
            _mapper = mapper;
           
        }
        public async Task<VmAccountsHeadType> Handle(GetByAccountsHeadTypeId request, CancellationToken cancellationToken)
        {

           
            var result = await _AccountsHeadTypeRepository.GetById(request.id);
            return result;

        }

        
        
    }
}
