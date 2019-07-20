using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Model.Food.Entities;

namespace WildFarm.Model.Animal.Entities
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {

        }

        protected override List<Type> listFood
          => new List<Type> { typeof(Meat) };
        
        
        protected override double WeightGroingCoeficient => 0.25;


        public override string ProduceSound()
        {
            return $"Hoot Hoot";
        }
    }
}
