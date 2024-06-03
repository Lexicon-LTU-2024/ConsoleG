internal class Player : Creature
{
    public Player(Cell cell) : base(cell, "P ")
    {
        Color = ConsoleColor.White;
    }
}


internal class Creature
{
    public Cell Cell { get; }
    public string Symbol { get; }
    public ConsoleColor Color { get; protected set; } = ConsoleColor.Green;
    public Creature(Cell cell, string symbol)
    {
        Cell = cell;
        Symbol = symbol;
    }

}