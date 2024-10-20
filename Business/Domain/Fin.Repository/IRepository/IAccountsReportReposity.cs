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
    public interface IAccountsReportReposity 
    {
        Task<VmAccountsTrialBalanceSheet> GetTrialBalance(int Level, DateTime FromDate, DateTime ToDate);
        Task<List<VmAccountLadger>> GetAccountsLadger(int AccountsHeadId, DateTime FromDate, DateTime ToDate);
        Task<VmAccountsHead> GetAccountsLadgerByRootId(int AccountsHeadId, DateTime FromDate, DateTime ToDate);
        Task<VmAccountsReportSetting> GetAccountsReportSettingsReport(int ReportSettingId, DateTime FromDate, DateTime ToDate);
    }
}
