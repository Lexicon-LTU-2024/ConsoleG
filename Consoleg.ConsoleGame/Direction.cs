internal class Direction
{
    public static Position North => new Position(y: -1,x:  0);
    public static Position South => new Position(1, 0);
    public static Position West => new Position(0, -1);
    public static Position East => new Position(0, 1);
}