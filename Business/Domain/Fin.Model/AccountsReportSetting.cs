using Pos.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pos.Model
{
    public class AccountsReportSetting : BaseEntity, IEntity
    {
        public string ReportName { get; set; }
        public string ReportType { get; set; }
        public DateTime? OpeningDate { get; set; }
        public int? CompanyId { get; set; }
        public List<AccountsReportSettingDetails> accountsReportSettingDetails  { get; set; }
    }
}
