using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Pos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Infrustructure.Persistance.Configuration
{
    internal class AccountsHeadConfigaration : IEntityTypeConfiguration<AccountsHead>
    {
        public void Configure(EntityTypeBuilder<AccountsHead> builder)
        {
            builder.ToTable("AccountsHeads");

            builder.HasKey(x => x.Id);
            builder.Property(a => a.RootLeaf).IsRequired();
            builder.Property(a => a.Code).IsRequired();
            builder.HasIndex(a => a.Code).IsUnique();
            builder.Property(a => a.HeadName).IsRequired();
            builder.Property(a => a.HeadType).IsRequired();
            builder.Property(a => a.AccountsHeadTypeId).IsRequired();
        }
    }
}
