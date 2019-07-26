using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Model.Contends;

namespace AnimalCentre.Model.Procedures
{
    public class Vaccinate : Procedure
    {
        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);
            animal.Energy -= 8;
            animal.IsVaccinated = true;
        }
    }
}
