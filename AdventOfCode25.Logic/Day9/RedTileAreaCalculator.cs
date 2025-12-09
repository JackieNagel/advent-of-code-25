namespace AdventOfCode25.Logic.Day9;

public class RedTileAreaCalculator
{
    private readonly List<Point> _points;

    public RedTileAreaCalculator(string redTileCoordinateInput)
    {
        _points = redTileCoordinateInput.Split('\n').Select(x =>
        {
            var split = x.Split(',');
            return new Point(long.Parse(split[0]), long.Parse(split[1]));
        }).ToList();
    }

    public long CalculateLargestRedTileArea()
    {
        var largestRedTileArea = 0L;

        for (var i = 0; i < _points.Count; i++)
        {
            var from = _points[i];
            for (var n = i + 1; n < _points.Count; n++)
            {
                var to = _points[n];
                var area = from.RectangleArea(to);
                if (area > largestRedTileArea)
                {
                    largestRedTileArea = area;
                }
            }
        }

        return largestRedTileArea;
    }

    public long CalculateLargestRedAndGreenTileArea()
    {
        var lines = new Line[_points.Count + 1];
        for (var i = 0; i < _points.Count - 1; i++)
        {
            lines[i] = new Line(_points[i], _points[i + 1]);
        }
        lines[^1] = new Line(_points[^1], _points[0]);

        var largestRedGreenTileArea = 0L;

        for (var i = 0; i < _points.Count - 1; i++)
        {
            var from = _points[i];
            for (var j = i + 1; j < _points.Count; j++)
            {
                var to = _points[j];
                var area = from.RectangleArea(to);

                if (largestRedGreenTileArea >= area )
                {
                    continue;
                }

                if (!lines.Any(line => line.Intersects(from, to)))
                {
                    largestRedGreenTileArea = area;
                }
            }
        }

        return largestRedGreenTileArea;
    }

    private readonly record struct Point(long X, long Y)
    {
        public long RectangleArea(Point other)
        {
            return (Math.Abs(other.X - X) + 1) * (Math.Abs(other.Y - Y) + 1);
        }
    }

    private readonly record struct Line(Point Start, Point End)
    {
        public bool Intersects(Point pointA, Point pointB)
        {
            var minX = Math.Min(pointA.X, pointB.X);
            var maxX = Math.Max(pointA.X, pointB.X);
            var minY = Math.Min(pointA.Y, pointB.Y);
            var maxY = Math.Max(pointA.Y, pointB.Y);

            var segMinX = Math.Min(Start.X, End.X);
            var segMaxX = Math.Max(Start.X, End.X);
            var segMinY = Math.Min(Start.Y, End.Y);
            var segMaxY = Math.Max(Start.Y, End.Y);

            return segMaxX > minX && segMinX < maxX && segMaxY > minY && segMinY < maxY;
        }
    }
}
