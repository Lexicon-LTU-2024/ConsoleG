
using Consoleg.ConsoleGame.Extensions;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

internal class Map : IMap
{
    private Cell[,] _cells;
    public int Width { get; }
    public int Height { get; }

    public List<Creature> Creatures { get; } = new List<Creature>();


    public Map(IConfiguration config)
    {
        //Validate
        Width = config.GetMapSizeFor("x");
        Height = config.GetMapSizeFor("y");

        _cells = new Cell[Height, Width];

        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                _cells[y, x] = new Cell(new Position(y, x));
            }

        }
    }

    // [return: MaybeNull]
    public Cell? GetCell(int y, int x)
    {
        return (x < 0 || x >= Width || y < 0 || y >= Height) ? null : _cells[y, x];
    }

    public Cell? GetCell(Position newPosition)
    {
        return GetCell(newPosition.Y, newPosition.X);
    }

    public void Place(Creature creature)
    {
       if(Creatures.FirstOrDefault(c => c.Cell == creature.Cell) == null)
        {
            Creatures.Add(creature);
        }

    }

    public Creature? CreatureAt(Cell cell) => Creatures.FirstOrDefault(c => c.Cell == cell);
  
}