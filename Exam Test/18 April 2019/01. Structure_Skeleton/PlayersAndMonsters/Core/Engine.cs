using PlayersAndMonsters.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        private ManagerController controler;
        public Engine()
        {
            controler = new ManagerController();
        }
        public void Run()
        {
            string line = Console.ReadLine();
            while (line != "Exit")
            {
                try
                {
                    string[] lineArgs = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string result = string.Empty;
                    switch (lineArgs[0])
                    {
                        case "AddPlayer":
                            result = controler.AddPlayer(lineArgs[1], lineArgs[2]);
                            Console.WriteLine(result);
                            break;
                        case "AddCard":
                            result = controler.AddCard(lineArgs[1], lineArgs[2]);
                            Console.WriteLine(result);
                            break;
                        case "AddPlayerCard":
                            result = controler.AddPlayerCard(lineArgs[1], lineArgs[2]);
                            Console.WriteLine(result);
                            break;
                        case "Fight":
                            result = controler.Fight(lineArgs[1], lineArgs[2]);
                            Console.WriteLine(result);
                            break;
                        case "Report":
                            result = controler.Report();
                            Console.WriteLine(result);
                            break;
                    }

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

                line = Console.ReadLine();
            }
        }
    }
}
