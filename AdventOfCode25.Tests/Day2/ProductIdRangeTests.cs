using AdventOfCode25.Logic.Day2;

namespace AdventOfCode25.Tests.Day2;

public class ProductIdRangeTests
{
    [TestCase("11-22", 11, 22)]
    [TestCase("1698522-1698528", 1698522, 1698528)]
    public void Product_Id_Range_Parses_Start_And_End(string rawProductIdRange, int start, int end)
    {
        var productIdRange = new ProductIdRange(rawProductIdRange);

        Assert.That(productIdRange.Start, Is.EqualTo(start));
        Assert.That(productIdRange.End, Is.EqualTo(end));
    }
}
