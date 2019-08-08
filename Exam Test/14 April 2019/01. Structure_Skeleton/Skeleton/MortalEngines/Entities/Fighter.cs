using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Fighter : BaseMachine, IFighter
    {
        private const double Default_HealthPoint = 200;
        private const int InitialAttack = 50;
        private const int InitialDefnse = 25;


        public Fighter(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints+ InitialAttack, defensePoints- InitialDefnse, Default_HealthPoint)
        {
            this.AggressiveMode = true;
       
        }

        public bool AggressiveMode
        {
            get; private set;
        }

        public void ToggleAggressiveMode()
        {
            if (AggressiveMode==false)
            {
                this.AggressiveMode = true;
                this.AttackPoints += InitialAttack;
                this.DefensePoints -= InitialDefnse;
            }
            else
            {
                this.AggressiveMode = false;
                this.AttackPoints -= InitialAttack;
                this.DefensePoints += InitialDefnse;
            }
           
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            if (AggressiveMode)
            {
                sb.AppendLine($" *Aggressive: ON");
            }
            else
            {
                sb.AppendLine($" *Aggressive: OFF");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
