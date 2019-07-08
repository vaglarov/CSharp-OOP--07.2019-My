namespace PersonsInfo
{
    using System;
    using System.Collections.Generic;

    public class Engine
    {
        public void Run()
        {
            try
            {
                string firsName = Console.ReadLine();
                string lastNane = Console.ReadLine();
                int age = int.Parse(Console.ReadLine());
                decimal salary = decimal.Parse(Console.ReadLine());
                Person test = new Person(firsName, lastNane, age, salary);
                Console.WriteLine(test);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }


        }
    }
}
