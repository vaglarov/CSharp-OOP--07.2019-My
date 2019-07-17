using BirthdayCelebr.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebr.Models
{
    public class CitizenWithBirthDate : Citizen, ICitizenWihtBirthDate
    {
        public CitizenWithBirthDate(string name, int age, string id, DateTime date)
            : base(name, age, id)
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
