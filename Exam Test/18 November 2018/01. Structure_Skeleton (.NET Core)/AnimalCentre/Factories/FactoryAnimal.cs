using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AnimalCentre.Factories
{
    public class FactoryAnimal:IFactoryAnimal
    {
      public IAnimal CreateAnimal(string typeAnimal, string name, int energy, int happiness, int procedureTime)
        {
            Type typeClass = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == typeAnimal);

            IAnimal animal = (IAnimal)Activator.CreateInstance(
                typeClass, name, energy, happiness, procedureTime);
            return animal;
        }
    }
}
