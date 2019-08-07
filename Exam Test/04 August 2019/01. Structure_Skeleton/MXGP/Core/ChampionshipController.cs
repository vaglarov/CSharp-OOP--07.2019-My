using MXGP.Core.Contracts;
using MXGP.Models.Motorcycles;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Races;
using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders;
using MXGP.Models.Riders.Contracts;
using MXGP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MXGP.Core
{
    public class ChampionshipController : IChampionshipController
    {
        //?readonly
        private readonly RiderRepository ridersRepository;
        private readonly MotorcycleRepository motoRepository;
        private readonly RaceRepository raceRepository;
        public ChampionshipController()
        {
            this.ridersRepository = new RiderRepository();
            this.motoRepository = new MotorcycleRepository();
            this.raceRepository = new RaceRepository();
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            var ride = this.ridersRepository.GetByName(riderName);
            if (ride == null)
            {
                throw new InvalidOperationException($"Rider { riderName } could not be found.");
            }
            var moto = this.motoRepository.GetByName(motorcycleModel);
            if (moto == null)
            {
                throw new InvalidOperationException($"Motorcycle {motorcycleModel} could not be found.");
            }
            ride.AddMotorcycle(moto);
            return $"Rider {riderName} received motorcycle {motorcycleModel}.";
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            var race = this.raceRepository.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            var rider = this.ridersRepository.GetByName(riderName);
            if (rider == null)
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }
            race.AddRider(rider);
            return $"Rider {riderName} added in {raceName} race.";
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            IMotorcycle moto = null;
            if (type== "Power")
            {
                moto = new PowerMotorcycle(model, horsePower);
            }
            else if (type== "Speed")
            {
               moto = new SpeedMotorcycle(model, horsePower);
            }
            if (this.motoRepository.GetByName(model) != null)
            {
                throw new ArgumentException($"Motorcycle {model} is already created.");
            }
            this.motoRepository.Add(moto);
            return $"{moto.GetType().Name} {model} is created.";

        }

        public string CreateRace(string name, int laps)
        {
            IRace race = new Race(name, laps);
            if (this.raceRepository.GetByName(name) != null)
            {
                throw new InvalidOperationException($"Race {name} is already created.");
            }
            this.raceRepository.Add(race);
            return $"Race {name} is created.";
        }

        public string CreateRider(string riderName)
        {
            IRider rider = new Rider(riderName);
            if (ridersRepository.GetByName(riderName) != null)
            {
                throw new ArgumentException($"Rider {riderName} is already created.");
            }
            this.ridersRepository.Add(rider);
            return $"Rider {riderName} is created.";
        }

        public string StartRace(string raceName)
        {
            var race = raceRepository.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            var firstTree = race.Riders.OrderByDescending(r => r.Motorcycle.CalculateRacePoints(race.Laps)).Take(3).ToList();
            if (firstTree.Count <= 2)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Rider {firstTree[0].Name} wins {raceName} race.");
            sb.AppendLine($"Rider {firstTree[1].Name} is second in {raceName} race.");
            sb.AppendLine($"Rider {firstTree[2].Name} is third in {raceName} race.");

            raceRepository.Remove(race);
            return sb.ToString().TrimEnd();
        }
    }
}
