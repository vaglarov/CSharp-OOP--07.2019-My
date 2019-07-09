namespace ClassBoxData
{
    using System;
    public class Engine
    {
        public void Run()
        {
            try
            {
                double length = double.Parse(Console.ReadLine());
                double width = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                Box test = new Box(length, width, height);
                Console.WriteLine(test);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
