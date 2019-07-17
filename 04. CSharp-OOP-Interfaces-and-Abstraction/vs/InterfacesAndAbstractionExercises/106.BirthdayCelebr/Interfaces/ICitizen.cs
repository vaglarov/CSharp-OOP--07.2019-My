using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebr.Interfaces
{
    public interface ICitizen:ICivilian
    {
        int Age { get; }
    }
}
