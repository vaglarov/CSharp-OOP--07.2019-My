using MilitaryElite.Enumerator;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Interface
{
    public interface IMissions
    {
        string CodeName { get; }
        State State { get; }
        void CompleteMission();
    }
}
