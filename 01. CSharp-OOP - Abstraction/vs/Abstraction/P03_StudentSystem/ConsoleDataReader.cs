using System;
using System.Collections.Generic;
using System.Text;

namespace P03_StudentSystem
{
    public class ConsoleDataReader : IDataReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
