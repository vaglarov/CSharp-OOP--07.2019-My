using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebr.Interfaces
{
    public interface IItemWithBirthDate:IItem
    {
        DateTime Date { get; }
        bool BirthInCurrentYear(int year);
    }
}
