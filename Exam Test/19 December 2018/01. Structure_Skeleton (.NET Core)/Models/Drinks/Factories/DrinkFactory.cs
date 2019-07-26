using SoftUniRestaurant.Models.Drinks.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SoftUniRestaurant.Models.Drinks.Factories
{
    public class DrinkFactory
    {                               //string type, string name, int servingSize, string brand
        public IDrink CreateDrink(string typeDrink, string name, int servingSize, string brand)
        {
            Type typeClass = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == typeDrink);

            IDrink food = (IDrink)Activator.CreateInstance(
                typeClass, name, servingSize, brand);
            return food;
        }
    }
}
