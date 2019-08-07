using MXGP.Models.Races.Contracts;
using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Repositories
{
    public class RaceRepository: IRepository<IRace>
    {
        // ?readonly
        private readonly List<IRace> ridersList;
        public RaceRepository()
        {
            this.ridersList = new List<IRace>();
        }
        public void Add(IRace model)
        {
            this.ridersList.Add(model);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return this.ridersList.AsReadOnly();
        }

        public IRace GetByName(string name)
        {
            var motoByName = ridersList.FirstOrDefault(rider => rider.Name == name);
            return motoByName;
        }

        public bool Remove(IRace moto)
        {
            return this.ridersList.Remove(moto);
        }
    }
}
