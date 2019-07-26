using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Model.Contends;

namespace AnimalCentre.Model.Procedures
{
    public class Fitness : Procedure
    {
    public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);
            animal.Happiness -= 3;
            animal.ProcedureTime += procedureTime;
        }
    }
}
