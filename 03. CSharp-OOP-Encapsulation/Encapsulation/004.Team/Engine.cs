namespace PersonsInfo
{
    using System;
    using System.Collections.Generic;

    public class Engine
    {
        public void Run()
        {
         

            List<int> ind = new List<int> { 1, 2, 5, 6, 8 };
            var result = ind.AsReadOnly();
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
    }
}
