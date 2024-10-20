using AutoMapper;
using Pos.Infrustructure;
using Pos.Model;
using Pos.Repository.IRepository;
using Pos.Service.Model;
using Pos.Shared.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Repository.Repository
{
    public class AccountsReportSettingRepository: RepositoryBase<AccountsReportSetting, VmAccountsReportSetting, int>,IAccountsReportSettingRepository
    {
        private readonly IMapper _mapper;
        private readonly PosDbContext _dbContext;

        public AccountsReportSettingRepository(IMapper mapper, PosDbContext dbContext) : base(mapper, dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
    }
}
