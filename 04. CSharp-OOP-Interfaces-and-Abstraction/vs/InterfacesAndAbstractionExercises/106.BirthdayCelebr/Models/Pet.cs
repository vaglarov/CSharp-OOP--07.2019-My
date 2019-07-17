using BirthdayCelebr.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebr.Models
{
    public class Pet : Item, IItemWithBirthDate
    {
        public Pet(string name, DateTime date)
            : base(name)
        {
            this.Date = date;
        }

        public DateTime Date
        {
            get;
            private set;
        }
        public bool BirthInCurrentYear(int year)
        {
            return this.Date.Year == year;
        }
        public override string ToString()
        {
            return $"{this.Date.Day:d2}/{this.Date.Month:d2}/{this.Date.Year}";
        }
    }
}
