namespace Cars.Model
{
    using Cars.Interfaces;
    using System.Text;
    public class Tesla : Seat, IElectricCar, ICar
    {
        public Tesla(string model, string color, int battery)
            : base(model, color)
        {
            this.Battery = battery;
        }
        public int Battery { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Color} Tesla {this.Model} with {this.Battery} Batteries");
            sb.AppendLine($"{Start()}");
            sb.AppendLine($"{Stop()}");
            return sb.ToString().TrimEnd();

        }
    }
}
