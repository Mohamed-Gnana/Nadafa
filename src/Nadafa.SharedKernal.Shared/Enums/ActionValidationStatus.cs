using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadafa.SharedKernal.Shared.Enums
{
    public enum ActionValidationStatus
    {
        Unauthorized = 1,
        Forbidden = 2,
        NotFound = 3,
        Continue = 5,
    }
}
