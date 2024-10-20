using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fin.VM
{
    public class VmAccountTransactionDtl
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