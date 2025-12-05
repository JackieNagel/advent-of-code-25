using AdventOfCode25.Logic.Day3;

namespace AdventOfCode25.Tests.Day3;

public class BatteryBankTests
{
    [TestCase("987654321111111", 98)]
    [TestCase("811111111111119", 89)]
    [TestCase("234234234234278", 78)]
    [TestCase("818181911112111", 92)]
    public void Will_Identify_Highest_Joltage(string batteryBank, int expectedJoltage)
    {
        var bank = new BatteryBank(batteryBank);

        var joltage = bank.IdentifyHighestJoltageRating();

        Assert.That(joltage, Is.EqualTo(expectedJoltage));
    }
}
