namespace s30070_1;

public class OverfillException : Exception
{
    public OverfillException(string message) : base(message) { }
}