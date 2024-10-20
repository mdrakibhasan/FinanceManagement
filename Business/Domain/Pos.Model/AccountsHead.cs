using Pos.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pos.Model
{
    public class AccountsHead : BaseEntity, IEntity
    {
        public string HeadName
        {
            get; set;
        }
        public string RootLeaf { get; set; }
        public string HeadType  {get; set;}
        public DateTime? OpeningDate { get; set; }
        public decimal? OpeningBal { get; set; }
        public int? CompanyId { get; set; }
        public bool? isCashOrBank { get; set; }
        public int? RootId { get; set; }
        [JsonIgnore]
        public AccountsHead Root { get; set; }
        public string Code { get; set; }
        public int AccountsHeadTypeId { get; set; }
        [JsonIgnore]
        public AccountsHeadType AccountsHeadType { get; set; }
        public List<AccountsHead> HeadLeaf { get; set; }
        public List<AccountTransactionDtl> AccountTransasction { get; set; }
    }
}
