
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fin.VM
{
    public class VmAccountsHead
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
        public int AccountsHeadTypeId { get; set; }
        public string AccountsHeadTypeName { get; set; }
        public int Id { get; set; }
        public List<VmAccountsHead> HeadLeaf { get; set; }
       
    }
}
