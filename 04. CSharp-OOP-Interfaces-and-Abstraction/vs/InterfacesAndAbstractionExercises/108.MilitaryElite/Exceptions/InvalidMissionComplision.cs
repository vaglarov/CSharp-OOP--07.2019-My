using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Exceptions
{
    public class InvalidMissionComplision : Exception
    {
        private const string INVALID_MISSION_COMP = "Invalid mission complision!";
        public InvalidMissionComplision()
            : base(INVALID_MISSION_COMP)
        {
        }

        public InvalidMissionComplision(string message)
            : base(message)
        {
        }
    }
}
