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

    public List<long> FindInvalidProductIdsExtended(ProductIdRange range)
    {
        var invalidProductIds = new List<long>();

        for (var productId = range.Start; productId <= range.End; productId++)
        {
            var stringed = productId.ToString();
            var halfPoint = stringed.Length / 2;

            for (var i = 1; i <= halfPoint; i++)
            {
                var comparer = stringed.Substring(0, i);
                var rest = stringed.Substring(i, stringed.Length - i);
                var chopped = new List<string>();

                for (var n = 0; n < rest.Length; n += i)
                {
                    chopped.Add(rest.Substring(n, Math.Min(i, rest.Length - n)));
                }

                if (chopped.Any() && chopped.All(x => x == comparer))
                {
                    invalidProductIds.Add(productId);
                    break;
                }
            }
        }

        return invalidProductIds;
    }
}
