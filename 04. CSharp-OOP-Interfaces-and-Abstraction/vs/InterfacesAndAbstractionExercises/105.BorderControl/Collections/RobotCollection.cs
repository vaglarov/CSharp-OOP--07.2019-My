using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BorderControl.Model;

namespace BorderControl.Collections
{
    public class RobotCollection
    {
        private Dictionary<string, Robot> data;
        public RobotCollection()
        {
            this.data = new Dictionary<string, Robot>();
        }

        public void Add(Robot robot)
        {
            if (!data.ContainsKey(robot.Id))
            {
                data.Add(robot.Id, robot);
            }
        }

        public List<Robot> TakeRevurseId(string ednId)
        {
            var result = data.Values.Where(x => x.Id.EndsWith(ednId)).ToList();
            return result;
        }
    }
}
