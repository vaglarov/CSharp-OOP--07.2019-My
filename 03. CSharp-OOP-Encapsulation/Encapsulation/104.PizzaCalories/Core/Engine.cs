namespace PizzaCalories.Core
{
    using PizzaCalories.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class Engine
    {
        public Engine()
        {

        }

        public void Run()
        {

            try
            {
                var pizzaName = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Skip(1)
                    .First();
                Dough dough = DoughFactory();
                List<Topping> listToping = ToppingListFactory();
               
               Pizza pizza = new Pizza(pizzaName, dough, listToping);
                Console.WriteLine(pizza.ToString());
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        private List<Topping> ToppingListFactory()
        {
            string lineInput = string.Empty;
            List<Topping> listToping = new List<Topping>();
            while ((lineInput = Console.ReadLine()) != "END")
            {
                Topping topping = ToppingFactory(lineInput);
                listToping.Add(topping);
            }
            return listToping;
        }

        private Topping ToppingFactory(string lineInput)
        {
            string[] lineInputArgs = lineInput.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string product = ToTittleCase(lineInputArgs[1]);
            int weight = int.Parse(lineInputArgs[2]);
            Topping newTopping = new Topping(product, weight);
            return newTopping;
        }

        private Dough DoughFactory()
        {
            string[] lineInput = Console.ReadLine().
                Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string doughtType = ToTittleCase(lineInput[1]);
            string bakintType = ToTittleCase(lineInput[2]);
            int weight = int.Parse(lineInput[3]);
            Dough dough = new Dough(doughtType, bakintType, weight);
            return dough;
        }

        private string ToTittleCase(string input)
        {
            StringBuilder sb = new StringBuilder(input.ToLower());
            sb[0] = char.ToUpper(sb[0]);
            return sb.ToString();
        }
    }
}
