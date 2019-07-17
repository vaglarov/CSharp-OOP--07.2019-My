using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebr.Interfaces
{
    public interface ICivilian:IItem
    {
        string Id { get; }
        bool GetWithEndId(string endArg);
    }
}
