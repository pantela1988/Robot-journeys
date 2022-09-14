try
{
    Point StartPoint = new Point(1, 1, 'E');
    Point EndPoint = new Point(1, 1, 'E');


    string input = "RFRFRFRF";


    addSteps(input, StartPoint);


    Console.WriteLine(StartPoint.x + " " + StartPoint.y + " " + StartPoint.direction);
    Console.WriteLine(EndPoint.x + " " + EndPoint.y + " " + EndPoint.direction);
    Console.WriteLine(checkRoute(StartPoint, EndPoint));

}
catch (CustomException ex)
{
    Console.WriteLine(ex.Message);
}


static bool checkRoute(Point Start, Point End)
{
    return Start.x == End.x && Start.y == End.y && Start.direction == End.direction;
}

static void addSteps(string steps, Point StartPoint)
{

    for (int i = 0; i < steps.Length; i++)
    {
        StartPoint.direction = changeDirection(steps[i], StartPoint.direction);
        if (Char.ToLower(steps[i]) == 'f')
        {
            switch (StartPoint.direction)
            {
                case Direction.North:
                    StartPoint.y++;
                    break;
                case Direction.East:
                    StartPoint.x++;
                    break;
                case Direction.South:
                    StartPoint.y--;
                    break;
                default:
                    StartPoint.x--;
                    break;
            }
        }
    }
}

static Direction changeDirection(char c, Direction d)
{
    if (Char.ToLower(c) == 'f')
    {
        return d;
    }
    if (Char.ToLower(c) == 'r')
    {
        d++;
    }
    if (Char.ToLower(c) == 'l')
    {
        d--;
    }

    if ((int)d < 0)
    {
        d = Direction.West;
    }
    if ((int)d > 3)
    {
        d = Direction.North;
    }

    return d;
}