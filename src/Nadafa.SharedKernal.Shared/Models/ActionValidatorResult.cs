using Nadafa.SharedKernal.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadafa.SharedKernal.Shared.Models
{
    public class ActionValidatorResult
    {
        public ActionValidationStatus Status { get; set; }
        public string? Message { get; set; }
    }
}
