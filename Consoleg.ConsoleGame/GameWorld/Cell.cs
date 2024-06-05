using Consoleg.ConsoleGame;

internal class Cell : IDrawable
{
    public string Symbol => ". ";
    public ConsoleColor Color { get; }
    public Position Position { get; }

    public List<Item> Items { get; } = new List<Item>();

    public Cell(Position position)
    {
        Color = ConsoleColor.Red;
        Position = position;
    }
}