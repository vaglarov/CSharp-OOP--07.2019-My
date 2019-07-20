using System;
using System.Collections.Generic;
using System.Text;

using WildFarm.Model.Animal.Entities;
using WildFarm.Model.Animal.Interfaces;
using WildFarm.Model.Food.Entities;
using WildFarm.Model.Food.Interfaces;

namespace WildFarm.Core
{
    public class Engine
    {
        List<Animal> animalData;
        public Engine()
        {
            this.animalData = new List<Animal>();
        }
        public void Run()
        {
            string fisltCommand = Console.ReadLine();
            while (fisltCommand != "End")
            {
                Animal animal = AnimalFactory(fisltCommand);
                Console.WriteLine(animal.ProduceSound());
                string secondLine = Console.ReadLine();
                IFood food = FoodFactory(secondLine);
                try
                {
                    animal.Feed(food);
                 }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                fisltCommand = Console.ReadLine();
            }
            PrintResult();
        }

        private void PrintResult()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var animal in animalData)
            {
                Console.WriteLine(animal);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        private IFood FoodFactory(string line)
        {
            string[] arg = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string type = arg[0];
            int quantit = int.Parse(arg[1]);
            IFood food = null;
            switch (type)
            {
                case "Vegetable":
                    food = new Vegetable(quantit);
                    break;
                case "Fruit":
                    food = new Fruit(quantit);
                    break;
                case "Meat":
                    food = new Meat(quantit);
                    break;
                case "Seeds":
                    food = new Seeds(quantit);
                    break;
            }
            return food;
        }

        private Animal AnimalFactory(string line)
        {
            string[] arg = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string type = arg[0];
            string name = arg[1];
            double weight = double.Parse(arg[2]);
            Animal animal = null;
            if (type == "Owl")
            {
                double wingSize = double.Parse(arg[3]);
                animal = new Owl(name, weight, wingSize);
            }
            else if (type == "Hen")
            {
                double wingSize = double.Parse(arg[3]);
                animal = new Hen(name, weight, wingSize);
            }
            else if (type == "Mouse")
            {
                string livingRegiom = arg[3];
                animal = new Mouse(name, weight, livingRegiom);
            }
            else if (type == "Dog")
            {
                string livingRegiom = arg[3];
                animal = new Dog(name, weight, livingRegiom);
            }
            else if (type == "Cat")
            {
                string livingRegiom = arg[3];
                string breed = arg[4];
                animal = new Cat(name, weight, livingRegiom, breed);
            }
            else if (type == "Tiger")
            {
                string livingRegiom = arg[3];
                string breed = arg[4];
                animal = new Tiger(name, weight, livingRegiom, breed);
            }
            this.animalData.Add(animal);
            return animal;
        }
    }
}
