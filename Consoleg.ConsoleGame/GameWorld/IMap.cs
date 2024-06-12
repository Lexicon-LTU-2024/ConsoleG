
internal interface IMap
{
    List<Creature> Creatures { get; }
    int Height { get; }
    int Width { get; }

    Cell? GetCell(int y, int x);
    Cell? GetCell(Position newPosition);
    void Place(Creature creature);
    Creature? CreatureAt(Cell cell);
}