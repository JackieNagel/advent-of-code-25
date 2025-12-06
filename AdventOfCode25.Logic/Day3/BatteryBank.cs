namespace AdventOfCode25.Logic.Day3;

public class BatteryBank
{
    private readonly string _batteryJoltageRatings;

    public BatteryBank(string batteryJoltageRatings)
    {
        _batteryJoltageRatings = batteryJoltageRatings;
    }

    public long IdentifyHighestJoltageRating(int numberOfJoltages)
    {
        var split = _batteryJoltageRatings.Select(joltage => (int)char.GetNumericValue(joltage)).ToArray();
        var enabledJoltages = new List<int>(numberOfJoltages);

        var previousJoltageIndex = -1;
        for (var i = numberOfJoltages - 1; i >= 0; i--)
        {
            var lowerOffset = previousJoltageIndex + 1;

            var toEvaluate = split[lowerOffset..^i];
            var highestJoltage = -1;
            var highestJoltageIndex = -1;

            for (var n = 0; n < toEvaluate.Length; n++)
            {
                if (toEvaluate[n] <= highestJoltage) continue;

                highestJoltage = toEvaluate[n];
                highestJoltageIndex = n;
            }

            previousJoltageIndex =  lowerOffset + highestJoltageIndex;
            enabledJoltages.Add(highestJoltage);
        }

        return long.Parse(string.Join("", enabledJoltages));;
    }
}
