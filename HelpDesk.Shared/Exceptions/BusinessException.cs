using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.Shared.Exceptions
{
    public sealed class BusinessException : BaseException
    {
        public BusinessException(string message)
            : base(message)
        {
        }
    }
}
