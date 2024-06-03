internal class Player : Creature
{
    public Player(Cell cell) : base(cell, "P ")
    {
        Color = ConsoleColor.White;
    }
}
