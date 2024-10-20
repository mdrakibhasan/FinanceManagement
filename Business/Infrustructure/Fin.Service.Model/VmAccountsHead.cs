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
    public class VmAccountsHead:IVm
    {
        public string HeadName
        {
            get; set;
        }
        public string RootLeaf { get; set; }
        public string HeadType { get; set; }
        public DateTime? OpeningDate { get; set; }
        public decimal? OpeningBal { get; set; }
        public int? RootId { get; set; }
        public string RootName { get; set; }
        public string Code { get; set; }
        public int? CompanyId { get; set; }
        public int AccountsHeadTypeId { get; set; }
        public string AccountsHeadTypeName { get; set; }
        public int Id { get; set; }
        public List<VmAccountsHead> HeadLeaf { get; set; }
        [JsonIgnore]
        public List<VmAccountTransactionDtl> AccountTransasction { get; set; }       
        public List<VmAccountLadger> vmAccountLadgers { get; set; }
    }
}
