using AdventOfCode25.Logic.Day9;

namespace AdventOfCode25.Tests.Day9;

public class RedTileAreaCalculatorTests
{
    [Test]
    public void Calculate_Largest_Red_Tile_Area_With_Exemplified_Input()
    {
        var redTileAreaCalculator = new RedTileAreaCalculator("7,1\n11,1\n11,7\n9,7\n9,5\n2,5\n2,3\n7,3");
        Assert.That(redTileAreaCalculator.CalculateLargestRedTileArea(), Is.EqualTo(50));
    }

    [Test]
    public void Calculate_Largest_Red_And_Green_Tile_Area_With_Exemplified_Input()
    {
        var redTileAreaCalculator = new RedTileAreaCalculator("7,1\n11,1\n11,7\n9,7\n9,5\n2,5\n2,3\n7,3");
        Assert.That(redTileAreaCalculator.CalculateLargestRedAndGreenTileArea(), Is.EqualTo(24));
    }
}
