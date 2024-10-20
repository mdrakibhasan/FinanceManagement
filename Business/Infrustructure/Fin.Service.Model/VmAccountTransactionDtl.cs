using Pos.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Service.Model
{
    public class VmAccountTransactionDtl:IVm
    {
        public int AccountTransactionMstID { get; set; }
        public int AccountsHeadId { get; set; }
        public decimal? CreditedAmount { get; set; }
        public decimal? DebitedAmount { get; set; }
        public int LineNo { get; set; }
        public string Particulars { get; set; }
        public string HeadName { get; set; }
        public int Id { get; set; }

    }
}
