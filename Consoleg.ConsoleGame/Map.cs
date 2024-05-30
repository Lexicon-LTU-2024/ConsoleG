internal class Map
{
    public int Width { get; }
    public int Height { get; }

    public Map(int width, int height)
    {
        Width = width;
        Height = height;

        var cells = new Cell[width, height];
    }
}