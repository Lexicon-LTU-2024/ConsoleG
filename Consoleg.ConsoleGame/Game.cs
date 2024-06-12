using Consoleg.ConsoleGame;
using Consoleg.ConsoleGame.Extensions;
using Consoleg.ConsoleGame.UserInterface;
using System.Diagnostics;

internal class Game
{
    private Dictionary<ConsoleKey, Action> actionMeny = null!;
    private IMap _map;
    private Player _player = null!;
    private bool gameInProgress;
    private IUI _ui; 

    public Game(IUI ui, IMap map)
    {
        _ui = ui;
        _map = map;
    }

    internal void Run()
    {
        Initialize();
        Play();
    }

    private void Play()
    {
        gameInProgress = true;

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
        var keyPressed = _ui.GetKey();

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
            _ui.AddMessage($"{i + 1}: {_player.BackPack[i]}");
        }
    }

    private void PickUp()
    {
        if (_player.BackPack.IsFull)
        {
            _ui.AddMessage("Backpack is full");
            return;
        }

        var items = _player.Cell.Items;
        var item = _player.Cell.Items.FirstOrDefault();

        if (item is null) return;

        if (_player.BackPack.Add(item))
        {
            _ui.AddMessage($"Player pick up {item}");
            items.Remove(item);
        }
    }

    private void Move(Position movement)
    {
        var newPosition = _player.Cell.Position + movement;
        var newCell = _map.GetCell(newPosition);


        if (newCell is not null)
        {
            Creature? opponent = _map.CreatureAt(newCell);
            if(opponent is not null)
            {
                _player.Attack(opponent);
                opponent.Attack(_player);
            }

            gameInProgress = !_player.IsDead;


            _player.Cell = newCell;
            if (newCell.Items.Any())
                _ui.AddMessage($"You see: {string.Join(", ", newCell.Items)}");
        }
    }

    private void Drawmap()
    {
        _ui.Clear();
        _ui.Draw(_map);
        _ui.PrintStats($"Health: {_player.Health}, Enemys: {_map.Creatures.Where(c => !c.IsDead).Count() -1}   ");
        _ui.PrintLog();
    }

    private void Initialize()
    {
        CreateActionMeny();
        //ToDo: Read from config
        //_map = new Map(width: 10, height: 10);
        Cell? playerCell = _map.GetCell(0, 0);
        _player = new Player(playerCell!);
        _map.Creatures.Add(_player);

        var r = new Random();

        //_map.GetCell(2, 2).Items.Add(Item.Coin());
        //_map.GetCell(2, 2).Items.Add(Item.Coin());
        //_map.GetCell(2, 2).Items.Add(Item.Stone());
        //_map.GetCell(2, 2).Items.Add(Item.Coin());

        RCell().Items.Add(Item.Coin());
        RCell().Items.Add(Item.Coin());
        RCell().Items.Add(Item.Stone());
        RCell().Items.Add(Item.Stone());
        RCell().Items.Add(Item.Stone());

        _map.Place(new Orc(RCell()));
        _map.Place(new Orc(RCell()));
        _map.Place(new Troll(RCell()));
        _map.Place(new Troll(RCell()));
        _map.Place(new Goblin(RCell()));
        _map.Place(new Goblin(RCell()));

        //_map.Creatures.ForEach(c =>
        //{
          
        //    c.AddToLog = ConsoleUI.AddMessage;
        //    c.AddToLog += m => Debug.WriteLine(m);
        //});

        Creature.AddToLog = _ui.AddMessage;
       // Creature.AddToLog += Console.WriteLine; 

        Cell RCell()
        {
            var width = r.Next(0, _map.Width);
            var height = r.Next(0, _map.Height);

            var cell = _map.GetCell(height, width);
            ArgumentNullException.ThrowIfNull(cell, nameof(cell));

            return cell;
        }
        
    }

    private void CreateActionMeny()
    {
        actionMeny = new Dictionary<ConsoleKey, Action>()
        {
            { ConsoleKey.P, PickUp },
            { ConsoleKey.I, Inventory },
            {ConsoleKey.D, Drop }
        };
    }

    private void Drop()
    {
        var item = _player.BackPack.FirstOrDefault();
        if (item != null && _player.BackPack.Remove(item)) 
        {
            _player.Cell.Items.Add(item);
            _ui.AddMessage($"Player dropped the {item}");
        }
        else
        {
            _ui.AddMessage("Backpack is empty");
        }
    }
}