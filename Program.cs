using System.Text.Json;

try
{
    string fileName = "data.json";
    string jsonString = File.ReadAllText(fileName);
    List<Source>? source = JsonSerializer.Deserialize<List<Source>>(jsonString);

    if (source is not null)
    {
        foreach (var item in source)
        {
            Point StartPoint = new Point(item.point1!.x, item.point1!.y, item.point1!.direction);
            Point EndPoint = new Point(item.point2!.x, item.point2!.y, item.point2!.direction);
            
            Console.WriteLine($"({StartPoint.x},{StartPoint.y}) {StartPoint.Direction}");

            addSteps(item.commands, StartPoint);


            
            Console.WriteLine(checkRoute(StartPoint, EndPoint));
        }
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
        int x = StartPoint.x > 0 ? StartPoint.x : 0;
            int y = StartPoint.y > 0 ? StartPoint.y : 0;
            Console.WriteLine($"({x},{y}) {StartPoint.Direction}");
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