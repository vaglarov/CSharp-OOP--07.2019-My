using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards
{
    public class TrapCard : Card
    {        // Has 120 damage points and 5 health points.
        private const int Default_Damage = 120;
        private const int Default_HP = 5;
        public TrapCard(string name)
            : base(name, Default_Damage, Default_HP)
        {
        }
    }
}
