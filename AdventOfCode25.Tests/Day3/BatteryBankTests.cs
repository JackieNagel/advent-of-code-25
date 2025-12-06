using AdventOfCode25.Logic.Day3;

namespace AdventOfCode25.Tests.Day3;

public class BatteryBankTests
{
    [TestCase("987654321111111", 98)]
    [TestCase("811111111111119", 89)]
    [TestCase("234234234234278", 78)]
    [TestCase("818181911112111", 92)]
    public void Will_Identify_Highest_Joltage_With_Two_Joltages(string batteryBank, int expectedJoltage)
    {
        var bank = new BatteryBank(batteryBank);

        var joltage = bank.IdentifyHighestJoltageRating(numberOfJoltages: 2);

        Assert.That(joltage, Is.EqualTo(expectedJoltage));
    }

    [TestCase("987654321111111", 987654321111)]
    [TestCase("811111111111119", 811111111119)]
    [TestCase("234234234234278", 434234234278)]
    [TestCase("818181911112111", 888911112111)]
    public void Will_Identify_Highest_Joltage_With_Twelve_Joltages(string batteryBank, long expectedJoltage)
    {
        var bank = new BatteryBank(batteryBank);

        var joltage = bank.IdentifyHighestJoltageRating(numberOfJoltages: 12);

        Assert.That(joltage, Is.EqualTo(expectedJoltage));
    }
}
