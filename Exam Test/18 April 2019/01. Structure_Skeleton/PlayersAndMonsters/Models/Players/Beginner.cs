using System;
using System.Collections.Generic;
using System.Text;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.Players
{
    public class Beginner : Player
    {//Has 50 initial health points.
        private const int Default_Health = 50;
        public Beginner(ICardRepository cardRepository, string username)
            : base(cardRepository, username, Default_Health)
        {
        }
    }
}
