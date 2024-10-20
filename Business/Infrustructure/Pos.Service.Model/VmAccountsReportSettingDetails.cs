using Pos.Model;
using Pos.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pos.Service.Model
{
    public class VmAccountsReportSettingDetails : IVm
    {
        public int Id { get; set; }
        public int AccountsReportSettingId { get; set; }
        public string HeadingName { get; set; }
        public string AccountsType { get; set; }
        public string HeadType { get; set; }
        public string TotalType { get; set; }
        public string TotalLineNoList { get; set; }
        public int LineNo { get; set; }
        public int? AccountsHeadId { get; set; }
        public decimal? CreditedAmount { get; set; }
        public decimal? DevitedAmount { get; set; }
        public decimal? Balance { get; set; }

    }
}
