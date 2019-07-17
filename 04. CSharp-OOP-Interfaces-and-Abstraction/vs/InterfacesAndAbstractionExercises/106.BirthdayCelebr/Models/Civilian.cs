using BirthdayCelebr.Exceptions;
using BirthdayCelebr.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebr.Models
{
    public class Civilian : Item,ICivilian
    { 
        public Civilian(string name,string id)
            :base(name)
        {
            ValidateID(id);
        }
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
     

        public bool GetWithEndId(string endArg)
        {
            return this.Id.EndsWith(endArg);
        }
    }
}
