using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Tables
{
    public class InsideTable : Table
    {
        private const decimal DEFAULT_PRICE_FOR_PRESON=2.50m;
        public InsideTable(int tableNumber, int capacity) 
            : base(tableNumber, capacity, DEFAULT_PRICE_FOR_PRESON)
        {
        }
    }
}
