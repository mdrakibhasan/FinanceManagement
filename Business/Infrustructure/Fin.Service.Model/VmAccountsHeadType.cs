using Pos.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Service.Model
{
    public class VmAccountsHeadType:IVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public char Key { get; set; }
    }
}
