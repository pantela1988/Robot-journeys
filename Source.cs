
public class TransferPoint
{
    public int x { get; set; }
    public int y { get; set; }
    public char direction { get; set; }
}

class Source
{
    public TransferPoint? point1 { get; set; }
    public TransferPoint? point2 { get; set; }
    public string? commands { get; set; }
}