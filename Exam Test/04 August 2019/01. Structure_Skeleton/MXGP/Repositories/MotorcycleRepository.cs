using MXGP.Models.Motorcycles;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Repositories
{
    public class MotorcycleRepository : IRepository<IMotorcycle>
    {
        // ?readonly
        private readonly List<IMotorcycle> motoList;
        public MotorcycleRepository()
        {
            this.motoList = new List<IMotorcycle>();
        }
        public void Add(IMotorcycle model)
        {
            this.motoList.Add(model);
        }

        public IReadOnlyCollection<IMotorcycle> GetAll()
        {
            return this.motoList.AsReadOnly();
        }

        public IMotorcycle GetByName(string model)
        {
            var motoByName = motoList.FirstOrDefault(moto => moto.Model == model);
            return motoByName;
        }

        public bool Remove(IMotorcycle moto)
        {
            return this.motoList.Remove(moto);
        }
    }
}
