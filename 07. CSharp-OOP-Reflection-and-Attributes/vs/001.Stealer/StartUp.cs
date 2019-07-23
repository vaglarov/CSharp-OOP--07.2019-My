
using System;


    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy newSpy = new Spy();
            string result = newSpy.StealFieldInfo("Hacker", "username", "password");
            Console.WriteLine(result);
        }
    }

