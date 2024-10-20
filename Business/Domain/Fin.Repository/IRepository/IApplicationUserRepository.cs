using Pos.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Repository.IRepository
{
    public interface IApplicationUserRepository
    {
        Task<LoginResponse> UserLogin(string username, string password);
    }
}
