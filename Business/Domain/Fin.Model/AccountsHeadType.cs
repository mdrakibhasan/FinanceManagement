using Pos.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Model
{
    public class AccountsHeadType: BaseEntity, IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public char Key { get; set; }
    }
}
