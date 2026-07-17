using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.Shared.Exceptions
{
    public sealed class ValidationException : BaseException
    {
        public ValidationException(string message)
            : base(message)
        {
        }
    }
}
