using System;

namespace RhombusOfStars
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int sizeRombus = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Red;
            for (int index = 1; index <= sizeRombus; index++)
            {
                PrintRowStars(index, sizeRombus);
            }
            for (int index = sizeRombus - 1; index >= 1; index--)
            {
                PrintRowStars(index, sizeRombus);

            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void PrintRowStars(int index, int sizeRombus)
        {
            string emptySpaces = new string(' ', sizeRombus - index);
            string stars = string.Empty;
            for (int i = 1; i <= index; i++)
            {
                stars += "* ";
            }
            Console.WriteLine($"{emptySpaces}{stars}");
        }
    }
}
