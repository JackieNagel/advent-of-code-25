namespace AdventOfCode25.Logic.Day6;

public class CephalopodCalculator
{
    public long CalculateSumOfProblems(string rawInput)
    {
        long sum = 0;
        var grid = new string[0,0];
        var lines = rawInput.Split('\n').Where(x => x != "").ToArray();

        for (var i = 0; i < lines.Length; i++)
        {
            var elements = lines[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (i == 0)
            {
                 grid = new string[lines.Length, elements.Length];
            }

            for (var n = 0; n < elements.Length; n++)
            {
                grid[i, n] = elements[n];
            }
        }

        for (var i = 0; i < grid.GetLength(1); i++)
        {
            var terms = new int[lines.Length - 1];
            for (var n = 0; n < lines.Length - 1; n++)
            {
                terms[n] = int.Parse(grid[n, i]);
            }

            var @operator = grid[lines.Length - 1, i];

            var aggregate = @operator switch
            {
                "*" => terms.Aggregate(1L, (acc, x) => acc * x),
                "+" => terms.Sum(),
                _ => throw new FormatException($"{@operator} is not a supported operator")
            };

            sum += aggregate;
        }

        return sum;
    }

    public long CalculateSumOfProblemsRTL(string rawInput)
    {
        long sum = 0;
        var grid = new char[0,0];
        var lines = rawInput.Split('\n').Where(x => x != "").ToArray();

        for (var i = 0; i < lines.Length; i++)
        {
            var elements = lines[i].ToCharArray();
            if (i == 0)
            {
                grid = new char[lines.Length, elements.Length];
            }

            for (var n = 0; n < elements.Length; n++)
            {
                grid[i, n] = elements[n];
            }
        }

        var terms = new List<int>();
        for (var i = grid.GetLength(1) - 1; i >= 0; i--)
        {
            var termChars = new char[lines.Length - 1];
            for (var n = 0; n < lines.Length - 1; n++)
            {
                termChars[n] = grid[n,i];
            }

            terms.Add(int.Parse(termChars));

            var @operator = grid[lines.Length - 1, i];
            if (@operator == ' ') continue;

            var aggregate = @operator switch
            {
                '*' => terms.Aggregate(1L, (acc, x) => acc * x),
                '+' => terms.Sum(),
                _ => throw new FormatException($"{@operator} is not a supported operator")
            };

            terms.Clear();
            i--;

            sum += aggregate;
        }

        return sum;
    }
}
