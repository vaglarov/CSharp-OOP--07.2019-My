namespace BorderControl.Model
{
    using BorderControl.Interfaces;
    using System;
    using BorderControl.Exception;
    public class Citizen : ICitizen
    {
        private string name;
        private int age;
        private string id;

        public Citizen(string name, int age, string id,int inputNumber)
        {
           this.Name = name;
           this.Age = age;
           this.Id = id;
            this.InputNumber = inputNumber;
        }
        public int InputNumber { get; set; }

        public string Name
        {
            get
            { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessage.NameIsNulleOrEmpty);
                }
                this.name = value;
            }
        }

        public int Age
        {
            get
            { return this.age; }
            private set
            {
                this.age = value;
            }
        }

        public string Id
        {
            get
            { return this.id; }
            private set
            {
                this.id = value;
            }
        }
    }
}
