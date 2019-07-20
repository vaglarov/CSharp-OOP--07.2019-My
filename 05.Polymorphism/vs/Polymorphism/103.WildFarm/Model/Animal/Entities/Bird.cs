﻿using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Model.Animal.Interfaces;

namespace WildFarm.Model.Animal.Entities
{
    public abstract class Bird : Animal, IBird
    {
        protected Bird(string name, double weight,double wingSize)
            : base(name, weight)
        {
            this.WingSize = wingSize;
        }

        public double WingSize
        {
            get;
            private set;
        }
        public override string ToString()
        {
            return base.ToString() + $"{this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }

    }
}
