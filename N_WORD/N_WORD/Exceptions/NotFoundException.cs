using NLog.Targets;
using System;

namespace N_WORD.Exceptions
{
    public class NotFoundException: Exception
    {
        public NotFoundException(string message) : base(message)
        {

        }
    }
}
