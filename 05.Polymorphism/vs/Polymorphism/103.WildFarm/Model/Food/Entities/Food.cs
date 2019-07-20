﻿using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Model.Food.Interfaces;

namespace WildFarm.Model.Food.Entities
{
    public abstract class Food : IFood
    {
        public Food(int quantity)
        {
            this.Quantity = quantity;
        }
        public int Quantity
        {
            get;
            private set;
        }
    }
}
