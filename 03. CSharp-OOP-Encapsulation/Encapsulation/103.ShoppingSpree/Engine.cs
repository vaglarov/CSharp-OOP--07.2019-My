namespace ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Engine
    {
        public void Run()
        {
            try
            {
                Dictionary<string, Person> listPersons = new Dictionary<string, Person>();
                Dictionary<string, Product> listProducts = new Dictionary<string, Product>();
                string personLineInput = Console.ReadLine();
                PersonFactory(listPersons, personLineInput);
                string productLineInput = Console.ReadLine();
                ProductFactory(listProducts, productLineInput);

                string lineInput = Console.ReadLine();
                while (lineInput != "END")
                {
                    string[] buyPasser = lineInput.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string personName = buyPasser[0];
                    string productName = buyPasser[1];
                    if (listPersons.ContainsKey(personName))
                    {
                        if (listProducts.ContainsKey(productName))
                        {
                            var currentPerson = listPersons[personName];
                            var currentProduct = listProducts[productName];
                            currentPerson.Buy(currentProduct);
                        }
                    }
                        lineInput = Console.ReadLine();
                   
                }
                PrintResult(listPersons);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void ProductFactory(Dictionary<string, Product> listProducts, string lineInput)
        {
            var productPaser = lineInput.Split(";", StringSplitOptions.RemoveEmptyEntries);
            foreach (var personLine in productPaser)
            {
                string[] productArgs = personLine.Split("=", StringSplitOptions.RemoveEmptyEntries);
                string name = productArgs[0];
                decimal money = decimal.Parse(productArgs[1]);
                Product newProduct = new Product(name, money);
                listProducts.Add(name, newProduct);
            }
        }

        private void PersonFactory(Dictionary<string, Person> listPersons, string lineInput)
        {
            var personsPaser = lineInput.Split(";", StringSplitOptions.RemoveEmptyEntries);
            foreach (var personLine in personsPaser)
            {
                string[] personsArgs = personLine.Split("=", StringSplitOptions.RemoveEmptyEntries);
                string name = personsArgs[0];
                decimal money = decimal.Parse(personsArgs[1]);
                Person newPerson = new Person(name, money);
                listPersons.Add(name, newPerson);
            }
        }
        private void PrintResult(Dictionary<string, Person> listPersons)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var person in listPersons)
            {
                Console.WriteLine(person.Value.ToString());
            }
            Console.ForegroundColor = ConsoleColor.White;

        }
    }

}
