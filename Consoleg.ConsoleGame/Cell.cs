internal class Cell
{
    public string Symbol => ". ";
    public ConsoleColor Color { get; }

    public Cell()
    {
        Color = ConsoleColor.Red;
    }
}