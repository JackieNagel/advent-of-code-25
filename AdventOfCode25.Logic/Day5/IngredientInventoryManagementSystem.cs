namespace AdventOfCode25.Logic.Day5;

public class IngredientInventoryManagementSystem
{
    private readonly List<(long Start, long End)> _freshIngredientRanges = [];
    private readonly long[] _ingredientIds;

    public IngredientInventoryManagementSystem(string database)
    {
        var split = database.Split("\n\n");
        var rawRanges = split[0].Split('\n');

        foreach (var rawRange in rawRanges)
        {
            var splitRange = rawRange.Split('-');
            _freshIngredientRanges.Add((long.Parse(splitRange[0]), long.Parse(splitRange[1])));
        }

        _ingredientIds = split[1].Split('\n').Where(x => x != "").Select(long.Parse).ToArray();
    }

    public int DetermineFreshIngredientCount()
    {
        var freshIngredientCount = 0;

        foreach (var ingredientId in _ingredientIds)
        {
            foreach (var freshIngredientRange in _freshIngredientRanges)
            {
                if (ingredientId >= freshIngredientRange.Start && ingredientId <= freshIngredientRange.End)
                {
                    freshIngredientCount++;
                    break;
                }
            }
        }

        return freshIngredientCount;
    }

    public long DetermineFreshIngredientCountInRanges()
    {
        _freshIngredientRanges.Sort((a, b) => a.Start.CompareTo(b.Start));

        var merged = new List<(long Start, long End)>();
        var current = _freshIngredientRanges[0];

        foreach (var range in _freshIngredientRanges.Skip(1))
        {
            if (range.Start <= current.End)
            {
                current.End = Math.Max(current.End, range.End);
            }
            else
            {
                merged.Add(current);
                current = range;
            }
        }

        merged.Add(current);

        return merged.Sum(range => range.End - range.Start + 1);;
    }
}
