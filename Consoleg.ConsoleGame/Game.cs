



internal class Game
{
    private Map _map = null!;
    private Player _player = null!;

    public Game()
    {
    }

    internal void Run()
    {
        Initialize();
        Play();
    }

    private void Play()
    {
        bool gameInProgress = true;

        do
        {
            //Drawmap
            Drawmap();

            //Getcommand

            //Act

            //Drawmap

            //EnemyAction

            //Drawmap

            Console.ReadKey();

        } while (gameInProgress);

    }

    private void Drawmap()
    {
        Console.Clear();

        for (int y = 0; y < _map.Height; y++)
        {
            for (int x = 0; x < _map.Width; x++)
            {
                //Todo handle null!!!
                Cell? cell = _map.GetCell(y, x);
                Console.ForegroundColor = cell.Color;
                Console.Write(cell.Symbol);
            }
            Console.WriteLine();
        }

        Console.ResetColor();
    }

    private void Initialize()
    {
        //ToDo: Read from config
        _map = new Map(width: 10, height: 10);
        Cell? playerCell = _map.GetCell(0, 0);
        _player = new Player(playerCell);
        _map.Creatures.Add(_player);
        
    }
}