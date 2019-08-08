namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Entities;
    using MortalEngines.Entities.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class MachinesManager : IMachinesManager
    {
        //readonly
        private readonly List<IPilot> litstpilots;
        private readonly List<IMachine> machineList;
        public MachinesManager()
        {
            this.litstpilots = new List<IPilot>();
            this.machineList = new List<IMachine>();

        }
        public string HirePilot(string name)
        {
            string result;
            var pilot = this.litstpilots.FirstOrDefault(p => p.Name == name);
            if (pilot != null)
            {            //Pilot {0   } is hired already
                result = $"Pilot {name} is hired already";
            }
            else
            {
                IPilot newPilot = new Pilot(name);
                this.litstpilots.Add(newPilot);
                //         Pilot {   0} hired
                result = $"Pilot {name} hired";
            }
            return result;
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            string result;

            var tank = this.machineList.FirstOrDefault(p => p.Name == name);

            if (tank != null)
            {            //Machine {    } is manufactured already
                result = $"Machine {name} is manufactured already";
            }
            else
            {
                IMachine newTank = new Tank(name, attackPoints, defensePoints);
                this.machineList.Add(newTank);
                //         Tank {   0} manufactured - attack: {1:F2                   }; defense: {2:F2}
                result = $"Tank {name} manufactured - attack: {newTank.AttackPoints:f2}; defense: {newTank.DefensePoints:f2}";
            }
            return result;
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            string result;

            var fighter = this.machineList.FirstOrDefault(p => p.Name == name);
            if (fighter != null)
            {            //Machine {0   } is manufactured already
                result = $"Machine {name} is manufactured already";
            }
            else
            {
                IMachine newFighter = new Fighter(name, attackPoints, defensePoints);
                this.machineList.Add(newFighter);
                //         Fighter {0   } manufactured - attack: {1:F2                      }; defense: {2:F2                       }; aggressive: {3}
                result = $"Fighter {name} manufactured - attack: {newFighter.AttackPoints:f2}; defense: {newFighter.DefensePoints:f2}; aggressive: ON";
            }
            return result;
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            string result;

            var pilot = this.litstpilots.FirstOrDefault(p => p.Name == selectedPilotName);
            if (pilot == null)
            {                 //  Pilot {0                } could not be found
                return result = $"Pilot {selectedPilotName} could not be found";
            }

            var machine = this.machineList.FirstOrDefault(p => p.Name == selectedMachineName);
            if (machine == null)
            {             //      Machine {                  0} could not be found
                return result = $"Machine {selectedMachineName} could not be found";
            }

            if (machine.Pilot != null)
            {                  // Machine {0                  } is already occupied
                return result = $"Machine {selectedMachineName} is already occupied";
            }
            else
            {
                machine.Pilot = pilot;
                pilot.AddMachine(machine);
                               //Pilot {                0} engaged machine {1}
               return result = $"Pilot {selectedPilotName} engaged machine {selectedMachineName}";
            }

        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            string result;
            var attack = this.machineList.FirstOrDefault(p => p.Name == attackingMachineName);
            var defence = this.machineList.FirstOrDefault(p => p.Name == defendingMachineName);
            if (attack == null)
            {      //      Machine {                   0} could not be found
                result = $"Machine {attackingMachineName} could not be found";
                return result;
            }
            else if (defence == null)
            {
                result = $"Machine {defendingMachineName} could not be found";
                return result;

            }
            if (attack.HealthPoints <= 0)
            {          //" Dead machine {0                   } cannot attack or be attacked
                result = $"Dead machine {attackingMachineName} cannot attack or be attacked";
                return result;
            }
            if (defence.HealthPoints <= 0)
            {
                result = $"Dead machine {defendingMachineName} cannot attack or be attacked";
                return result;
            }
            attack.Attack(defence);
                    //"Machine {0                   } was attacked by machine {1                   } - current health: {2:F2}"
            result = $"Machine {defendingMachineName} was attacked by machine {attackingMachineName} - current health: {defence.HealthPoints:f2}";
            return result;
        }

        public string PilotReport(string pilotReporting)
        {
            //if exist
            string result;
            var pilot = this.litstpilots.FirstOrDefault(p => p.Name == pilotReporting);
            result = pilot.Report();
            return result;
        }

        public string MachineReport(string machineName)
        {
            //if exist
            string result;
            var machine = this.machineList.FirstOrDefault(p => p.Name == machineName);
            result = machine.ToString();
            return result;
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            string result;
            var machine = this.machineList.FirstOrDefault(p => p.Name == fighterName&&p.GetType().Name=="Fighter");
            if (machine == null)
            {
                result = $"Machine {fighterName} could not be found";
                return result;
            }

            var fighter = (Fighter)machine;
            fighter.ToggleAggressiveMode();
            result = $"Fighter {fighterName} toggled aggressive mode";

            return result;
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            string result;
            var machine = this.machineList.FirstOrDefault(p => p.Name == tankName && p.GetType().Name == "Tank");
            if (machine == null)
            {
                result = $"Machine {tankName} could not be found";
                return result;
            }
            var tank = (Tank)machine;
            tank.ToggleDefenseMode();
                     //Tank {0        } toggled defense mode
            result = $"Tank {tank.Name} toggled defense mode";
            return result;
        }
    }
}