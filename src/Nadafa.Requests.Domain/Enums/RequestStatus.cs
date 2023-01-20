using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadafa.Requests.Domain.Enums
{
    public enum RequestStatus
    {
        Pending = 0,
        OnTheWayToPick = 1,
        PickedAndPaid = 2,
        Canceled = 3,
    }
}
