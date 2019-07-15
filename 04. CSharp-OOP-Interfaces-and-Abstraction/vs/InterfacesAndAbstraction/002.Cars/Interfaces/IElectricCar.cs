namespace Cars.Interfaces
{
    public interface IElectricCar : ICar
    {
        int Battery { get; set; }
    }
}
