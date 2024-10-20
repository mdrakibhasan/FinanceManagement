using Pos.Model;
using Pos.Service.Model;
using Pos.Shared.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.IRepository
{
    public interface IAccountsHeadTypeRepository : IRepository<AccountsHeadType, VmAccountsHeadType, int>
    {
    }
}
