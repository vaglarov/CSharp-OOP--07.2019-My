using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Model.Animal.Entities
{
    public abstract class Mammal : Animal
    {
        protected Mammal(string name, double weight, string livingRegion)
            : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }
        public string LivingRegion
        {
            get;
            private set;
        }

    }
}
