namespace RogueLikeGame.Utils;

public struct Position
{
    public int X { get; set; }
    public int Y { get; set; }

    public static Position Up => new Position(0, -1);
    public static Position Down => new Position(0, 1);
    public static Position Left => new Position(-1, 0);
    public static Position Right => new Position(1, 0);

    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }

    public static Position operator +(Position a, Position b)
    {
        return new Position(a.X + b.X, a.Y + b.Y);
    }
}
