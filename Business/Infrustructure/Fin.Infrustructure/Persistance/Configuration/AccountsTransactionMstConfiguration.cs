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
    internal class AccountsTransactionMstConfiguration : IEntityTypeConfiguration<AccountTransactionMst>
    {
        public void Configure(EntityTypeBuilder<AccountTransactionMst> builder)
        {
            builder.ToTable("AccountTransactionMst");

            builder.HasKey(x => x.Id);
            builder.Property(a => a.VoucherType).IsRequired();
            builder.Property(a => a.VoucherDate).IsRequired();
            builder.Property(a => a.VoucherNo).IsRequired();
            builder.Property(a => a.TotalAmount).IsRequired();
            builder.Property(a => a.CreditedAmount).IsRequired();
            builder.Property(a => a.DebitedAmount).IsRequired();
        }
    }
}
