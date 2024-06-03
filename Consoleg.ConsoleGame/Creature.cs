internal class Creature : IDrawable
{
    //ToDo validate set
    public Cell Cell { get; set; }
    public string Symbol { get; }
    public ConsoleColor Color { get; protected set; } = ConsoleColor.Green;
    public Creature(Cell cell, string symbol)
    {
        Cell = cell ?? throw new ArgumentNullException(nameof(cell));
      
        if (string.IsNullOrEmpty(symbol))
        {
            throw new ArgumentException($"'{nameof(symbol)}' cannot be null or empty.", nameof(symbol));
        }

        Symbol = symbol;
    }

}