using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Interface
{
    public interface ICommando:ISpecialisedSoldier
    {
        IReadOnlyCollection<IMissions> Missions { get; }
        void Add(IMissions mission);
    }
}
