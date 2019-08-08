using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Pilot : IPilot
    {

        private string name;
        //ReadOnly
        private readonly List<IMachine> listMachines;
        public Pilot(string name)
        {
            this.Name = name;

            this.listMachines = new List<IMachine>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {                              //Pilot name cannot be null or empty string.
                    throw new ArgumentNullException("Pilot name cannot be null or empty string.");
                }
                this.name = value;
            }
        }

        public void AddMachine(IMachine machine)
        {
            if (machine == null)
            {
                                                //Null machine cannot be added to the pilot.
                throw new NullReferenceException("Null machine cannot be added to the pilot.");
            }
            this.listMachines.Add(machine);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name} - {this.listMachines.Count} machines");
            foreach (var machine in this.listMachines)
            {
                sb.AppendLine(machine.ToString());
            }

            return sb.ToString().TrimEnd();

        }
    }
}
