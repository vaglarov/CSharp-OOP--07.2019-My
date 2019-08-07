using MXGP.Models.Riders;
using MXGP.Models.Riders.Contracts;
using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Repositories
{
   public class RiderRepository: IRepository<IRider>
    {
         
        // ?readonly
        private List<IRider> ridersList;
        public RiderRepository()
        {
            this.ridersList = new List<IRider>();
        }
        public void Add(IRider model)
        {
            this.ridersList.Add(model);
        }

        public IReadOnlyCollection<IRider> GetAll()
        {
            return this.ridersList.AsReadOnly();
        }

        public IRider GetByName(string name)
        {
            var motoByName = ridersList.FirstOrDefault(rider => rider.Name==name);
            return motoByName;
        }

        public bool Remove(IRider moto)
        {
            return this.ridersList.Remove(moto);
        }
    }
}
