using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebr.Exceptions
{
    public class InvalidIDException:Exception
    {
        private const string EXC_MESSAGE = "ID can not be null or white spase!";
        public InvalidIDException()
            :base(EXC_MESSAGE)
        {

        }
        public InvalidIDException(string message)
        : base(message)
        {

        }
    }
}
