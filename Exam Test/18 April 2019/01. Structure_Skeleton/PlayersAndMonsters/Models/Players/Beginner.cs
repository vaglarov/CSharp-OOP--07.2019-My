using System;
using System.Collections.Generic;
using System.Text;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.Players
{
    public class Beginner : Player
    {
        //        Has 50 initial health points.
        //Constructor should take the following values upon initialization:
        //ICardRepository cardRepository, string username

        private const int DefaultHealth = 50;
        public Beginner(ICardRepository cardRepository, string username) 
            : base(cardRepository, username, DefaultHealth)
        {
        }
    }
}
