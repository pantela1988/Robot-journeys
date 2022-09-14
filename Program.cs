using System.Text.Json;

try
{
    string fileName = "data.json";
    string jsonString = File.ReadAllText(fileName);
    Source? source = JsonSerializer.Deserialize<Source>(jsonString);

    if (source is not null)
    {

        Point StartPoint = new Point(source.point1!.x, source.point1!.y, source.point1!.direction);
        Point EndPoint = new Point(source.point2!.x, source.point2!.y, source.point2!.direction);

        addSteps(source.commands, StartPoint);


        Console.WriteLine(StartPoint.x + " " + StartPoint.y + " " + StartPoint.Direction);
        Console.WriteLine(EndPoint.x + " " + EndPoint.y + " " + EndPoint.Direction);
        Console.WriteLine(checkRoute(StartPoint, EndPoint));
    }

}
catch (CustomException ex)
{
    Console.WriteLine(ex.Message);
}


bool checkRoute(Point Start, Point End)
{
    return Start.x == End.x && Start.y == End.y && Start.Direction == End.Direction;
}

void addSteps(string? steps, Point StartPoint)
{

    for (int i = 0; i < steps!.Length; i++)
    {
        StartPoint.Direction = changeDirection(steps[i], StartPoint.Direction);
        if (Char.ToLower(steps[i]) == 'f')
        {
            switch (StartPoint.Direction)
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