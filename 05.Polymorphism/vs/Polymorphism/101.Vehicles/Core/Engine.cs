using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Models;

namespace Vehicles.Core
{
    public class Engine
    {
        public Engine()
        {

        }
        public void Run()
        {
            Car car = CarFactory(Console.ReadLine());
            Truck truck = TruckFactory(Console.ReadLine());
            int numberCommands = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberCommands; i++)
            {
                string[] lineCommands = Console.ReadLine().Split();
                string command = lineCommands[0];
                string commandType = lineCommands[1];
                if (command == "Drive")
                {
                    double distance = double.Parse(lineCommands[2]);
                    if (commandType == "Car")
                    {
                        Console.WriteLine(car.Drive(distance));
                    }
                    else
                    {
                        Console.WriteLine(truck.Drive(distance));
                    }

                }
                else if (command == "Refuel")
                {
                    double addQuantity = double.Parse(lineCommands[2]);
                    if (commandType == "Car")
                    {
                        car.Refuel(addQuantity);
                    }
                    else
                    {
                       truck.Refuel(addQuantity);
                    }

                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

        private Truck TruckFactory(string lineInput)
        {
            string[] carArg = lineInput.Split();
            double FuelQuantit = double.Parse(carArg[1]);
            double FuelConsumption = double.Parse(carArg[2]);
            Truck truck = new Truck(FuelQuantit, FuelConsumption);
            return truck;
        }

        private Car CarFactory(string lineInput)
        {
            string[] carArg = lineInput.Split();
            double FuelQuantit = double.Parse(carArg[1]);
            double FuelConsumption = double.Parse(carArg[2]);
            Car car = new Car(FuelQuantit, FuelConsumption);
            return car;
        }
    }
}
