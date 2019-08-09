namespace PlayersAndMonsters.Core
{
    using System;
    using System.Text;
    using Contracts;
    using PlayersAndMonsters.Models.BattleFields;
    using PlayersAndMonsters.Models.Cards;
    using PlayersAndMonsters.Models.Players;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories;
    using PlayersAndMonsters.Repositories.Contracts;

    public class ManagerController : IManagerController
    {
        private PlayerRepository playerRepo;
        private CardRepository cardRepo;

        public ManagerController()
        {
            this.playerRepo = new PlayerRepository();
            this.cardRepo = new CardRepository();
        }

        public string AddPlayer(string type, string username)
        {
            string result = string.Empty;
            if (type == "Beginner")
            {
                ICardRepository palyersRepo = new CardRepository();
                IPlayer newPlayer = new Beginner(palyersRepo, username);
                this.playerRepo.Add(newPlayer);
            }
            else
            {
                ICardRepository palyersRepo = new CardRepository();
                IPlayer newPlayer = new Advanced(palyersRepo, username);
                this.playerRepo.Add(newPlayer);
            }
            //            Functionality
            //Creates a player with the provided type and name. The method should return the following message:
            //"Successfully added player of type {type} with username: {username}"
            result = $"Successfully added player of type {type} with username: {username}";
            return result;
        }

        public string AddCard(string type, string name)
        {
            string result = $"Successfully added card of type {type}Card with name: {name}";
            // Creates a card$ with the provided type and name.The method should return the following message:
            if (type== "Magic")
            {
                var newCard = new MagicCard(name);
                this.cardRepo.Add(newCard);
            }
            else
            {
                var newCard = new TrapCard(name);
                this.cardRepo.Add(newCard);
            }
            return result;
        }

        public string AddPlayerCard(string username, string cardName)
        {
            string result = $"Successfully added card: {cardName} to user: {username}";
            var card = this.cardRepo.Find(cardName);
            var player = this.playerRepo.Find(username);
            player.CardRepository.Add(card);
            return result;
        }

        public string Fight(string attackUser, string enemyUser)
        {
            var attackPlayer = this.playerRepo.Find(attackUser);
            var enemyPlayer = this.playerRepo.Find(enemyUser);
            var battleField = new BattleField();
            battleField.Fight(attackPlayer, enemyPlayer);
            string result=$"Attack user health {attackPlayer.Health} - Enemy user health {enemyPlayer.Health}";
            return result;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var player in this.playerRepo.Players)
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
