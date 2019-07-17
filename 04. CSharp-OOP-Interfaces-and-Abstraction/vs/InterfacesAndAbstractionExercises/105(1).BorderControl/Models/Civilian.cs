using BorderControl2.Exceptions;
using BorderControl2.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl2.Models
{
    public class Civilian : ICivilian
    { 
        public Civilian(string name,string id)
        {
            ValidateName(name);
            ValidateID(id);
        }

        public string Name
        { get; private set; }

        public string Id
        { get; private set; }
        private void ValidateID(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new InvalidIDException();
            }
            this.Id = id;
        }
        private void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new InvalidNameException();
            }
            this.Name = name;
        }

        public bool GetWithEndId(string endArg)
        {
            return this.Id.EndsWith(endArg);
        }
    }
}
