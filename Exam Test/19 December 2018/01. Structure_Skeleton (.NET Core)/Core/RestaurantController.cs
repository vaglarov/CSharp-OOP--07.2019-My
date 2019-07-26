namespace SoftUniRestaurant.Core
{
    using SoftUniRestaurant.Models.Drinks.Contracts;
    using SoftUniRestaurant.Models.Drinks.Factories;
    using SoftUniRestaurant.Models.Foods.Contracts;
    using SoftUniRestaurant.Models.Foods.Factories;
    using SoftUniRestaurant.Models.Tables;
    using SoftUniRestaurant.Models.Tables.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class RestaurantController
    {
        private IList<IFood> menu;
        private IList<IDrink> drinks;
        private IList<ITable> tables;
        private decimal income;


        //Factory
        private FoodFactory foodFactory;
        private DrinkFactory drinkFactory;
        private TableFactory tableFactory;

        public RestaurantController() //ok
        {
            this.menu = new List<IFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();

            //Factory 
            this.foodFactory = new FoodFactory();
            this.drinkFactory = new DrinkFactory();
            this.tableFactory = new TableFactory();
            this.income = 0.0m;

        }


        public string AddFood(string type, string name, decimal price) //ok
        {
            IFood food = this.foodFactory.CreateFood(type, name, price);
            menu.Add(food);
            return $"Added {food.Name} ({food.GetType().Name}) with price {food.Price:f2} to the pool";
        }

        public string AddDrink(string type, string name, int servingSize, string brand)
        {
            IDrink drink = this.drinkFactory.CreateDrink(type, name, servingSize, brand);
            drinks.Add(drink);
            return $"Added {drink.Name} ({drink.Brand}) to the drink pool";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = this.tableFactory.CreateTable(type, tableNumber, capacity);
            tables.Add(table);
            return $"Added table number {table.TableNumber} in the restaurant";
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = tables.FirstOrDefault(t => t.IsReserved == false && t.Capacity >= numberOfPeople);
            if (table==null)
            {
                return $"No available table for {numberOfPeople} people";
            }
            else
            {
                table.Reserve(numberOfPeople);
                return $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";
            }
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber== tableNumber);
            if (table == null)
            {
                return $"Could not find table with {tableNumber}";
            }
            else
            {
                IFood food = this.menu.FirstOrDefault(f => f.Name == foodName);
                if (food==null)
                {
                    return $"No {foodName} in the menu";
                }
                else
                {
                    table.OrderFood(food);
                    return $"Table {tableNumber} ordered {foodName}";
                }
            }
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            if (table == null)
            {
                return $"Could not find table with {tableNumber}";
            }
            else
            {
                IDrink drink = this.drinks.FirstOrDefault(d => d.Name == drinkName&&d.Brand==drinkBrand);
                if (drink == null)
                {
                    return $"There is no {drinkName} {drinkBrand} available";
                }
                else
                {
                    table.OrderDrink(drink);
                    return $"Table {tableNumber} ordered {drinkName}";
                }
            }
        }

        public string LeaveTable(int tableNumber)
        {

            ITable currentTable = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            decimal bill = currentTable.GetBill();
            currentTable.Clear();
            this.income += bill;
            return $"Table: {tableNumber}" +
            $"{Environment.NewLine}"+$"Bill: {bill:f2}";

        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var table in tables.Where(x=>x.IsReserved==false))
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string GetOccupiedTablesInfo()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var table in tables.Where(x => x.IsReserved == true))
            {
                sb.AppendLine(table.GetOccupiedTableInfo() );
            }
            return sb.ToString().TrimEnd();
        }
        public string GetSummary()
        {
            return $"Total income: {income:f2}lv";
        }
    }
}
