using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadafa.SharedKernal.Domain.Extensions
{
    public static class StringExtensions
    {
        public static Guid? ToGuidOrNull(this string? id)
        {
            Guid userId;
            if (Guid.TryParse(id, out userId) == false) return null;
            return userId;

        }
    }
}
