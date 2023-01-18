using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadafa.SharedKernal.Domain.Entities
{
    public abstract class BaseEntity
    {
        protected Guid _id;
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}
