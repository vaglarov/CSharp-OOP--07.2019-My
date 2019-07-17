using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl2.Interfaces
{
    public interface ICitizen:ICivilian
    {
        int Age { get; }
    }
}
