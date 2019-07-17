using BirthdayCelebr.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebr.Models
{
    public class Robot : Civilian, IRobot
    {
        public Robot(string name, string id)
            : base(name, id)
        {
        }
    }
}
