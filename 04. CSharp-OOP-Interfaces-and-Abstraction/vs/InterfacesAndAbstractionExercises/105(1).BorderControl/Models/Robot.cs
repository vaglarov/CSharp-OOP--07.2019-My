using BorderControl2.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl2.Models
{
    public class Robot : Civilian, IRobot
    {
        public Robot(string name, string id)
            : base(name, id)
        {
        }
    }
}
