using Pos.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Model
{
    public class AccountTransactionDtl : BaseEntity, IEntity
    {
        public int AccountTransactionMstID { get; set; }
        public AccountTransactionMst AccountTransactionMst { get; set; }
        public int AccountsHeadId { get; set; }
        public AccountsHead AccountsHead { get; set; }
        public decimal? CreditedAmount { get; set; }
        public int LineNo { get; set; }
        public decimal? DebitedAmount { get; set; }
        public string Particulars { get; set; }
    }
}
