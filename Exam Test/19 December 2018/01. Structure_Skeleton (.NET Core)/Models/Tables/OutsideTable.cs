﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Tables
{
    public class OutsideTable : Table
    {
        private const decimal DEFAULT_PRICE_FOR_PRESON = 3.50m;

        public OutsideTable(int tableNumber, int capacity)
            : base(tableNumber, capacity, DEFAULT_PRICE_FOR_PRESON)
        {
        }
    }
}
