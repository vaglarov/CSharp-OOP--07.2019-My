using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Model.Contends
{
    public interface IHotel
    {
        IReadOnlyDictionary<string, IAnimal> dataAnimal { get; }
        void Accommodate(IAnimal animal);
        void Adopt(string animalName, string owner);
    }
}
