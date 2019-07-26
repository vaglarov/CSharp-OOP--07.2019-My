﻿using AnimalCentre.Model.Contends;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace AnimalCentre.Model.Hotels
{
   public class Hotel:IHotel
    {
        private const int DEFAULT_CAPACITY = 10;
        private readonly Dictionary<string, IAnimal> animals;
        public Hotel()
        {
            animals = new Dictionary<string, IAnimal>();
        }

        public IReadOnlyDictionary<string, IAnimal> dataAnimal
            => this.animals.ToImmutableDictionary();

        public void Accommodate(IAnimal animal)
        {
            if (animals.Count== DEFAULT_CAPACITY)
            {
                throw new InvalidOperationException("Not enough capacity");
            }
            if (animals.ContainsKey(animal.Name))
            {
                throw new ArgumentException($"Animal {animal.Name} already exist");
            }
            animals.Add(animal.Name, animal);
        }

        public void Adopt(string animalName, string owner)
        {
            if (!animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }
            animals[animalName].Owner = owner;
            animals[animalName].IsAdopt = true;
            animals.Remove(animalName);
        }
    }
}
