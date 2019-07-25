using System;
using System.Collections.Generic;
using System.Text;
using ValidationAttributes.Attributies;

namespace ValidationAttributes.Entities
{
    public class Person
    {
        private const int DAFAULT_MIN_AGE = 12;
        private const int DAFAULT_MAX_AGE = 90;
        public Person(string fullName,int age)
        {
            this.FullName = fullName;
            this.Age = age;
        }

        [MyRequiredAttribute]
        public string FullName { get;private set; }

        [MyRange(DAFAULT_MIN_AGE, DAFAULT_MAX_AGE)]
        public int Age { get; private set; }
    }
}
