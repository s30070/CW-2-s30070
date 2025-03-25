namespace s30070_1;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazardous { get; }

    public LiquidContainer(int height, double emptyWeight, int depth, double maxLoadCapacity, bool isHazardous)
        : base(height, emptyWeight, depth, maxLoadCapacity)
    {
        IsHazardous = isHazardous;
    }

    public override void Load(double weight)
    {
        double maxAllowedWeight = IsHazardous ? MaxLoadCapacity * 0.5 : MaxLoadCapacity * 0.9;
        if (LoadWeight + weight > maxAllowedWeight)
        {
            SendHazardNotification($"Próba przekroczenia maksymalnej ładowności dla kontenera {SerialNumber}.");
            throw new OverfillException("Przekroczono maksymalną ładowność kontenera.");
        }
        base.Load(weight);
    }

    public void SendHazardNotification(string message)
    {
        Console.WriteLine($"UWAGA: {message}");
    }
}