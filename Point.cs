class Point
{
    public int x;
    public int y;

    public Direction direction;

    public Point(int x, int y, char direct)
    {
        this.x = x;
        this.y = y;
        direct = Char.ToLower(direct);
        switch (direct)
        {
            case 'n':
                this.direction = Direction.North;
                break;
            case 'e':
                this.direction = Direction.East;
                break;
            case 's':
                this.direction = Direction.South;
                break;
            case 'w':
                this.direction = Direction.West;
                break;
            default:
                throw new CustomException("invalid direction");

        }
    }
}
