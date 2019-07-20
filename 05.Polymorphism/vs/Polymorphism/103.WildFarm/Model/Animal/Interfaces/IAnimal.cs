using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Model.Food.Interfaces;

namespace WildFarm.Model.Animal.Interfaces
{
    public interface IAnimal
    {
        string Name { get; }
        double Weight { get; }
        int FoodEaten { get; }

        string ProduceSound();

        void Feed(IFood food);

    }
}
