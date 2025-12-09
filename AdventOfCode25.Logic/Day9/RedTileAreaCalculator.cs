namespace AdventOfCode25.Logic.Day9;

public class RedTileAreaCalculator
{
    private readonly List<(long X, long Y)> _redTileCoordinates;


    public RedTileAreaCalculator(string redTileCoordinateInput)
    {
        _redTileCoordinates = redTileCoordinateInput.Split('\n').Select(x =>
        {
            var split = x.Split(',');
            return (long.Parse(split[0]), long.Parse(split[1]));
        }).ToList();
    }

    public long CalculateLargestRedTileArea()
    {
        var largestRedTileArea = 0L;

        for (var i = 0; i < _redTileCoordinates.Count; i++)
        {
            var from = _redTileCoordinates[i];
            for (var n = i + 1; n < _redTileCoordinates.Count; n++)
            {
                var to = _redTileCoordinates[n];
                var area = CalculateRedTileArea(from, to);
                if (area > largestRedTileArea)
                {
                    largestRedTileArea = area;
                }
            }
        }

        return largestRedTileArea;
    }

    public long CalculateRedTileArea((long X, long Y) c1, (long X, long Y) c2)
    {
        return (Math.Abs(c2.X - c1.X) + 1) * (Math.Abs(c2.Y - c1.Y) + 1);
    }
}
