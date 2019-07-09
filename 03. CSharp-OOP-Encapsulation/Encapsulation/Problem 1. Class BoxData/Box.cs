namespace ClassBoxData
{
    using System;
   public class Box
    {
        private double length;
        //, width and height
        private double widht;
        private double height;

        public Box(double lenght, double widht, double height)
        {
            this.Lenght = lenght;
            this.Widht = widht;
            this.Height = height;
        }

        public double Lenght
        {
            get { return this.length; }
            private set
            {
                if (value<=0)
                {
                    throw new ArgumentException("Lenght cannot be zero or negative.");
                }
                this.length = value;
            }
        }
        public double  Widht
        {
            get { return this.widht; }
            private set
            {
                if (value<=0)
                {
                    throw new ArgumentException("Widht cannot be zero or negative.");
                }
                this.widht = value;
            }
        }
        public double Height
        {
            get { return this.height; }
           private set
            {
                if (value<=0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
                this.height = value;
            }
        }

        public double SurfaceArea =>
            2 * (this.Lenght * this.Widht + this.Lenght * this.Height + this.Widht * this.Height);
        public double LateralSurfaceArea =>
            2 * (this.Lenght * this.Height + this.Widht * this.Height);

        public double Volume =>
            this.Lenght * this.Height * this.Widht;
        public override string ToString()
        {
            return $"Surface Area – {this.SurfaceArea:f2}" +
                   $"{Environment.NewLine}Lateral Surface Area –{this.LateralSurfaceArea:f2}" +
                   $"{Environment.NewLine}Volume – {this.Volume:f2}";
        }

    }
}
