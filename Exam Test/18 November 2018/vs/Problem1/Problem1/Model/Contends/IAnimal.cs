﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Model.Contends
{
    public interface IAnimal
    {
        string Name { get; }
        int Happiness { get; set; }
        int Energy { get; set; }
        int ProcedureTime { get; set; }
        string Owner { get; set; }
        bool IsAdopt { get; set; }
        bool IsChipped { get; set; }
        bool IsVaccinated { get; set; }
    }
}
