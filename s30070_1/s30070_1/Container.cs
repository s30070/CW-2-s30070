namespace s30070_1;

public abstract class Container
{
    private static int nextSerialNumber = 1;

    public double LoadWeight { get; protected set; }
    public int Height { get; }
    public double EmptyWeight { get; }
    public int Depth { get; }
    public string SerialNumber { get; }
    public double MaxLoadCapacity { get; }

    protected Container(int height, double emptyWeight, int depth, double maxLoadCapacity)
    {
        Height = height;
        EmptyWeight = emptyWeight;
        Depth = depth;
        MaxLoadCapacity = maxLoadCapacity;
        SerialNumber = $"KON-{GetType().Name[0]}-{nextSerialNumber++}";
    }

    public virtual void Load(double weight)
    {
        if (LoadWeight + weight > MaxLoadCapacity)
        {
            throw new OverfillException("Przekroczono maksymalną ładowność kontenera.");
        }
        LoadWeight += weight;
    }

    public virtual void Unload()
    {
        LoadWeight = 0;
    }

    public override string ToString()
    {
        return $"Numer seryjny: {SerialNumber}, Wysokość: {Height} cm, Waga własna: {EmptyWeight} kg, Głębokość: {Depth} cm, Maksymalna ładowność: {MaxLoadCapacity} kg, Aktualna waga ładunku: {LoadWeight} kg";
    }
}