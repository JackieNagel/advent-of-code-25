namespace AdventOfCode25.Logic.Day3;

public class BatteryBank
{
    private readonly string _batteryJoltageRatings;

    public BatteryBank(string batteryJoltageRatings)
    {
        _batteryJoltageRatings = batteryJoltageRatings;
    }

    public int IdentifyHighestJoltageRating()
    {
        var split = _batteryJoltageRatings.Select(joltageRating => (int)Char.GetNumericValue(joltageRating)).ToArray();

        var firstJoltage = 0;
        var firstIndex = -1;

        var firstEvaluation = split[..^1];
        for (var i = 0; i < firstEvaluation.Length; i++)
        {
            if (firstEvaluation[i] > firstJoltage)
            {
                firstJoltage = firstEvaluation[i];
                firstIndex = i;
            }
        }

        var secondJoltage = split[(firstIndex + 1)..].Max();

        return int.Parse($"{firstJoltage}{secondJoltage}");
    }
}
