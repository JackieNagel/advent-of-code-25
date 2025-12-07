namespace AdventOfCode25.Logic.Day7;

public class TachyonManifold
{
    private readonly char[,] _grid;

    public TachyonManifold(string rawGridInput)
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

        _grid = grid;
    }

    public long DetermineTachyonManifoldSplitCount()
    {
        var splitSum = 0L;

        for (var l = 0; l < _grid.GetLength(0); l++)
        {
            for (var c = 0; c < _grid.GetLength(1); c++)
            {
                var cell = _grid[l, c];

                switch (cell)
                {
                    case 'S':
                        _grid[l+1, c] = '|';
                        break;
                    case '^':
                        _grid[l, c - 1] = '|';
                        _grid[l, c + 1] = '|';
                        break;
                    case '|':
                    case '.':
                        if (l > 0 && _grid[l - 1, c] == '|')
                        {
                            _grid[l, c] = '|';
                        }
                        break;
                    default:
                        throw new FormatException($"Unknown cell character: {cell}");
                }
            }

            for (var i = 0; i < _grid.GetLength(1); i++)
            {
                if (_grid[l, i] != '^') continue;

                if (_grid[l - 1, i] == '|')
                {
                    splitSum++;
                }
            }
        }

        return splitSum;
    }
}
