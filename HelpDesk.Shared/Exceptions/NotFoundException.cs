using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.Shared.Exceptions
{
    public sealed class NotFoundException : BaseException
    {
        public NotFoundException(string message)
            : base(message)
        {
        }
    }
}
