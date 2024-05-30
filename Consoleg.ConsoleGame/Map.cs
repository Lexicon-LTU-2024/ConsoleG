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

        cells = new Cell[width, height];
    }
}