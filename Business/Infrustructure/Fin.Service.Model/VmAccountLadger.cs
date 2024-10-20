using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Service.Model
{
    public class VmAccountLadger
    {
        public string HeadName { get; set; }
        public string VoucherNo { get; set; }
        public int? CompanyId { get; set; }
        public string Particulars { get; set; }
        public string ManualVoucherNo { get; set; }
        public string VoucherType { get; set; }
        public string VoucherDate { get; set; }
        public decimal? DebitedAmount { get; set; }
        public decimal? CreditedAmount { get; set; }

        public decimal? PrevDebitedAmount { get; set; }
        public decimal? PrevCreditedAmount { get; set; }
        public decimal? PrevBalance { get; set; }
        public decimal Balance { get; set; }
        public int LineNo { get; set; }
        public int Id { get; set; }
        public int TranMstId { get; set; }
    }
}
