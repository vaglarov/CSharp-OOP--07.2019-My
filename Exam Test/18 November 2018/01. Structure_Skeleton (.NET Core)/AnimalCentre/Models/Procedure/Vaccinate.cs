using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedure
{
    public class Vaccinate : Procedure
    {
        private const int Correction_Energy = -8;
        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.CheckTime(procedureTime, animal);
            animal.IsVaccinated = true;
            animal.Energy += Correction_Energy;
            base.procedureHistory.Add(animal);
        }
    }
}
