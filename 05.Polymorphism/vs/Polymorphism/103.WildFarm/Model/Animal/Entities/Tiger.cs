using System;
using System.Collections.Generic;
using System.Text;

using WildFarm.Model.Food.Entities;

namespace WildFarm.Model.Animal.Entities
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        protected override List<Type> listFood
            => new List<Type>
            {
                typeof(Meat)
            };

        protected override double WeightGroingCoeficient => 1.0;

        public override string ProduceSound()
        {
            return $"ROAR!!!";
        }
    }
}
