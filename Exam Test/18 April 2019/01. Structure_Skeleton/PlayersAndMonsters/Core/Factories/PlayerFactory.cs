using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PlayersAndMonsters.Core.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {
            Type typeClass = Assembly.GetCallingAssembly()
             .GetTypes()
             .FirstOrDefault(p => p.Name == type);

            if (typeClass == null)
            {
                throw new ArgumentException("Player of this type does not exists!");
            }

            var repository = new CardRepository();

            IPlayer player = (IPlayer)Activator.CreateInstance(
                    typeClass, repository, username );
            return player;
        }
    }
}
