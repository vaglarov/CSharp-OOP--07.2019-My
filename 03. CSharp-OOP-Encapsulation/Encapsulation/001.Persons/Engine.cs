namespace PersonsInfo
{
using System;
    public class Engine
    {
        public void Run()
        {
            Person newPerson = new Person("Az", "Azzz", 22);
            Console.WriteLine(newPerson);
        }
    }
}
