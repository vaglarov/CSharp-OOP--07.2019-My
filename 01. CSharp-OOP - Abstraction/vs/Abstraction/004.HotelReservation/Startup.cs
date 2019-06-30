namespace _004.HotelReservation
{
    using System;
    public class Startup
    {


        static void Main()
        {
            string[] inputLine = Console.ReadLine().Split();
            decimal pricePurDay = decimal.Parse(inputLine[0]);
            int numberOfDays = int.Parse(inputLine[1]);
            Season season;
            Enum.TryParse(inputLine[2], out season);
            Discount discount;
            if (inputLine.Length == 4)
            {
                Enum.TryParse(inputLine[3], out discount);
            }
            else
            {
                discount = Discount.None;
            }

            var result = PriceCalculator.CalculatePrice(pricePurDay, numberOfDays, season, discount);

            Console.WriteLine($"{result:f2}");

        }
    }
}
