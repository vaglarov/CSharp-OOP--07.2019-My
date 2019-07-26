using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Model.Contends
{
    interface IProcedure
    {
        string History();
        void DoService(IAnimal animal, int procedureTime);

    }
}
