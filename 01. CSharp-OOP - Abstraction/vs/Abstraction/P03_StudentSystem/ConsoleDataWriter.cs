﻿namespace P03_StudentSystem
{
using System;
    public class ConsoleDataWriter : IDataWriter
    {
        public void Write(object obj)
        {
            Console.Write(obj);
        }
    }
}
