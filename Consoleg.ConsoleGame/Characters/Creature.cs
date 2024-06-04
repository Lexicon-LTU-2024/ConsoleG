using System.Diagnostics.CodeAnalysis;

internal class Creature : IDrawable
{
    private Cell _cell;
    public Cell Cell 
    {
        get => _cell;

        [MemberNotNull(nameof(_cell))]
        set
        {
            ArgumentNullException.ThrowIfNull(value, nameof(value));
            _cell = value;
        }
    }
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