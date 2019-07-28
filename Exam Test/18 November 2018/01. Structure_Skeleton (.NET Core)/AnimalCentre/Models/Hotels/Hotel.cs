using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AnimalCentre.Models.Hotels
{
    public class Hotel : IHotel
    {
        private const string Message_Not_Enough_Capacity = "Not enough capacity";
        private const string Message_Animal_Exist_In_Data = "Animal {0} already exist";
        private const string Message_Animal_Doesnot_Exist_In_Data = "Animal {0} does not exist";

        private const int Capacity_Hotel = 10;

        private IDictionary<string, IAnimal> animalDATA;
        private int capacity;
        public Hotel()
        {
            this.animalDATA = new Dictionary<string, IAnimal>(Capacity_Hotel);
            this.capacity = Capacity_Hotel;
        }
        public void Accommodate(IAnimal animal)
        {
            if (animalDATA.Count==Capacity_Hotel)
            {
                throw new InvalidOperationException(Message_Not_Enough_Capacity);
            }
            if (animalDATA.ContainsKey(animal.Name))
            {
                throw new ArgumentException(string.Format(Message_Animal_Exist_In_Data, animal.Name));
            }
            this.animalDATA.Add(animal.Name, animal);
        }



        public void Adopt(string animalName, string owner)
        {
            if (!animalDATA.ContainsKey(animalName))
            {
                throw new ArgumentException(string.Format(Message_Animal_Doesnot_Exist_In_Data, animalName));
            }
            var currentAnimal = animalDATA[animalName];
            currentAnimal.IsAdopt = true;
            currentAnimal.Owner = owner;
            animalDATA.Remove(animalName);
        }

        public IReadOnlyDictionary<string, IAnimal> Animals
        {
            get => new ReadOnlyDictionary<string, IAnimal>(this.animalDATA);

        }


    }
}
