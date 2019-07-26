using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards
{
    public class TrapCard : Card
    {
        private const int DAMAGEPOINTS = 120;
        private const int HEALTHPOINTS = 5;
        public TrapCard(string name) 
            : base(name, DAMAGEPOINTS, HEALTHPOINTS)
        {
        }
    }
}
