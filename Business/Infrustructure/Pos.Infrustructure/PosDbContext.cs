using Microsoft.EntityFrameworkCore;
using Pos.Model;
using System;

namespace Pos.Infrustructure
{
    public class PosDbContext:DbContext
    {
		public PosDbContext(DbContextOptions<PosDbContext> options) : base(options)
		{


		}
        public DbSet<AccountsHead> AccountsHeads { get; set; }
        public DbSet<AccountTransactionMst> AccountTransactionMst { get; set; }
        public DbSet<AccountTransactionDtl> AccountTransactionDtl { get; set; }
        public DbSet<AccountsReportSetting> AccountsReportSettings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(PosDbContext).Assembly);
		}

	}
}
