internal class Map
{
    private Cell[,] cells;
    public int Width { get; }
    public int Height { get; }


    public Map(int width, int height)
    {
        //Validate
        Width = width;
        Height = height;

        cells = new Cell[height, width];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                cells[y, x] = new Cell();
            }

        }
    }
}