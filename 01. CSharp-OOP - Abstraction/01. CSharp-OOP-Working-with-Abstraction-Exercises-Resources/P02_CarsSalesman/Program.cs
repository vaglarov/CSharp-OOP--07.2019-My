using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P02_CarsSalesman
{

    class CarSalesman
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Engine> engines = new List<Engine>();
            int engineCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < engineCount; i++)
            {
                Engine newEngine = EngineFactory(Console.ReadLine());
                engines.Add(newEngine);
            }

            int carCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < carCount; i++)
            {
                Car newCar = CarFactory(engines);
                cars.Add(newCar);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }

        private static Car CarFactory(List<Engine> engines)
        {
            string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string model = parameters[0];
            string engineModel = parameters[1];
            Engine engine = engines.FirstOrDefault(x => x.Model == engineModel);
            string color= string.Empty;
            int weight = (int)default;

            if (parameters.Length >= 3)
            {
                bool isDigit = int.TryParse(parameters[2], out weight);
                if (!isDigit)
                {
                    color = parameters[2];
                }

            }
            else if (parameters.Length == 4)
            {
                color = parameters[3];
            }

            Car newCar = new Car(model, engine,weight,color);
            return newCar;
        }

        private static Engine EngineFactory(string input)
        {

            string[] parameters = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string model = parameters[0];
            int power = int.Parse(parameters[1]);

            int displacement = (int)default;
            string efficiency = string.Empty; ;

            if (parameters.Length == 3)
            {
                bool isDigit = int.TryParse(parameters[2], out displacement);
                if (!isDigit)
                {
                    efficiency = parameters[2];
                }
            }
            else if (parameters.Length == 4)
            {
                displacement = int.Parse(parameters[2]);
                efficiency = parameters[3];
            }
            Engine newEngine = new Engine(model, power, displacement, efficiency);
            return newEngine;

        }
    }

}
