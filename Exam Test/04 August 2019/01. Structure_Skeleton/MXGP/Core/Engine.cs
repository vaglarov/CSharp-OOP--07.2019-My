using MXGP.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Core
{
    public class Engine : IEngine

    {
        public Engine()
        {

        }

        public void Run()
        {
            ChampionshipController controler = new ChampionshipController();

            string command = Console.ReadLine();
            while (command != "End")
            {
                try
                {
                    var commandPasser = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    if (commandPasser[0] == "CreateRider")
                    {
                        string nameRider = commandPasser[1];
                        string result = controler.CreateRider(nameRider);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(result);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (commandPasser[0] == "CreateMotorcycle")
                    {
                        // Speed Honda 60
                        string type = commandPasser[1];
                        string model= commandPasser[2];
                        int horsePower = int.Parse(commandPasser[3]);
                        string result = controler.CreateMotorcycle(type, model, horsePower);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(result);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (commandPasser[0]== "CreateRace")
                    {
                        //Loket 2
                        string nameRace = commandPasser[1];
                        int laps = int.Parse(commandPasser[2]);
                        string result = controler.CreateRace(nameRace, laps);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(result);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (commandPasser[0]== "AddMotorcycleToRider")
                    {
                        string riderName = commandPasser[1];
                        string motorName = commandPasser[2];
                        string result = controler.AddMotorcycleToRider(riderName, motorName);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(result);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (commandPasser[0]== "StartRace")
                    {
                        string nameRase = commandPasser[1];
                        string result = controler.StartRace(nameRase);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(result);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (commandPasser[0] == "AddRiderToRace")
                    {
                        string nameRase = commandPasser[1];
                        string nameRider = commandPasser[2];
                        string result = controler.AddRiderToRace(nameRase, nameRider);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(result);
                        Console.ForegroundColor = ConsoleColor.White;
                    }

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
