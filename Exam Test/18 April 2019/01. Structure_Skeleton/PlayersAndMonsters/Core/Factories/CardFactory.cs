using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Cards.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PlayersAndMonsters.Core.Factories
{
    public class CardFactory : ICardFactory
    {
        public ICard CreateCard(string type, string name)
        {
            Type typeClass = Assembly.GetCallingAssembly()
             .GetTypes()
             .FirstOrDefault(c => c.Name == type);

            ICard card = (ICard)Activator.CreateInstance(
                    typeClass, name);
            return card;
        }
    }
}
