using BirthdayCelebr.Interfaces;
using BirthdayCelebr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BirthdayCelebr.Core
{
    public class Engine
    {
        private List<IItemWithBirthDate> civilians;
        public Engine()
        {
            this.civilians = new List<IItemWithBirthDate>();
        }
        public void Run()
        {
            try
            {

                string input = Console.ReadLine();
                while (input != "End")
                {
                    Queue<string> inputArgs = new Queue<string>(input.Split(" ", StringSplitOptions.RemoveEmptyEntries));
                    string type = inputArgs.Dequeue();
                    if (type == "Citizen")
                    {
                        string name = inputArgs.Dequeue();
                        int age = int.Parse(inputArgs.Dequeue());
                        string id = inputArgs.Dequeue();

                        DateTime date = DateFactory(inputArgs.Dequeue());
                        CitizenWithBirthDate citizen = new CitizenWithBirthDate(name, age, id, date);
                        civilians.Add(citizen);
                    }
                    else if (type == "Pet")
                    {
                        string name = inputArgs.Dequeue();

                        DateTime date = DateFactory(inputArgs.Dequeue());
                        Pet pet = new Pet(name, date);
                        civilians.Add(pet);
                    }


                    input = Console.ReadLine();
                }
                int year = int.Parse(Console.ReadLine());
                List<IItemWithBirthDate> result = civilians.Where(x => x.BirthInCurrentYear(year)).ToList();

                PrintResult(result);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }

        private DateTime DateFactory(string line)
        {
            string[] lineArgs = line.Split('/');
            int day = int.Parse(lineArgs[0]);
            int month = int.Parse(lineArgs[1]);
            int year = int.Parse(lineArgs[2]);
            DateTime date = new DateTime(year, month, day);
            return date;
        }

        private void PrintResult(List<IItemWithBirthDate> result)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (result.Count == 0)
            {
              
            }
            else
            {

                foreach (var item in result)
                {
                    Console.WriteLine(item);
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
