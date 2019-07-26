using SoftUniRestaurant.Models.Foods.Contracts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SoftUniRestaurant.Models.Foods.Factories
{
    public class FoodFactory
    {
        public IFood CreateFood(string typeFood, string name, decimal price)
        {
            Type typeClass = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == typeFood);

            IFood food = (IFood)Activator.CreateInstance(
                typeClass, name,price);
            return food;
        }
    }
}
 