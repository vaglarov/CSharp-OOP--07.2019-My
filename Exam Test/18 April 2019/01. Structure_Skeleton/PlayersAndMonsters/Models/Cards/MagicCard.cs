using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards
{
    public class MagicCard : Card
    {
        //        MagicCard
        //Has 5 damage points and 80 health points.
        //Constructor should take the following values upon initialization:
        //string name
        private const int DefaultDamagePoints = 5;
        private const int DeFaultHealthPoints = 80;

        public MagicCard(string name)
            : base(name, DefaultDamagePoints, DeFaultHealthPoints)
        {
        }
    }
}
