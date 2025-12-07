namespace AdventOfCode25.Logic.Day7;

public class TachyonManifold
{
    public long DetermineTachyonManifoldSplitCount(string rawGridInput)
    {
        var grid = new char[0,0];
        var lines = rawGridInput.Split('\n');

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

        var splitSum = 0L;

        for (var l = 0; l < grid.GetLength(0); l++)
        {
            for (var c = 0; c < grid.GetLength(1); c++)
            {
                var cell = grid[l, c];

                switch (cell)
                {
                    case 'S':
                        grid[l+1, c] = '|';
                        break;
                    case '^':
                        grid[l, c - 1] = '|';
                        grid[l, c + 1] = '|';
                        break;
                    case '|':
                    case '.':
                        if (l > 0 && grid[l - 1, c] == '|')
                        {
                            grid[l, c] = '|';
                        }
                        break;
                    default:
                        throw new FormatException($"Unknown cell character: {cell}");
                }
            }

            for (var i = 0; i < grid.GetLength(1); i++)
            {
                if (grid[l, i] != '^') continue;

                if (grid[l - 1, i] == '|')
                {
                    splitSum++;
                }
            }
        }

        return splitSum;
    }

    public long DetermineTachyonManifoldTimelines(string rawGridInput)
    {
        var grid = new long[0,0];
        var lines = rawGridInput.Split('\n');

        for (var i = 0; i < lines.Length; i++)
        {
            var elements = lines[i].ToCharArray();
            if (i == 0)
            {
                grid = new long[lines.Length, elements.Length];
            }

            for (var n = 0; n < elements.Length; n++)
            {
                grid[i, n] = elements[n] switch
                {
                    'S' => 1,
                    '^' => -1,
                    '.' => 0,
                    _ => throw new ArgumentOutOfRangeException()
                };
            }
        }

        var timelines = 0L;
        var height = grid.GetLength(0);
        var width = grid.GetLength(1);

        for (var l = 1; l < height; l++)
        {
            for (var c = 0; c < width; c++)
            {
                var cell = grid[l, c];

                var cellAbove = grid[l - 1, c];
                switch (cell)
                {
                    case 0:
                        var splitterLeft = c - 1 > 0 && grid[l, c - 1] == -1;
                        var splitterRight = c + 1 < width && grid[l, c + 1] == -1;

                        if (!splitterLeft && !splitterRight && cellAbove > 0)
                        {
                            grid[l, c] = cellAbove;
                            continue;
                        }

                        if (splitterLeft && splitterRight)
                        {
                            grid[l, c] = cellAbove + grid[l - 1, c - 1] + grid[l - 1, c + 1];
                        }
                        else if (splitterLeft)
                        {
                            grid[l, c] = cellAbove + grid[l - 1, c - 1];
                        }
                        else if (splitterRight)
                        {
                            grid[l, c] = cellAbove + grid[l - 1, c + 1];
                        }

                        break;
                }
            }
        }

        // for (var i = 0; i < height; i++)
        // {
        //     for (var c = 0; c < width; c++)
        //     {
        //         if (grid[i, c] > 0)
        //         {
        //             Console.Write(grid[i, c]);
        //         }
        //
        //         if (grid[i, c] == 0)
        //         {
        //             Console.Write('.');
        //         }
        //
        //         if (grid[i, c] == -1)
        //         {
        //             Console.Write('^');
        //         }
        //         Console.Write(' ');
        //     }
        //     Console.Write('\n');
        // }

        for (var c = 0; c < width; c++)
        {
            timelines += grid[height - 1, c];
        }

        return timelines;
    }
}
