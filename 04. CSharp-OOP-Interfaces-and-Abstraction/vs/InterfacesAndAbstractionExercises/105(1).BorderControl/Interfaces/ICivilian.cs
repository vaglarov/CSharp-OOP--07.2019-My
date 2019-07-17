using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl2.Interfaces
{
    public interface ICivilian
    {
        string Name { get; }
        string Id { get; }
        bool GetWithEndId(string endArg);
    }
}
