using Pos.Model;
using Pos.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Service.Model
{
    public class VmAccountsReportSetting : IVm
    {
        public string ReportName { get; set; }
        public string ReportType { get; set; }
        public DateTime? OpeningDate { get; set; }
        public int? CompanyId { get; set; }
        public List<VmAccountsReportSettingDetails> accountsReportSettingDetails { get; set; }
        public int Id { get; set; }
    }
}
