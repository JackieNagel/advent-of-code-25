namespace AdventOfCode25.Logic.Day2;

public class ProductIdRange
{
    public long Start { get; set; }
    public long End { get; set; }

    public ProductIdRange(string rawProductIdRange)
    {
        var split = rawProductIdRange.Split('-');
        Start = long.Parse(split[0]);
        End = long.Parse(split[1]);
    }
}
