using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Model.Food.Entities;

namespace WildFarm.Model.Animal.Entities
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        protected override List<Type> listFood 
            => new List<Type> { typeof(Meat)};

        protected override double WeightGroingCoeficient => 0.4;

        public override string ProduceSound()
        {
            return $"Woof!";
        }
        public override string ToString()
        {
            return base.ToString() + $"{ this.Weight}, { this.LivingRegion}, { this.FoodEaten}]";
        }
    }
}
