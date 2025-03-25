using s30070_1;

public class Program
{
    public static void Main(string[] args)
    {
        ContainerShip ship = new ContainerShip(20, 10, 100);

        LiquidContainer liquidContainer = new LiquidContainer(200, 1000, 300, 10000, true);
        GasContainer gasContainer = new GasContainer(200, 800, 300, 8000, 10);
        RefrigeratedContainer refrigeratedContainer = new RefrigeratedContainer(200, 1200, 300, 12000, "Banany", 5);

        liquidContainer.Load(4000);
        gasContainer.Load(7000);
        refrigeratedContainer.Load(10000);

        ship.LoadContainer(liquidContainer);
        ship.LoadContainer(gasContainer);
        ship.LoadContainer(refrigeratedContainer);

        Console.WriteLine(ship);

        ship.UnloadContainer(gasContainer);

        Console.WriteLine(ship);

        LiquidContainer newLiquidContainer = new LiquidContainer(200, 1100, 300, 11000, false);
        ship.ReplaceContainer(liquidContainer.SerialNumber, newLiquidContainer);

        Console.WriteLine(ship);

        ContainerShip otherShip = new ContainerShip(18, 8, 80);
        ship.TransferContainer(otherShip, refrigeratedContainer);

        Console.WriteLine(ship);
        Console.WriteLine(otherShip);
    }
}