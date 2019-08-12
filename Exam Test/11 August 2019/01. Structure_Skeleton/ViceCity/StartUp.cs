using ViceCity.Core;
using ViceCity.Core.Contracts;
using System;

namespace ViceCity
{
    public class StartUp
    {
        IEngine engine;
        static void Main(string[] args)
        {
            //IEngine engine = new Engine();
            //engine.Run();

            IController cntr = new Controller();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Exit")
            {
                string[] commandLine = input.Split();
                string command = commandLine[0];
                string first = string.Empty;
                string second = string.Empty;

                if (commandLine.Length > 1)
                {
                    first = commandLine[1];
                }
                if (commandLine.Length > 2)
                {
                    second = commandLine[2];
                }

                try
                {
                    switch (command)
                    {
                        case "AddPlayer":
                            Console.WriteLine(cntr.AddPlayer(first));
                            break;
                        case "AddGun":
                            Console.WriteLine(cntr.AddGun(first, second));
                            break;
                        case "AddGunToPlayer":
                            Console.WriteLine(cntr.AddGunToPlayer(first));
                            break;
                        case "Fight":
                            Console.WriteLine(cntr.Fight());
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }
    }
}
