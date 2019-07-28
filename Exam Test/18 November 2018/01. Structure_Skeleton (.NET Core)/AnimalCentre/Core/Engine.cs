using AnimalCentre.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Core
{
    public class Engine : IEngine

    {
        private AnimalCentre zoo;
        public Engine()
        {
            this.zoo = new AnimalCentre();
        }
        public void Run()
        {
            string line = Console.ReadLine();
            while (line != "End")
            {
                try
                {
                    string[] arg = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string command = arg[0];
                    string[] argumets = arg.Skip(1).ToArray();
                    string resultCommand=ReadCommand(command, argumets);
                    Console.WriteLine(resultCommand);

                }
                catch (InvalidOperationException ex) 
                {

                    Console.WriteLine("InvalidOperationException: "+ex.Message); ;
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine("ArgumentException: "+ex.Message);
                }

                line = Console.ReadLine();
            }
            string result=this.zoo.AllAdoptedAnnimal();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(result);
            Console.ForegroundColor = ConsoleColor.White;
        } 

        private string ReadCommand(string command, string[] argumets)
        {
            Queue<string> line = new Queue<string>(argumets);
            string typeAnimal;
            string name;
            int energy;
            int happiness;
            int procedureTime;
            string owner;
            string historyType;
            switch (command)
            {
                case "RegisterAnimal":
                    typeAnimal = line.Dequeue();
                    name = line.Dequeue();
                    energy = int.Parse(line.Dequeue());
                    happiness = int.Parse(line.Dequeue());
                    procedureTime = int.Parse(line.Dequeue());
                    return zoo.RegisterAnimal(typeAnimal, name, energy, happiness, procedureTime);
                  
                    break;
                case "Chip":
                    name = line.Dequeue();
                    procedureTime = int.Parse(line.Dequeue());
                    return zoo.Chip(name, procedureTime);
                    break;
                case "Vaccinate":
                    name = line.Dequeue();
                    procedureTime = int.Parse(line.Dequeue());
                    return zoo.Vaccinate(name, procedureTime);
                    break;
                case "Fitness":
                    name = line.Dequeue();
                    procedureTime = int.Parse(line.Dequeue());
                    return zoo.Fitness(name, procedureTime);
                    break;
                case "Play":
                    name = line.Dequeue();
                    procedureTime = int.Parse(line.Dequeue());
                    return zoo.Play(name, procedureTime);
                    break;
                case "DentalCare":
                    name = line.Dequeue();
                    procedureTime = int.Parse(line.Dequeue());
                    return  zoo.DentalCare(name, procedureTime);
                    break;
                case "NailTrim":
                    name = line.Dequeue();
                    procedureTime = int.Parse(line.Dequeue());
                    return zoo.NailTrim(name, procedureTime);
                    break;
                case "Adopt":
                    name = line.Dequeue();
                    owner = line.Dequeue();
                    return zoo.Adopt(name, owner);
                    break;
                case "History":
                    historyType = line.Dequeue();
                    return zoo.History(historyType);
                    break;
                default:
                    return "Wrong input";
                    break;
            }
        }
    }
}
