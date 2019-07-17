using BirthdayCelebr.Exceptions;
using BirthdayCelebr.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebr.Models
{
    public class Item : IItem
    {
        public Item(string name)
        {
            ValidateName(name);
        }

        public string Name
        { get; private set; }
        private void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new InvalidNameException();
            }
            this.Name = name;
        }
        
    }
}
