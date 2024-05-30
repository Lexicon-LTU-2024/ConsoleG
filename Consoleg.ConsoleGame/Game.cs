

internal class Game
{
    public Game()
    {
    }

    internal void Run()
    {
        Initialize();
    }

    private void Initialize()
    {
        //ToDo: Read from config
        var map = new Map(width: 10, height: 10);
    }
}