using MilitaryElite.Enumerator;
using MilitaryElite.Exceptions;
using MilitaryElite.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Model
{
    public class Mission : IMissions
    {
        public Mission(string codeNme,string state)
        {
            this.CodeName = codeNme;
            ParseState(state);
        }


        public string CodeName
        {
            get;
            private set;
        }

        public State State
        {
            get;
            private set;
        }


        public void CompleteMission()
        {
            if (this.State==State.Finished)
            {
                throw new InvalidMissionComplision();
            }
            this.State = State.Finished;
        }
        private void ParseState(string stateStr)
        {
            State state;
            bool parser = Enum.TryParse<State>(stateStr, out state);
            if (!parser)
            {
                throw new InvalidStateException();
            }
            this.State = state;
        }
        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
