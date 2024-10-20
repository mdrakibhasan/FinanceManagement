using Pos.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Service.Model
{
    public class VmAccountsTrialBalanceSheet:IVm
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int Level { get; set; }
        public List<VmAccountsHeadDetails> AccountsHeadDetails { get; set; }
        public int Id { get; set; }
    }
    public class VmAccountsHeadDetails
    {
        public string HeadName { get; set; }
        public int HeadId { get; set; }
        public string AccountCode { get; set; }
        public string AccountsType { get; set; }
        public string RootLeaf { get; set; }
        public decimal? PrevBalance { get; set; }
        public decimal? DebitedAmount { get; set; }
        public decimal? CreditedAmount { get; set; }
        public decimal? Balance { get; set; }

    }
}
