using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using Pos.Infrustructure;
using Pos.IRepository;
using Pos.Model;
using Pos.Repository.IRepository;
using Pos.Service.Model;
using Pos.Shared;
using Pos.Shared.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Repository.Repository
{
    public class AccountsHeadRepository: RepositoryBase<AccountsHead, VmAccountsHead, int>, IAccountsHeadRepository
    {
        private readonly IMapper _mapper;
        private readonly PosDbContext _dbContext;
        public AccountsHeadRepository(IMapper mapper, PosDbContext dbContext) : base(mapper, dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<VmAccountsHead>> GetAccountsTypeOnlyRoot()
        {
            
            var Data = _dbContext.AccountsHeads.Where(a => a.RootLeaf == "R").AsAsyncEnumerable();
            var _vmAccountsHeads = _mapper.Map<IEnumerable<VmAccountsHead>>(Data);
            
            return _vmAccountsHeads;
        }
        public async Task<IEnumerable<VmAccountsHead>> GetAccountsTypeOnlyChield()
        {
            
            var Data = _dbContext.AccountsHeads.Where(a => a.RootLeaf == "L").AsAsyncEnumerable();
            var _vmAccountsHeads = _mapper.Map<IEnumerable<VmAccountsHead>>(Data);

            return _vmAccountsHeads;
        }
        public async Task<bool> GetAccountsCodeExist(string code ,int? id)
        {            
            var Data = await _dbContext.AccountsHeads.AnyAsync(a => a.Code == code && (id==0 || id==null || a.Id!= id));            
            return Data;
        }

        public async Task<IEnumerable<VmAccountsHead>> GetAccountsType()
        {
            

            var Data =  _dbContext.AccountsHeads.Include(a => a.HeadLeaf).Where(a=>a.RootId==null).AsAsyncEnumerable();
            var _vmAccountsHeads = _mapper.Map<IEnumerable<VmAccountsHead>>(Data);
            foreach (var data in _vmAccountsHeads)
            {
                if (data.RootLeaf != "L")
                {
                    data.HeadLeaf = await GetAccountsTypeLeafList(data);
                }

            }
            return _vmAccountsHeads;
        }
        public async Task<IEnumerable<VmAccountsHead>> GetAccountsHEadByRootId( int Id)
        {
            

            var Data =  _dbContext.AccountsHeads.Where(a=>a.RootId==Id).AsAsyncEnumerable();
            var _vmAccountsHeads = _mapper.Map<IEnumerable<VmAccountsHead>>(Data);
            
            return _vmAccountsHeads;
        }
        public async Task<IEnumerable<VmAccountsHead>> GEtFirstLevelPArent()
        {


            var Data = _dbContext.AccountsHeads.Where(a => a.RootId == null).AsAsyncEnumerable();
            var _vmAccountsHeads = _mapper.Map<IEnumerable<VmAccountsHead>>(Data);

            return _vmAccountsHeads;
        }
        // Call Back Function for Accounts Head > Child List
        public async Task<List<VmAccountsHead>> GetAccountsTypeLeafList(VmAccountsHead aVmAccountsHead)
        {
            if (aVmAccountsHead.HeadLeaf.Count > 0)
            {
                foreach (var data in aVmAccountsHead.HeadLeaf)
                {
                    if (data.RootLeaf != "L")
                    {
                        var Datarec = await _dbContext.AccountsHeads.Where(a => a.RootId == data.Id).Include(a => a.HeadLeaf).ToListAsync();
                        var datavm = _mapper.Map<List<VmAccountsHead>>(Datarec);
                        foreach (VmAccountsHead data2 in datavm)
                        {
                            data2.HeadLeaf = await GetAccountsTypeLeafList(data2);
                        }
                        data.HeadLeaf = datavm;
                    }
                }
            }
            return aVmAccountsHead.HeadLeaf;
        }
    }
}
