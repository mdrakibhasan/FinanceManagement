using AutoMapper;
using JetBrains.Annotations;
using MediatR;
using Pos.Core.AccountsHead.Query;
using Pos.Repository.IRepository;
using Pos.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pos.Core.User.Command
{
   
    public record LoginUser(string username, string password) : IRequest<LoginResponse>;

    public class LoginUserHandler : IRequestHandler<LoginUser, LoginResponse>
    {

        private readonly IApplicationUserRepository _AccountsHeadRepository;

        private readonly IMapper _mapper;

        public LoginUserHandler(IApplicationUserRepository AccountsHeadRepository, IMapper mapper)
        {
            _AccountsHeadRepository = AccountsHeadRepository;
            _mapper = mapper;

        }
        public async Task<LoginResponse> Handle(LoginUser request, CancellationToken cancellationToken)
        {


            var result = await _AccountsHeadRepository.UserLogin(request.username, request.password);
            return result;

        }

    }
}
