using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Foods
{
    public class Salad : Food
    {
        private const int DEFAULT_InitialServingSize = 300;
        public Salad(string name, decimal price) 
            : base(name, DEFAULT_InitialServingSize, price)
        {
        }
    }
}
