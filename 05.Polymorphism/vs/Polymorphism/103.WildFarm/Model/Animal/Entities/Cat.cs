using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Model.Food.Entities;

namespace WildFarm.Model.Animal.Entities
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        protected override List<Type> listFood 
            => new List<Type>
            {
                typeof(Meat),
                typeof(Vegetable)
            };

        protected override double WeightGroingCoeficient => 0.3;

        public override string ProduceSound()
        {
            return $"Meow";
        }
    }
}
