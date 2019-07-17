using BorderControl2.Exceptions;
using BorderControl2.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl2.Models
{
    public class Citizen : Civilian, ICitizen
    {
        public Citizen(string name, int age, string id)
            :base(name,id)
        {
            ValidateAge(age);
        }

        private void ValidateAge(int age)
        {
            if (age<0)
            {
                throw new InvalidAgeException();
            }
            this.Age = age;
        }
        public int Age
        {
            get;
            private set;
        }
    }
}
