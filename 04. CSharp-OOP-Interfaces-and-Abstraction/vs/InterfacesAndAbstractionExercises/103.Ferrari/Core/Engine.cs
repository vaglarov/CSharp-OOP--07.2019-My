namespace _103.Ferrari.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using _103.Ferrari.Model;
    public class Engine
    {
        public Engine()
        {

        }
        public void Run()
        {
            string driverName = Console.ReadLine();
            Ferrari ferrari = new Ferrari(driverName);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ferrari);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
