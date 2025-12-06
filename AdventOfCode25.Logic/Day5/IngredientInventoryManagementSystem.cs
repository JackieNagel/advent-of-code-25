namespace AdventOfCode25.Logic.Day5;

public class IngredientInventoryManagementSystem
{
    private record FreshIngredientRange(long Lower, long Upper);
    private readonly List<FreshIngredientRange> _freshIngredientRanges = [];
    private readonly long[] _ingredientIds;

    public IngredientInventoryManagementSystem(string database)
    {
        var split = database.Split("\n\n");
        var rawRanges = split[0].Split('\n');

        foreach (var rawRange in rawRanges)
        {
            var splitRange = rawRange.Split('-');
            var range = new FreshIngredientRange(long.Parse(splitRange[0]), long.Parse(splitRange[1]));
            _freshIngredientRanges.Add(range);
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
                if (ingredientId >= freshIngredientRange.Lower && ingredientId <= freshIngredientRange.Upper)
                {
                    freshIngredientCount++;
                    break;
                }
            }
        }

        return freshIngredientCount;
    }
}
