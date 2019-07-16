using MilitaryElite.Enumerator;
using MilitaryElite.Exceptions;
using MilitaryElite.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Model
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary,string corpsStr) 
            : base(id, firstName, lastName, salary)
        {
            ParseCorps(corpsStr);
        }


        public Corp Corps { get; private set; }

        private void ParseCorps(string corpsStr)
        {
            Corp corps;
            bool parsed = Enum.TryParse<Corp>(corpsStr, out corps);
            if (!parsed)
            {
                throw new InvalidCorpException();
            }
             this.Corps=corps;
        }
        public override string ToString()
        {
            return base.ToString() + Environment.NewLine +
                $"Corps: {this.Corps}";
        }
    }
}
