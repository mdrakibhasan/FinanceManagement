using Pos.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Shared
{
    public class BaseEntity : IEntity
    {
        public DateTimeOffset Created { get; set; } = DateTimeOffset.UtcNow;

        public string CreatedBy { get; set; } = string.Empty;

        public DateTimeOffset? LastModified { get; set; }

        public string? LastModifiedBy { get; set; }

        public EntityStatus Status { get; set; }
        public int Id { get; set; }
    }
}
