using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Pos.Model;
using Pos.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Infrustructure.Persistance.Configuration
{
    internal class AccountsHeadTypeConfigaration : IEntityTypeConfiguration<AccountsHeadType>
    {
        public void Configure(EntityTypeBuilder<AccountsHeadType> builder)
        {
            builder.ToTable("AccountsHeadTypes");

            builder.HasKey(x => x.Id);
            builder.Property(a => a.Key).IsRequired();
          
        }
    }
}
