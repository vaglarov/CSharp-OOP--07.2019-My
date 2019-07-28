using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedure
{
    public class NailTrim : Procedure
    {
        private const int Correction_Happiness = -7;
        
        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.CheckTime(procedureTime, animal);
            animal.Happiness += Correction_Happiness;
            base.procedureHistory.Add(animal);
        }
    }
}
