using BorderControl2.Interfaces;
using BorderControl2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BorderControl2.Core
{
    public class Engine
    {
        private List<ICivilian> civilians;
        public Engine()
        {
            this.civilians = new List<ICivilian>();
        }
        public void Run()
        {
            try
            {

            string input = Console.ReadLine();
            while (input!="End")
            {
                Queue<string> inputArgs = new Queue<string>(input.Split(" ", StringSplitOptions.RemoveEmptyEntries));
                if (inputArgs.Count==2)
                {
                    string model = inputArgs.Dequeue();
                    string id = inputArgs.Dequeue();
                    Robot robot = new Robot(model, id);
                    civilians.Add(robot);
                }
                else
                {
                    string model = inputArgs.Dequeue();
                    int age = int.Parse(inputArgs.Dequeue());
                    string id = inputArgs.Dequeue();
                    Citizen citizen = new Citizen(model,age,id);
                    civilians.Add(citizen);
                }

                input = Console.ReadLine();
            }
            string endID = Console.ReadLine();
            List<ICivilian> result = civilians.Where(x => x.GetWithEndId(endID)).ToList();
            PrintResult(result);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }

        private void PrintResult(List<ICivilian> result)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var item in result)
            {
                Console.WriteLine(item.Id);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
