namespace AdventOfCode25.Logic.Day2;

public class InvalidProductIdFinder
{
    public List<long> FindInvalidProductIds(ProductIdRange range)
    {
        var invalidProductIds = new List<long>();

        for (var productId = range.Start; productId <= range.End; productId++)
        {
            var stringed = productId.ToString();
            var halfPoint = stringed.Length / 2;
            var prior = stringed.Substring(0, halfPoint);
            var latter = stringed.Substring(halfPoint, stringed.Length - halfPoint);

            if (prior == latter) invalidProductIds.Add(productId);
        }

        return invalidProductIds;
    }
}
