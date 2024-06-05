using Consoleg.ConsoleGame;
using Consoleg.LimitedList;

internal class Player : Creature
{
    public LimitedList<Item> BackPack { get; }
    public Player(Cell cell) : base(cell, "P ")
    {
        Color = ConsoleColor.White;
        BackPack = new LimitedList<Item>(3);
    }
}
