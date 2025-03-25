namespace s30070_1;

public class RefrigeratedContainer : Container
{
    public string ProductType { get; }
    public double Temperature { get; }

    public RefrigeratedContainer(int height, double emptyWeight, int depth, double maxLoadCapacity, string productType, double temperature)
        : base(height, emptyWeight, depth, maxLoadCapacity)
    {
        ProductType = productType;
        Temperature = temperature;
    }
}