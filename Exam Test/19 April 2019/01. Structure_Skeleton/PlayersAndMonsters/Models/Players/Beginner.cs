﻿using System;
using System.Collections.Generic;
using System.Text;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.Players
{
    public class Beginner : Player
    {
        private const int DEFAULT_HEALT = 50;
        public Beginner(ICardRepository cardRepository, string username )
            : base(cardRepository, username, DEFAULT_HEALT)
        {
        }
    }
}
