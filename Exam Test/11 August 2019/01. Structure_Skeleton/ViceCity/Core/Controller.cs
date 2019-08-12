using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Core.Contracts;
using ViceCity.Models.Guns;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Core
{
    public class Controller : IController
    {
        private IPlayer mainPlayer;
        private List<IPlayer> civilPlayers;

        private IRepository<IGun> guns;

        private INeighbourhood hood;

        public Controller()
        {
            this.mainPlayer = new MainPlayer();
            this.civilPlayers = new List<IPlayer>();

            this.guns = new GunRepository();

            this.hood = new GangNeighbourhood();
        }

        public string AddGun(string type, string name)
        {
            IGun gun = null;
            switch (type)
            {
                case "Pistol":
                    gun = new Pistol(name);
                    break;
                case "Rifle":
                    gun = new Rifle(name);
                    break;
            }

            if (gun == null)
            {
                return $"Invalid gun type!";
            }

            this.guns.Add(gun);
            return $"Successfully added {name} of type: {type}";
        }

        public string AddGunToPlayer(string name)
        {
            IGun gun = this.guns.Models.FirstOrDefault();

            if (gun == null)
            {
                return $"There are no guns in the queue!";
            }

            if (name == "Vercetti")
            {
                this.mainPlayer.GunRepository.Add(gun);
                this.guns.Remove(gun);
                return $"Successfully added {gun.Name} to the Main Player: Tommy Vercetti";
            }

            IPlayer player = this.civilPlayers.FirstOrDefault(p => p.Name == name);
            if (player == null)
            {
                return $"Civil player with that name doesn't exists!";
            }

            player.GunRepository.Add(gun);
            this.guns.Remove(gun);
            return $"Successfully added {gun.Name} to the Civil Player: {player.Name}";
        }

        public string AddPlayer(string name)
        {
            IPlayer player = new CivilPlayer(name);
            this.civilPlayers.Add(player);
            return $"Successfully added civil player: {name}!";
        }

        public string Fight()
        {
            int initialMainPlPoints = mainPlayer.LifePoints;
            string firstVictimName = civilPlayers.FirstOrDefault().Name;
            int initialFirstVictimPoints = civilPlayers.FirstOrDefault().LifePoints;

            int civilCount = civilPlayers.Count;

            this.hood.Action(mainPlayer, civilPlayers);

            if (mainPlayer.LifePoints == initialMainPlPoints
                && civilPlayers.Count > 0
                && firstVictimName == civilPlayers.FirstOrDefault().Name
                && civilPlayers.FirstOrDefault().LifePoints == initialFirstVictimPoints)
            {
                return $"Everything is okay!";
            }

            return "A fight happened:"
 + Environment.NewLine + $"Tommy live points: {mainPlayer.LifePoints}!"
 + Environment.NewLine + $"Tommy has killed: {civilCount - this.civilPlayers.Count} players!"
 + Environment.NewLine + $"Left Civil Players: {this.civilPlayers.Count}!";

        }
    }
}
