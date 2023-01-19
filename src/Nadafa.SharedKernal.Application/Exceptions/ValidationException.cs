using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadafa.SharedKernal.Application.Exceptions
{
    public sealed class ValidationException : ApplicationException
    {
        public ValidationException(IReadOnlyDictionary<string, string[]> errorsDictionary)
            : base()
            => ErrorsDictionary = errorsDictionary;

        public IReadOnlyDictionary<string, string[]> ErrorsDictionary { get; }
    }
}
