namespace AdventOfCode25.Logic.Day1;

public enum Direction
{
    Left,
    Right,
}

public class Instruction(string instruction)
{
    public Direction Direction { get; } = instruction[0] switch
    {
        'L' => Direction.Left,
        'R' => Direction.Right,
        _ => throw new ArgumentOutOfRangeException()
    };

    public int Clicks { get; } = int.Parse(instruction.Substring(1));
}
