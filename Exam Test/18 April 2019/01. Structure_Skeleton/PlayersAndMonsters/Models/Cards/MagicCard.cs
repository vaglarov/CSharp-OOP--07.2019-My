﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards
{
    public class MagicCard : Card
    {
        // 5 damage points and 80 health points.
        private const int Default_Damage = 5;
        private const int Default_HP = 80;
        public MagicCard(string name)
            : base(name, Default_Damage, Default_HP)
        {
        }
    }
}
