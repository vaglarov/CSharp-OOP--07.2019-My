using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards
{
    public class TrapCard : Card
    {
        //        Has 120 damage points and 5 health points.
        //Constructor should take the following values upon initialization:
        //string name
        private const int DefaultDamagePoints = 120;
        private const int DeFaultHealthPoints = 5;
        public TrapCard(string name) 
            : base(name, DefaultDamagePoints, DeFaultHealthPoints)
        {
        }
    }
}
