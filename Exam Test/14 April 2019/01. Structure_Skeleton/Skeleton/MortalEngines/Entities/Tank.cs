using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Tank : BaseMachine, ITank
    {
        private const double Default_HealthPoint = 100;
        private const int InitialAttack = 40;
        private const int InitialDefnse = 30;
        public Tank(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints- InitialAttack, defensePoints+ InitialDefnse, Default_HealthPoint)
        {
            this.DefenseMode = true;
        }

        public bool DefenseMode
        {
            get;private set;
        }

        public void ToggleDefenseMode()
        {
            if (!DefenseMode)
            {
                this.DefenseMode = true;
                this.AttackPoints -= InitialAttack;
                this.DefensePoints += InitialDefnse;
            }
            else
            {
                this.DefenseMode = false;
                this.AttackPoints += InitialAttack;
                this.DefensePoints -= InitialDefnse;
            }

        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            if (DefenseMode)
            {
                sb.AppendLine($" *Defense: ON");
           }
            else
            {
                sb.AppendLine($" *Defense: OFF");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
