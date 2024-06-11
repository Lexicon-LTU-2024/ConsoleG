using System.Diagnostics.CodeAnalysis;

internal class Creature : IDrawable
{
    private Cell _cell;
    private int _health;
    private ConsoleColor _color;

    public Cell Cell 
    {
        get => _cell;

        [MemberNotNull(nameof(_cell))]
        set
        {
            ArgumentNullException.ThrowIfNull(value, nameof(value));
            _cell = value;
        }
    }

    public string Name => GetType().Name;
    public string Symbol { get; }
    public int MaxHealth { get; }


    public int Health
    {
        get => _health;
        set => _health = value >= MaxHealth ? MaxHealth : value;
    }

    public bool IsDead => _health <= 0;

    public int Damage { get; protected set; }

    public static Action<string>? AddToLog { get; set; }

    public ConsoleColor Color 
    { 
        get => IsDead ? ConsoleColor.Gray : _color;
        protected set => _color = value;

    } 
    public Creature(Cell cell, string symbol, int maxHealth, int damage = 50)
    {
        Cell = cell ?? throw new ArgumentNullException(nameof(cell));
      
        if (string.IsNullOrEmpty(symbol))
        {
            throw new ArgumentException($"'{nameof(symbol)}' cannot be null or empty.", nameof(symbol));
        }

        Symbol = symbol;
        MaxHealth = maxHealth;
        Health = maxHealth;
        Damage = damage;
        Color = ConsoleColor.Green;
    }

    public void Attack(Creature target)
    {
        if (target.IsDead || this.IsDead) return;

        var attacker = this.Name;

        target.Health -= this.Damage;

        AddToLog?.Invoke($"The {attacker} attacks the {target.Name} for {this.Damage}");

        if (target.IsDead)
            AddToLog?.Invoke($"The {target.Name} is dead");

    }

    

}



