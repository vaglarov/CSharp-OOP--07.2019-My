using AnimalCentre.Factories;
using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Hotels;
using AnimalCentre.Models.Procedure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Core
{

    public class AnimalCentre
    {
        private const string Message_Animal_Donot_Exist = "Animal {0} does not exist";

        private IFactoryAnimal factoryAnimal;
        private readonly IHotel hotel;
        private Dictionary<string, IProcedure> procedureAnimals;
        private Dictionary<string, List<string>> adoptedAnimals;

        public AnimalCentre()
        {
            this.adoptedAnimals = new Dictionary<string, List<string>>();
            this.factoryAnimal = new FactoryAnimal();
            this.hotel = new Hotel();
            this.procedureAnimals = new Dictionary<string, IProcedure>()
            {
                {"Chip",new Chip() },
                {"DentalCare",new DentalCare() },
                {"Fitness",new Fitness() },
                {"NailTrim",new NailTrim() },
                {"Play",new Play() },
                {"Vaccinate",new Vaccinate() },
            };
        }
        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            var animal = factoryAnimal.CreateAnimal(type, name, energy, happiness, procedureTime);
            this.hotel.Accommodate(animal);
            return $"Animal {animal.Name} registered successfully";
        }

        public string Chip(string name, int procedureTime)
        {
            var animal = hotel.Animals[name];
            if (animal == null)
            {
                throw new ArgumentException(string.Format(Message_Animal_Donot_Exist, name));
            }
            this.procedureAnimals["Chip"].DoService(animal, procedureTime);

            return $"{animal.Name} had chip procedure";
        }


        public string Vaccinate(string name, int procedureTime)
        {
            var animal = hotel.Animals[name];

            if (animal == null)
            {
                throw new ArgumentException(string.Format(Message_Animal_Donot_Exist, name));
            }
            this.procedureAnimals["Vaccinate"].DoService(animal, procedureTime);
            return $"{name} had vaccination procedure";
        }

        public string Fitness(string name, int procedureTime)
        {
            var animal = hotel.Animals[name];
            if (animal == null)
            {
                throw new ArgumentException(string.Format(Message_Animal_Donot_Exist, name));
            }
            this.procedureAnimals["Fitness"].DoService(animal, procedureTime);
            return $"{name} had fitness procedure";
        }

        public string Play(string name, int procedureTime)
        {
            var animal = hotel.Animals[name];
            if (animal == null)
            {
                throw new ArgumentException(string.Format(Message_Animal_Donot_Exist, name));
            }
            this.procedureAnimals["Play"].DoService(animal, procedureTime);
            return $"{name} was playing for {procedureTime} hours";
        }

        public string DentalCare(string name, int procedureTime)
        {
            var animal = hotel.Animals[name];
            if (animal == null)
            {
                throw new ArgumentException(string.Format(Message_Animal_Donot_Exist, name));
            }
            this.procedureAnimals["DentalCare"].DoService(animal, procedureTime);
            return $"{name} had dental care procedure";
        }

        public string NailTrim(string name, int procedureTime)
        {
            var animal = hotel.Animals[name];
            if (animal == null)
            {
                throw new ArgumentException(string.Format(Message_Animal_Donot_Exist, name));
            }
            this.procedureAnimals["NailTrim"].DoService(animal, procedureTime);
            return $"{name} had nail trim procedure";
        }

        public string Adopt(string animalName, string owner)
        {
            var animal = hotel.Animals[animalName];
            if (animal == null)
            {
                throw new ArgumentException(string.Format(Message_Animal_Donot_Exist, animalName));
            }
            hotel.Adopt(animalName, owner);
            AddInAdoptedData(animal);


            if (animal.IsChipped)
            {
                return $"{owner} adopted animal with chip";

            }
            return $"{owner} adopted animal without chip";
        }

        public string AllAdoptedAnnimal()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var owner in this.adoptedAnimals.OrderBy(x => x.Key))
            {
                sb.AppendLine($"--Owner: {owner.Key}");
                sb.AppendLine($"    - Adopted animals: {string.Join(" ", owner.Value)}");
            }
            return sb.ToString().TrimEnd();
        }
        private void AddInAdoptedData(IAnimal animal)
        {
            if (!adoptedAnimals.ContainsKey(animal.Owner))
            {
                this.adoptedAnimals.Add(animal.Owner, new List<string>());
            }
            else
            {
                this.adoptedAnimals[animal.Owner].Add(animal.Name);
            }
        }

        public string History(string type)
        {
            return this.procedureAnimals[type].History();
        }

    }
}
