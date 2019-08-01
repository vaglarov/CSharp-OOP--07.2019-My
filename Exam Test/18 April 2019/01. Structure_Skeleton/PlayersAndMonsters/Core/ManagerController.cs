namespace PlayersAndMonsters.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Core.Factories;
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.BattleFields;
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Models.Cards;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Players;
    using PlayersAndMonsters.Repositories;

    public class ManagerController : IManagerController
    {
        private ICardFactory factoryCard;
        private IPlayerFactory factoryPlayer;

        private BattleField battleField;

        private PlayerRepository players;
        private CardRepository cards;
        

        public ManagerController()
        {
            this.factoryCard = new CardFactory();
            this.factoryPlayer = new PlayerFactory();

            this.battleField = new BattleField();

         
            this.cards = new CardRepository();
            this.players = new PlayerRepository();
        }

        public string AddPlayer(string type, string username) //seem worked
        {
            var player = factoryPlayer.CreatePlayer(type, username);
            players.Add(player);
            return string.Format(ConstantMessages.SuccessfullyAddedPlayer, type, username);
        }
         
        public string AddCard(string type, string name)  //seem worked
        {
            var card = factoryCard.CreateCard(type, name);
            cards.Add(card);
            return string.Format(ConstantMessages.SuccessfullyAddedCard, type, name);
        }

        public string AddPlayerCard(string username, string cardName)
        {
            var playerToAddCard = this.players.Find(username);
            var cardToAddInPlayer = this.cards.Find(cardName);
        

            playerToAddCard.CardRepository.Add(cardToAddInPlayer);
            return string.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, cardName, username);
        }

        public string Fight(string attackUser, string enemyUser)
        {
            var attackPlayer = this.players.Find(attackUser);
            var enemyPlayer = this.players.Find(attackUser);
            this.battleField.Fight(attackPlayer, enemyPlayer);

            return string.Format(ConstantMessages.FightInfo, attackPlayer.Health, enemyPlayer.Health);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var player in players.Players)
            {
                sb.AppendLine(string.Format(ConstantMessages.PlayerReportInfo, player.Username, player.Health, player.CardRepository.Count));
                if (player.CardRepository.Count>0)
                {
                    foreach (var card in player.CardRepository.Cards)
                    {
                        sb.AppendLine(string.Format(ConstantMessages.CardReportInfo, card.Name, card.DamagePoints));
                    }
                }
                sb.AppendLine(ConstantMessages.DefaultReportSeparator);

            }

            return sb.ToString().TrimEnd();
  
        }
    }
}
