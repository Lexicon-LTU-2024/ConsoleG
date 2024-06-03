internal class Cell : IDrawable
{
    public string Symbol => ". ";
    public ConsoleColor Color { get; }
    public int Y { get; }
    public int X { get; }

    public Cell(int y, int x)
    {
        Color = ConsoleColor.Red;
        Y = y;
        X = x;
    }
}