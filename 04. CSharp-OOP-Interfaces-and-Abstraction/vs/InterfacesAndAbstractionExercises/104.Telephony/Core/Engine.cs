namespace _104.Telephony.Core
{
    using _104.Telephony.Model;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Engine
    {
        public Engine()
        {

        }
        public void Run()
        {
            string[] lineNumbers = Console.ReadLine().Split();
            string[] lineURL = Console.ReadLine().Split();
            CallingNumbers(lineNumbers);
            Browsing(lineURL);
        }

        private void Browsing(string[] lineURL)
        {
            foreach (var URL in lineURL)
            {
                Smartphone telephone = new Smartphone();
                string browsing = telephone.Browsing(URL);
                PrintResult(browsing);
            }
        }

        private void CallingNumbers(string[] lineNumbers)
        {
            foreach (var number in lineNumbers)
            {
                Smartphone telephone = new Smartphone();
                string calling = telephone.Calling(number);
                PrintResult(calling);
            }
        }

        private void PrintResult(string result)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(result);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
