using AdventOfCode25.Logic.Day2;

namespace AdventOfCode25.Tests.Day2;

public class InvalidProductIdFinderTests
{
    [TestCase("11-22", new long[] { 11, 22 })]
    [TestCase("95-115", new long[] { 99 })]
    [TestCase("998-1012", new long[] { 1010 })]
    [TestCase("1188511880-1188511890", new long[] { 1188511885 })]
    [TestCase("222220-222224", new long[] { 222222 })]
    [TestCase("1698522-1698528", new long[0])]
    [TestCase("446443-446449", new long[] { 446446 })]
    [TestCase("38593856-38593862", new long[] { 38593859 })]
    public void Product_Id_Range_Parses_Start_And_End(string rawProductIdRange, long[] invalidProductIds)
    {
        var productIdRange = new ProductIdRange(rawProductIdRange);

        var finder = new InvalidProductIdFinder();
        var result = finder.FindInvalidProductIds(productIdRange);

        Assert.That(result, Is.EquivalentTo(invalidProductIds));
    }

    [Test]
    public void Sum_Of_Product_Ids_Adds_Up()
    {
        var rawProductIdInput =
            "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124";
        var ranges = rawProductIdInput.Split(',');
        var finder = new InvalidProductIdFinder();
        var aggregatedResults = new List<long>();

        foreach (var range in ranges)
        {
            var productIdRange = new ProductIdRange(range);
            var result = finder.FindInvalidProductIds(productIdRange);
            aggregatedResults.AddRange(result);
        }

        Assert.That(aggregatedResults.Sum(), Is.EqualTo(1227775554));
    }
}
