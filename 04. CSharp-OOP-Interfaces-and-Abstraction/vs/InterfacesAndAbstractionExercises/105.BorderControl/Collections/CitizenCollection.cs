using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BorderControl.Interfaces;
using BorderControl.Model;

namespace BorderControl.Collections
{
    public class CitizenCollection 
    {
        private Dictionary<string, Citizen> data;
        public CitizenCollection()
        {
            this.data = new Dictionary<string, Citizen>();
        }
     
        public void Add(Citizen citizen)
        {
            if (!data.ContainsKey(citizen.Id))
            {
                data.Add(citizen.Id, citizen);
            }
        }

        public List<Citizen> TakeRevurseId(string ednId)
        {
            var result = data.Values.Where(x => x.Id.EndsWith(ednId)).ToList();
            return result;
        }
    }
}
