using System;


    public class StartUp
    {
        static void Main(string[] args)
        {
        Spy newSpy = new Spy();
        string result = newSpy.AnalyzeAcessModifiers("Hacker");
        Console.WriteLine(result);
    }
    }

