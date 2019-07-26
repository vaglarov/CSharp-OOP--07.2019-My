using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Model.Contends;

namespace AnimalCentre.Model.Procedures
{
    public class Play : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);
            animal.Energy -= 6;
            animal.Happiness += 12;
        }
    }
}
