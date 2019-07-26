using SoftUniRestaurant.Models.Drinks.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Drinks
{
    public class FuzzyDrink : Drink
    {
        private const decimal DEFAULT_PRICE = 2.50m;
        public FuzzyDrink(string name, int servingSize, string brand) 
            : base(name, servingSize, DEFAULT_PRICE, brand)
        {
        }
    }
}
