using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards
{
    public class MagicCard : Card
    {
        private const int DAMAGEPOINTS = 5;
        private const int HEALTHPOINTS = 80;

        public MagicCard(string name)
            : base(name, DAMAGEPOINTS, HEALTHPOINTS)
        {
        }
    }
}
