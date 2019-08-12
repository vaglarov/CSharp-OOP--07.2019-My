using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players.Contracts;
using System.Linq;

namespace ViceCity.Models.Neghbourhoods
{
    public class GangNeighbourhood : INeighbourhood
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            Queue<IGun> guns = new Queue<IGun>(mainPlayer.GunRepository.Models);
            Queue<IPlayer> victims = new Queue<IPlayer>(civilPlayers);

            while (victims.Count > 0 && guns.Count > 0)
            {
                IPlayer victim = victims.Peek();
                IGun gun = guns.Peek();

                while (victim.IsAlive && (gun.BulletsPerBarrel > 0 || gun.TotalBullets > 0))
                {
                    victim.TakeLifePoints(gun.Fire());
                }

                if (victim.IsAlive)
                {
                    guns.Dequeue();
                }
                else
                {
                    if (gun.BulletsPerBarrel <= 0 && gun.TotalBullets <= 0)
                    {
                        guns.Dequeue();
                    }

                    victims.Dequeue();
                    civilPlayers.Remove(victim);
                }
            }

            while (victims.Count > 0)
            {
                IPlayer victim = victims.Peek();

                while (victim.GunRepository.Models.Count > 0)
                {
                    IGun gun = victim.GunRepository.Models.First();

                    while ((gun.BulletsPerBarrel > 0 || gun.TotalBullets > 0) && mainPlayer.IsAlive)
                    {
                        mainPlayer.TakeLifePoints(gun.Fire());
                    }

                    if (mainPlayer.IsAlive)
                    {
                        victim.GunRepository.Remove(gun);
                    }
                    else
                    {
                        break;
                    }
                }

                if (!mainPlayer.IsAlive)
                {
                    break;
                }

                victims.Dequeue();
                civilPlayers.Remove(victim);
            }

        }
    }
}
