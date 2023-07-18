using System;

namespace N_WORD.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message): base(message)
        {
        }
    }
}
