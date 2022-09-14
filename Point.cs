class Point
{
    public int x { get; set; }
    public int y { get; set; }
    public Direction Direction;

    public Point(int x, int y, char direct)
    {
        this.x = x;
        this.y = y;

        direct = Char.ToLower(direct);
        switch (direct)
        {
            case 'n':
                this.Direction = Direction.North;
                break;
            case 'e':
                this.Direction = Direction.East;
                break;
            case 's':
                this.Direction = Direction.South;
                break;
            case 'w':
                this.Direction = Direction.West;
                break;
            default:
                throw new CustomException("invalid direction");

        }
    }
}
