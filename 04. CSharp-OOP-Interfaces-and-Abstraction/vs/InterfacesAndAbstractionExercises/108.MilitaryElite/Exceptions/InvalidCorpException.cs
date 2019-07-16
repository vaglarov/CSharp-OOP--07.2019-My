using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Exceptions
{
    public class InvalidCorpException:Exception
    {
        private const string EXC_MESSAGE = "Invalid corps!";
        public InvalidCorpException()
            :base(EXC_MESSAGE)
        {

        }
        public InvalidCorpException(string message)
            :base(message)
        {

        }
    }
}
