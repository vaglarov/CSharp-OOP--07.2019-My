using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehiclesExtePolymorph.Models;

namespace VehiclesExtePolymorph.Core
{
    public class Engine
    {
        private List<Vehicle> vehicles = new List<Vehicle>();
        public Engine()
        {

        }
        public void Run()
        {
            VechicleFactory();

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
                        var car = vehicles.FirstOrDefault(x => x.GetType().Name == "Car");
                        Console.WriteLine(car.Drive(distance));
                    }
                    else if (commandType == "Truck")
                    {
                        var truck = vehicles.FirstOrDefault(x => x.GetType().Name == "Truck");

                        Console.WriteLine(truck.Drive(distance));
                    }
                    else
                    {
                        var bus = vehicles.FirstOrDefault(x => x.GetType().Name == "Bus");

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
                            var car = vehicles.FirstOrDefault(x => x.GetType().Name == "Car");
                            car.Refuel(addQuantity);
                        }
                        else if (commandType == "Truck")
                        {
                            var truck = vehicles.FirstOrDefault(x => x.GetType().Name == "Truck");
                            truck.Refuel(addQuantity);
                        }
                        else
                        {
                            var bus = vehicles.FirstOrDefault(x => x.GetType().Name == "Bus");
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
                    var bus = (Bus)vehicles.FirstOrDefault(x => x.GetType().Name == "Bus");
                    Console.WriteLine(bus.DriveEmpty(distance));
                }
            }
            PrintResult(vehicles);

        }

        private void VechicleFactory()
        {
            for (int i = 0; i < 3; i++)
            {
                Vehicle vehicle = null;
                if (i == 0)
                {
                    vehicle = CarFactory(Console.ReadLine());
                }
                else if (i == 1)
                {
                    vehicle = TruckFactory(Console.ReadLine());
                }
                else
                {
                    vehicle = BusFactory(Console.ReadLine());
                }
                vehicles.Add(vehicle);
            }
        }

        private void PrintResult(List<Vehicle> vehicles)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        private Bus BusFactory(string lineInput)
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
        private void PrintResult(Car car, Truck truck, Bus bus)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
