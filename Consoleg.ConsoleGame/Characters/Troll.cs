internal class Troll : Creature
{
    public Troll(Cell cell) : base(cell, "T ", 120)
    {
        Damage = 30;
        Color = ConsoleColor.DarkYellow;
    }
}

