namespace _103.Ferrari.Interfaces
{
    public interface ICar
    {
        string Model { get; }
        string DriverName { get; }
        string PushGas();
        string PushBrake();

    }
}
