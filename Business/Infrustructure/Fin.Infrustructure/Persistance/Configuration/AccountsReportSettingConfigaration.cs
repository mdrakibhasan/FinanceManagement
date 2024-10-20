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
    internal class AccountsReportSettingConfigaration : IEntityTypeConfiguration<AccountsReportSetting>
    {
        public void Configure(EntityTypeBuilder<AccountsReportSetting> builder)
        {
            builder.ToTable("AccountsReportSettings");

            builder.HasKey(x => x.Id);

        }
    }
}

