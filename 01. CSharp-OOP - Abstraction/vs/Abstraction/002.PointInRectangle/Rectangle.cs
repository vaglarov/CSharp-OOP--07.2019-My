using System;
using System.Collections.Generic;
using System.Text;

namespace _002.PointInRectangle
{
    public class Rectangle
    {
        public Rectangle(int topLeftX, int topLeftY, int bottomRightX, int bottomRightY)
        {
            this.topLeftX = topLeftX;
            this.topLeftY = topLeftY;
            this.bottomRightX = bottomRightX;
            this.bottomRightY = bottomRightY;
        }
        public Rectangle(int[] twoPointInARow)
        {
            this.topLeftX = twoPointInARow[0];
            this.topLeftY = twoPointInARow[1];
            this.bottomRightX = twoPointInARow[2];
            this.bottomRightY = twoPointInARow[3];
        }
        public int topLeftX { get; set; }
        public int topLeftY { get; set; }
        public int bottomRightX { get; set; }
        public int bottomRightY { get; set; }

        public int Wight()
        {
            return Math.Abs(bottomRightX - topLeftX);
        }

        public int Hight()
        {
            return Math.Abs( topLeftY - bottomRightY);
        }

        public bool Contains(Point point)
        {
            if (point.coordinateX>= topLeftX&& 
                point.coordinateX <= topLeftX+Wight()&&
                point.coordinateY>=topLeftY&&
                point.coordinateY<=topLeftY+Hight()
               )
            {
                return true;
            }
            return false;
        }


    }
}
