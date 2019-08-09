using PlayersAndMonsters.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            string command = Console.ReadLine();
            ManagerController date = new ManagerController();


            while (command != "Exit")
            {
                try
                {
                    string[] arg = command.Split();
                    string result = string.Empty;
                    switch (arg[0])
                    {
                        case "AddPlayer":
                            result = date.AddPlayer(arg[1], arg[2]);
                            break;
                        case "AddCard":
                            result = date.AddCard(arg[1], arg[2]);
                            break;
                        case "AddPlayerCard":
                            result = date.AddPlayerCard(arg[1], arg[2]);
                            break;
                        case "Fight":
                            result = date.Fight(arg[1], arg[2]);
                            break;
                        case "Report":
                            result = date.Report();
                            break;
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(result);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                    command = Console.ReadLine();
            }
        }
    }
}
