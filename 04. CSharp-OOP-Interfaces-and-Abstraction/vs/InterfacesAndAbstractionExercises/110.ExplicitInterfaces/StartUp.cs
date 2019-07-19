using ExplicitInterfaces.Interfaces;
using System;
using System.Collections.Generic;

namespace ExplicitInterfaces
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            while (line!="End")
            {
                string[] lineArg = line.Split();

                Citizen current = CitizenFzctory(lineArg);
                IPerson person = (IPerson)current;
                IResident resident = (IResident)current;
                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());

                line = Console.ReadLine();
            }
        }

        private static Citizen CitizenFzctory(string[] lineArg)
        {
            string name = lineArg[0];
            string country = lineArg[1];
            int age= int.Parse(lineArg[2]);
            Citizen current = new Citizen(name, country, age);
            return current;
        }
    }
}
