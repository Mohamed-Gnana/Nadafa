﻿using Microsoft.AspNetCore.Http;
using Nadafa.SharedKernal.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadafa.SharedKernal.Application.Exceptions
{
    public class ForbiddenAccessException : BaseException
    {
        public ForbiddenAccessException()
        {
            StatusCode = StatusCodes.Status403Forbidden;
        }

        public ForbiddenAccessException(string message) : base(message)
        {
            StatusCode = StatusCodes.Status403Forbidden;
        }

        public ForbiddenAccessException(string message, Exception innerException)
            : base(message, innerException)
        {
            StatusCode = StatusCodes.Status403Forbidden;
        }

        public ForbiddenAccessException(string name, object key)
            : base($"Entity \"{name}\" ({key}) was not found.")
        {
            StatusCode = StatusCodes.Status403Forbidden;
        }
    }
}
