namespace P03_StudentSystem
{
    public class Student
    {
        public Student(string name, int age, double grade)
        {
            this.Name = name;
            this.Age = age;
            this.Grade = grade;
        }
        public string Name
        {
            get;
            private set;
        }
        public int Age
        {
            get;
            private set;
        }
        public double Grade
        {
            get;
            private set;
        }
        public override string ToString()
        {
            string message;

            if (this.Grade >= 5.00)
            {
                message = " Excellent student.";
            }
            else if (this.Grade < 5.00 && this.Grade >= 3.50)
            {
                message = " Average student.";
            }
            else
            {
                message = " Very nice person.";
            }
            return $"{this.Name} is {this.Age} years old.{message}";

        }

    }
}
