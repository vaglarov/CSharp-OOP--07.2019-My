using System;
using System.Collections.Generic;
using System.Text;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.Players
{
    public class Advanced : Player
    {
        //        Has 250 initial health points.
        //Constructor should take the following values upon initialization:
        //ICardRepository cardRepository, string username
        private const int DefaultHealth = 250;
        public Advanced(ICardRepository cardRepository, string username)
            : base(cardRepository, username, DefaultHealth)
        {
        }
    }
}
