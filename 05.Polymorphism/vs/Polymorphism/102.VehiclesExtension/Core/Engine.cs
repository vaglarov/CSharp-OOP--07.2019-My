using System;
using System.Collections.Generic;
using System.Text;
using VehiclesExtension.Models;

namespace VehiclesExtension.Core
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
            Bus bus = BusFActory(Console.ReadLine());
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
                    else if (commandType == "Truck")
                    {
                        Console.WriteLine(truck.Drive(distance));
                    }
                    else
                    {
                        Console.WriteLine(bus.Drive(distance));

                    }

                }
                else if (command == "Refuel")
                {
                    try
                    {


                        double addQuantity = double.Parse(lineCommands[2]);
                        if (commandType == "Car")
                        {
                            car.Refuel(addQuantity);
                        }
                        else if (commandType == "Truck")
                        {
                            truck.Refuel(addQuantity);
                        }
                        else
                        {
                            bus.Refuel(addQuantity);
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                        continue;
                    }

                }
                else
                {
                    double distance = double.Parse(lineCommands[2]);

                    Console.WriteLine(bus.DriveEmpty(distance));
                }
            }
            PrintResult(car, truck, bus);

        }

        private void PrintResult(Car car, Truck truck, Bus bus)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private Bus BusFActory(string lineInput)
        {
            string[] carArg = lineInput.Split();
            double fuelQuantit = double.Parse(carArg[1]);
            double fuelConsumption = double.Parse(carArg[2]);
            double tankCapacity = double.Parse(carArg[3]);

            Bus bus = new Bus(fuelQuantit, fuelConsumption, tankCapacity);
            return bus;
        }

        private Truck TruckFactory(string lineInput)
        {
            string[] carArg = lineInput.Split();
            double fuelQuantit = double.Parse(carArg[1]);
            double fuelConsumption = double.Parse(carArg[2]);
            double tankCapacity = double.Parse(carArg[3]);
            Truck truck = new Truck(fuelQuantit, fuelConsumption, tankCapacity);
            return truck;
        }

        private Car CarFactory(string lineInput)
        {
            string[] carArg = lineInput.Split();
            double fuelQuantit = double.Parse(carArg[1]);
            double fuelConsumption = double.Parse(carArg[2]);
            double tankCapacity = double.Parse(carArg[3]);

            Car car = new Car(fuelQuantit, fuelConsumption, tankCapacity);
            return car;
        }
    }
}
