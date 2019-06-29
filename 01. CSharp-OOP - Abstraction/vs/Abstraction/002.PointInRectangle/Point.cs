using System;
using System.Collections.Generic;
using System.Text;

namespace _002.PointInRectangle
{
    public class Point
    {
        public Point(int coordinateX, int coordinateY)
        {
            this.coordinateX = coordinateX;
            this.coordinateY = coordinateY;
        }

        public int coordinateX { get; set; }
        public int coordinateY { get; set; }

    }
}
