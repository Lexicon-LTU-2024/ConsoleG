using Consoleg.ConsoleGame;
using Consoleg.LimitedList;

internal class Player : Creature
{
    public LimitedList<Item> BackPack { get; }
   

    public Player(Cell cell) : base(cell, symbol: "P ",maxHealth: 100, damage: 75)
    {
        Color = ConsoleColor.White;
        BackPack = new LimitedList<Item>(3);
       
    }

   
}
