using Consoleg.ConsoleGame;
using Consoleg.ConsoleGame.Extensions;
using Consoleg.ConsoleGame.UserInterface;

internal class Game
{
    private Dictionary<ConsoleKey, Action> actionMeny;
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
            //case ConsoleKey.P:
            //    PickUp();
            //    break;
            //case ConsoleKey.I:
            //    Inventory();
            //    break;

        }

        if (actionMeny.ContainsKey(keyPressed))
        {
            actionMeny[keyPressed]?.Invoke();
        }

    }

    private void Inventory()
    {
        for (int i = 0; i < _player.BackPack.Count; i++)
        {
            ConsoleUI.AddMessage($"{i + 1}: {_player.BackPack[i]}");
        }
    }

    private void PickUp()
    {
        if (_player.BackPack.IsFull)
        {
            ConsoleUI.AddMessage("Backpack is full");
            return;
        }

        var items = _player.Cell.Items;
        var item = _player.Cell.Items.FirstOrDefault();

        if (item is null) return;

        if (_player.BackPack.Add(item))
        {
            ConsoleUI.AddMessage($"Player pick up {item}");
            items.Remove(item);
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
        ConsoleUI.Clear();
        ConsoleUI.Draw(_map);
        ConsoleUI.PrintStats($"Health: {_player.Health}");
        ConsoleUI.PrintLog();

        
    }

    private void Initialize()
    {
        CreateActionMeny();
        //ToDo: Read from config
        _map = new Map(width: 10, height: 10);
        Cell? playerCell = _map.GetCell(0, 0);
        _player = new Player(playerCell!);
        _map.Creatures.Add(_player);

        _map.GetCell(2, 5)?.Items.Add(Item.Coin());
        _map.GetCell(5, 4)?.Items.Add(Item.Coin());
        _map.GetCell(6, 1)?.Items.Add(Item.Stone());
        _map.GetCell(6, 1)?.Items.Add(Item.Stone());
        _map.GetCell(1, 3)?.Items.Add(Item.Stone());
        
    }

    private void CreateActionMeny()
    {
        actionMeny = new Dictionary<ConsoleKey, Action>()
        {
            { ConsoleKey.P, PickUp },
            { ConsoleKey.I, Inventory }
        };
    }
}