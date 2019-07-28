using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Factories
{
    public interface IFactoryAnimal
    {
        IAnimal CreateAnimal(string typeAnimal, string name, int energy, int happiness, int procedureTime);
      
    }
}
