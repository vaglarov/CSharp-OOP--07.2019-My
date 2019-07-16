using System;

namespace MilitaryElite.Exceptions
{
    public class InvalidStateException : Exception
    {
        private const string INVALID_STATE_EXCEPTION = "Invalid Stae!";
        public InvalidStateException()
            :base(INVALID_STATE_EXCEPTION)
        {
        }

        public InvalidStateException(string message) 
            : base(message)
        {

        }
    }
}
