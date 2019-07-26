using SoftUniRestaurant.Models.Drinks.Contracts;
using System; 
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Drinks
{
    public class Alcohol:Drink
    {
        private const decimal DEFAULT_PRICE = 3.50m;
        public Alcohol(string name, int servingSize, string brand)
            : base(name, servingSize, DEFAULT_PRICE, brand)
        {
        }
    }
}
