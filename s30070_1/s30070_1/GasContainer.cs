namespace s30070_1;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; }

    public GasContainer(int height, double emptyWeight, int depth, double maxLoadCapacity, double pressure)
        : base(height, emptyWeight, depth, maxLoadCapacity)
    {
        Pressure = pressure;
    }

    public override void Unload()
    {
        LoadWeight *= 0.05;
    }

    public void SendHazardNotification(string message)
    {
        Console.WriteLine($"UWAGA: {message}");
    }
}