using SoftUniRestaurant.Models.Drinks.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Drinks
{
    public class Juice:Drink 
    {
        private const decimal DEFAULT_PRICE = 1.80m;
        public Juice(string name, int servingSize, string brand)
            : base(name, servingSize, DEFAULT_PRICE, brand)
        {
        }
    }
}
