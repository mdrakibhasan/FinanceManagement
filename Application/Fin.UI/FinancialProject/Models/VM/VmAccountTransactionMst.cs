using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fin.VM
{ 
    public class VmAccountTransactionMst
    {
        public int? CompanyId { get; set; }
        public string AuthRef { get; set; }
        public int? AuthRefId { get; set; }
        public string VoucherType { get; set; }
        public DateTimeOffset VoucherDate { get; set; }
        public string VoucherNo { get; set; }
        public string ManualVoucherNo { get; set; }
        public decimal CreditedAmount { get; set; }
        public decimal DebitedAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public string AuthBy { get; set; }
        public string AuthDate { get; set; }
        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public string FileType { get; set; }
        public string Particulars { get; set; }
        public int Id { get; set; }
        public List<VmAccountTransactionDtl> AccountsDtl { get; set; }
    }
}