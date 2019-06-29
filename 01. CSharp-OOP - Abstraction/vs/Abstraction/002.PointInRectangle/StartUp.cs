using System;
using System.Linq;

namespace _002.PointInRectangle
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] rectanglePoints = Console.ReadLine().
                Split().
                Select(int.Parse).
                ToArray();
            Rectangle newRectangle = new Rectangle(rectanglePoints);

            int numberComparePoint = int.Parse(Console.ReadLine());
            for (int index = 0; index < numberComparePoint; index++)
            {
                int[]pointCoordinate = Console.ReadLine().
                Split().
                Select(int.Parse).
                ToArray();
                Point currentPoint = new Point(pointCoordinate[0], pointCoordinate[1]);
                Console.WriteLine(newRectangle.Contains(currentPoint) ); 
            }

        }
    }
}
