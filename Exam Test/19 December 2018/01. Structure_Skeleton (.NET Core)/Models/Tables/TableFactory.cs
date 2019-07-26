using SoftUniRestaurant.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SoftUniRestaurant.Models.Tables
{
    public class TableFactory
    {                                //string type, int tableNumber, int capacity
        public ITable CreateTable(string typeTable, int tableNumber, int capacity)
        {
            Type typeClass = Assembly.GetCallingAssembly()
              .GetTypes()
              .FirstOrDefault(t => t.Name == typeTable);

            ITable table = (ITable)Activator.CreateInstance(typeClass, tableNumber, capacity);

            return table;
        }
    }
}
