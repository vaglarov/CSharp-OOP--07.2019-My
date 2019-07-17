using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebr.Exceptions
{
    public class InvalidNameException : Exception
    {
        private const string EXC_MESSAGE = "Name can not be null or whitespace!";
        public InvalidNameException()
            : base(EXC_MESSAGE)
        {

        }
        public InvalidNameException(string message)
            : base(message)
        {

        }
    }
}
