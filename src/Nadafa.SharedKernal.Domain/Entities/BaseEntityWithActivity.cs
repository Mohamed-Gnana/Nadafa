using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadafa.SharedKernal.Domain.Entities
{
    public abstract class BaseEntityWithActivity: BaseEntity
    {
        public DateTimeOffset CreatedDate { get; private set; }
        public Guid? CreatedBy { get; private set; }

        public DateTimeOffset UpdatedDate { get; private set; }
        public Guid? UpdateBy { get; private set; }

        public void MarkAsCreated(Guid? userId)
        {
            CreatedBy = userId;
            CreatedDate = DateTimeOffset.Now;
        }

        public void MarkAsModified(Guid? userId)
        {
            UpdateBy = userId;
            UpdatedDate = DateTimeOffset.Now;
        }
    }
}
