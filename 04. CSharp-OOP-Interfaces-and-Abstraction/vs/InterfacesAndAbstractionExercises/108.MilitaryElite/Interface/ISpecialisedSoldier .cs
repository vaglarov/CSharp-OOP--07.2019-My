using MilitaryElite.Enumerator;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Interface
{
    public interface ISpecialisedSoldier:IPrivate
    {
        Corp Corps { get; }
    }
}
