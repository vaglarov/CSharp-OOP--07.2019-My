namespace PlayersAndMonsters
{
    using System;
    public class Runner
    {
        public void Run()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Wizard wizardTEst = new Wizard("Me", 123);
            Console.WriteLine(wizardTEst);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
