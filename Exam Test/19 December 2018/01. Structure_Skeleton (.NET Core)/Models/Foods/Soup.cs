using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Foods
{
    public class Soup : Food
    {
        private const int DEFAULT_InitialServingSize = 245;
        public Soup(string name,  decimal price)
            : base(name, DEFAULT_InitialServingSize, price)
        {
        }
    }
}
