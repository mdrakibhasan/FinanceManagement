using Pos.Model;
using Pos.Service.Model;
using Pos.Shared.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Repository.IRepository
{
    public interface IAccountsTransactionRepository : IRepository<AccountTransactionMst, VmAccountTransactionMst, int>
    {
        //Task<List<VmAccountLadger>> GetAccountsLadger(int AccountsHeadId, DateTime FromDate, DateTime ToDate);
        //Task<VmAccountsHead> GetAccountsLadgerByRootId(int AccountsHeadId, DateTime FromDate, DateTime ToDate);
        Task<VmAccountTransactionMst> GetTransactionDetails(int TranMstId);
    }
}
