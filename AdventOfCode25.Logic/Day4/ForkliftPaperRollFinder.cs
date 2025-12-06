namespace AdventOfCode25.Logic.Day4;

public class ForkliftPaperRollFinder
{
    private readonly bool[,] _grid;
    private readonly int _lineLength;
    private readonly int _lines;

    public ForkliftPaperRollFinder(string rawGrid)
    {
        var split = rawGrid.Split('\n');
        _lineLength = split[0].Length;
        _lines = split.Length;
        _grid = new bool[_lines, _lineLength];

        for (var i = 0; i < split.Length; i++)
        {
            var line = split[i].ToArray();

            for (var n = 0; n < line.Length; n++)
            {
                _grid[i, n] = line[n] == '@';
            }
        }
    }

    public int IdentifyNumberOfAccessiblePaperRolls()
    {
        var adjacentPaperRollLimit = 4;
        var accessiblePaperRolls = 0;

        for (var l = 0; l < _lines; l++)
        {
            for (var c = 0; c < _lineLength; c++)
            {
                if (!_grid[l, c]) continue; // skip cells that doesn't hold a paper roll

                if (GetAmoutOfAdjacentPaperRolls(l, c) < adjacentPaperRollLimit)
                {
                    accessiblePaperRolls++;
                }
            }
        }

        return accessiblePaperRolls;
    }

    public int IdentifyNumberOfAccessiblePaperRollsInIterations()
    {
        var adjacentPaperRollLimit = 4;
        var accessiblePaperRolls = 0;

        while (true)
        {
            var toRemove = new List<Tuple<int, int>>();

            for (var l = 0; l < _lines; l++)
            {
                for (var c = 0; c < _lineLength; c++)
                {
                    if (!_grid[l, c]) continue; // skip cells that doesn't hold a paper roll

                    if (GetAmoutOfAdjacentPaperRolls(l, c) < adjacentPaperRollLimit)
                    {
                        accessiblePaperRolls++;
                        toRemove.Add(new Tuple<int, int>(l, c));
                    }
                }
            }

            if (toRemove.Count == 0) break;

            foreach (var tuple in toRemove)
            {
                _grid[tuple.Item1, tuple.Item2] = false;
            }
        }

        return accessiblePaperRolls;
    }

    private int GetAmoutOfAdjacentPaperRolls(int line, int column)
    {
        var adjacentPaperRolls = 0;

        if (line - 1 >= 0) //line above
        {
            if (column - 1 >= 0 && _grid[line - 1, column - 1]) //above left
            {
                adjacentPaperRolls++;
            }

            if (_grid[line - 1, column]) //above
            {
                adjacentPaperRolls++;
            }

            if (column + 1 < _lineLength && _grid[line - 1, column + 1]) //above right
            {
                adjacentPaperRolls++;
            }
        }

        if (column - 1 >= 0 && _grid[line, column - 1]) //left
        {
            adjacentPaperRolls++;
        }

        if (column + 1 < _lineLength && _grid[line, column + 1]) //right
        {
            adjacentPaperRolls++;
        }

        if (line + 1 < _lines) // below
        {
            if (column - 1 >= 0 && _grid[line + 1, column - 1]) //below left
            {
                adjacentPaperRolls++;
            }

            if (_grid[line + 1, column]) //below
            {
                adjacentPaperRolls++;
            }

            if (column + 1 < _lineLength && _grid[line + 1, column + 1]) //below right
            {
                adjacentPaperRolls++;
            }
        }

        return adjacentPaperRolls;
    }
}
