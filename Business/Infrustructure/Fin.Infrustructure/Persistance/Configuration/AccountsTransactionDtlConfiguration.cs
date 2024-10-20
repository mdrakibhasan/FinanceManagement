using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pos.Model;

namespace Pos.Infrustructure.Persistance.Configuration
{
    public class AccountsTransactionDtlConfiguration : IEntityTypeConfiguration<AccountTransactionDtl>
    {
        public void Configure(EntityTypeBuilder<AccountTransactionDtl> builder)
        {
            builder.ToTable("AccountTransactionDtl");

            builder.HasKey(x => x.Id);
            builder.Property(a => a.AccountsHeadId).IsRequired();
        }
    }
}
