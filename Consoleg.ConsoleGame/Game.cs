using Consoleg.ConsoleGame.Extensions;
using Consoleg.ConsoleGame.UserInterface;

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
            GetCommand();
            //Act

            //Drawmap

            //EnemyAction

            //Drawmap

        } while (gameInProgress);

    }

    private void GetCommand()
    {
        var keyPressed = ConsoleUI.GetKey();

        switch (keyPressed)
        {
            case ConsoleKey.UpArrow:
                Move(Direction.North);
                break;
            case ConsoleKey.DownArrow:
                Move(Direction.South);
                break;
            case ConsoleKey.LeftArrow:
                Move(Direction.West);
                break;
            case ConsoleKey.RightArrow:
                Move(Direction.East);
                break;
        }
    }

    private void Move(Position movement)
    {
        var newPosition = _player.Cell.Position + movement;
        var newCell = _map.GetCell(newPosition);
        if (newCell is not null) _player.Cell = newCell;
    }

    private void Drawmap()
    {
        Console.Clear();

        for (int y = 0; y < _map.Height; y++)
        {
            for (int x = 0; x < _map.Width; x++)
            {
                Cell? cell =  _map.GetCell(y, x);
                ArgumentNullException.ThrowIfNull(cell, nameof(cell));

                IDrawable drawable = _map.Creatures.CreatureAtExtension(cell);
                Console.ForegroundColor = drawable.Color;
                Console.Write(drawable.Symbol);
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
        _player = new Player(playerCell!);
        _map.Creatures.Add(_player);
        
    }
}