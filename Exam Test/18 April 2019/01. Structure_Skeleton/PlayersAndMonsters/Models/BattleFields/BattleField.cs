using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        private const int Default_Health_Increase = 40;
        private const int Default_DamageCard_Increase = 30;
    
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }
            ChechkedForBeginers(attackPlayer);
            ChechkedForBeginers(enemyPlayer);
            TakeBonusHealth(attackPlayer);
            TakeBonusHealth(enemyPlayer);
            while (true)
            {
                var attackPlayerTotalDamagePoints = attackPlayer.CardRepository.Cards.Sum(d => d.DamagePoints);
                enemyPlayer.TakeDamage(attackPlayerTotalDamagePoints);

                if (enemyPlayer.Health == 0)
                {
                    break;
                }

                var enemyPlayerTotalDamagePoints = enemyPlayer.CardRepository.Cards.Sum(d => d.DamagePoints);
                attackPlayer.TakeDamage(enemyPlayerTotalDamagePoints);

                if (attackPlayer.Health == 0)
                {
                    break;
                }
            }
        }

        private void TakeBonusHealth(IPlayer player)
        {
            var bonusHealth = player.CardRepository.Cards.Sum(c => c.HealthPoints);
            player.Health += bonusHealth;
        }

        private void ChechkedForBeginers(IPlayer player)
        {
            if (player.GetType()== typeof(Beginner))
            {
                player.Health += Default_Health_Increase;
                foreach (var card in player.CardRepository.Cards)
                {
                    card.DamagePoints += Default_DamageCard_Increase;
                }
            }
        }
    }
}
