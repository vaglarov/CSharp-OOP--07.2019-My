using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Foods
{
    public class MainCourse : Food
    {
        private const int DEFAULT_InitialServingSize = 500;
        public MainCourse(string name,  decimal price)
            : base(name, DEFAULT_InitialServingSize, price)
        {
        }
    }
}
