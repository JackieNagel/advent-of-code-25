namespace AdventOfCode25.Logic.Day8;

public class JunctionBoxConnections
{
    private readonly List<JunctionBox> _junctionBoxes;

    public JunctionBoxConnections(string rawInput)
    {
        var split = rawInput.Split('\n');
        _junctionBoxes = split.Select(x =>
        {
            var iSplit = x.Split(',');
            return new JunctionBox(long.Parse(iSplit[0]), long.Parse(iSplit[1]), long.Parse(iSplit[2]));
        }).ToList();
    }

    private List<(JunctionBox From, JunctionBox To, double Distance)> GetOrderedDistances()
    {
        var distances = new List<(JunctionBox From, JunctionBox To, double Distance)>();

        for (var i = 0; i < _junctionBoxes.Count; i++)
        {
            var from = _junctionBoxes[i];
            for (var n = i + 1; n < _junctionBoxes.Count; n++)
            {
                var to = _junctionBoxes[n];
                distances.Add((from, to, from.DistanceTo(to)));
            }
        }

        return distances.OrderBy(x => x.Distance).ToList();
    }

    public long GetProductOfLargestCircuits(int amount, int targetCircuitAmount)
    {
        var orderedByDistances = GetOrderedDistances();

        var circuits = _junctionBoxes.Select(junctionBox => (HashSet<JunctionBox>)[junctionBox]).ToList();

        var iteration = 0;
        while (true)
        {
            iteration++;

            var (from, to, _) = orderedByDistances[iteration - 1];
            var circuitA = circuits.First(c => c.Contains(from));
            var circuitB = circuits.First(c => c.Contains(to));

            if (circuitA != circuitB)
            {
                circuitA.UnionWith(circuitB);
                circuits.Remove(circuitB);
                circuits = [.. circuits.OrderByDescending(c => c.Count)];
            }

            if (iteration == targetCircuitAmount)
            {
                break;
            }
        }

        return circuits.OrderByDescending(x => x.Count)
            .Take(amount)
            .Aggregate(1L, (acc, x) => acc * x.Count);
    }

    public long GetXCoordinateProductOfLargestCircuit()
    {
        var orderedByDistances = GetOrderedDistances();

        var circuits = _junctionBoxes.Select(junctionBox => (HashSet<JunctionBox>)[junctionBox]).ToList();

        var iteration = 0;
        while (true)
        {
            iteration++;

            var (from, to, _) = orderedByDistances[iteration - 1];
            var circuitA = circuits.First(c => c.Contains(from));
            var circuitB = circuits.First(c => c.Contains(to));

            if (circuitA != circuitB)
            {
                circuitA.UnionWith(circuitB);
                circuits.Remove(circuitB);
                circuits = [.. circuits.OrderByDescending(c => c.Count)];
            }

            if (circuits.Count == 1)
            {
                return from.X * to.X;
            }
        }
    }

    private class JunctionBox(long x, long y, long z)
    {
        public long X { get; } = x;
        public long Y { get; } = y;
        public long Z { get; } = z;

        public double DistanceTo(JunctionBox other)
        {
            double dx = other.X - X;
            double dy = other.Y - Y;
            double dz = other.Z - Z;

            return Math.Sqrt(dx * dx + dy * dy + dz * dz);
        }

        public override bool Equals(object? obj)
        {
            if (obj is JunctionBox other)
            {
                return ToString() == other.ToString();
            }

            return false;
        }

        public override string ToString()
        {
            return $"{X},{Y},{Z}";
        }
    }
}
