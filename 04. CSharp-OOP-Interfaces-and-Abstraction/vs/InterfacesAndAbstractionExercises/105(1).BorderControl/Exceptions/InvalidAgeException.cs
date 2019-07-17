using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl2.Exceptions
{
    public class InvalidAgeException : Exception
    {
        private const string AGE_EXC = "Age must be 0 or positive!";
        public InvalidAgeException()
            :base(AGE_EXC)
        {
        }

        public InvalidAgeException(string message)
            : base(message)
        {
        }
    }
}
