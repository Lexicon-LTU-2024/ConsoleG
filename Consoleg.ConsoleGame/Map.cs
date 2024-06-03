
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

internal class Map
{
    private Cell[,] _cells;
    public int Width { get; }
    public int Height { get; }


    public Map(int width, int height)
    {
        //Validate
        Width = width;
        Height = height;

        _cells = new Cell[height, width];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                _cells[y, x] = new Cell();
            }

        }
    }

   // [return: MaybeNull]
    internal Cell? GetCell(int y, int x)
    {
        try
        {
            return _cells[y, x];
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }
}