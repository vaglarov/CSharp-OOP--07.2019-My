using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Engine
    {
        public void Run()
        {
            try
            {
                string name = Console.ReadLine();
                int age = int.Parse(Console.ReadLine());
                Child person = new Child(name, age);
                Console.WriteLine(person);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }
}
