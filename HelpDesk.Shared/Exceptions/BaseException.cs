using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.Shared.Exceptions
{
    public abstract class BaseException : Exception
    {
        protected BaseException(string message) : base(message)
        {
        }
    }
}
