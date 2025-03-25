namespace s30070_1;

public class ContainerShip
{
    public List<Container> Containers { get; } = new List<Container>();
    public double MaxSpeed { get; }
    public int MaxContainers { get; }
    public double MaxWeight { get; }

    public ContainerShip(double maxSpeed, int maxContainers, double maxWeight)
    {
        MaxSpeed = maxSpeed;
        MaxContainers = maxContainers;
        MaxWeight = maxWeight;
    }

    public void LoadContainer(Container container)
    {
        if (Containers.Count >= MaxContainers)
        {
            throw new Exception("Statek osiągnął maksymalną liczbę kontenerów.");
        }
        if (Containers.Sum(c => c.LoadWeight + c.EmptyWeight) + container.LoadWeight + container.EmptyWeight > MaxWeight * 1000)
        {
            throw new Exception("Statek osiągnął maksymalną wagę ładunku.");
        }
        Containers.Add(container);
    }

    public void LoadContainers(List<Container> containers)
    {
        foreach (var container in containers)
        {
            LoadContainer(container);
        }
    }

    public void UnloadContainer(Container container)
    {
        Containers.Remove(container);
    }

    public void ReplaceContainer(string serialNumber, Container newContainer)
    {
        int index = Containers.FindIndex(c => c.SerialNumber == serialNumber);
        if (index == -1)
        {
            throw new Exception("Kontener o podanym numerze seryjnym nie istnieje.");
        }
        Containers[index] = newContainer;
    }

    public void TransferContainer(ContainerShip otherShip, Container container)
    {
        if (Containers.Contains(container))
        {
            UnloadContainer(container);
            otherShip.LoadContainer(container);
        }
        else
        {
            throw new Exception("Kontener nie znajduje się na tym statku.");
        }
    }

    public override string ToString()
    {
        string containerList = string.Join("\n", Containers.Select(c => c.ToString()));
        return $"Maksymalna prędkość: {MaxSpeed} węzłów, Maksymalna liczba kontenerów: {MaxContainers}, Maksymalna waga: {MaxWeight} ton, Kontenery:\n{containerList}";
    }
}