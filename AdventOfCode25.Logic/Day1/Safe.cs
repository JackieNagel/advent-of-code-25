namespace AdventOfCode25.Logic.Day1;

public class Safe
{
    private int CurrentDialPosition { get; set; } = 50;

    public (int currentDialPosition, int rotatedAcrossZeroCount) MoveDial(string instruction)
    {
        var parsed = new Instruction(instruction);
        var passedAcrossZeroCount = 0;

        for (var i = 0; i < parsed.Clicks; i++)
        {
            switch (parsed.Direction)
            {
                case Direction.Left:
                    CurrentDialPosition--;
                    break;
                case Direction.Right:
                    CurrentDialPosition++;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (CurrentDialPosition is 0 or > 99) passedAcrossZeroCount++;
            if (CurrentDialPosition < 0) CurrentDialPosition = 99;
            if (CurrentDialPosition > 99) CurrentDialPosition = 0;
        }

        return (CurrentDialPosition, passedAcrossZeroCount);
    }

    public (int encounteredExactZeroes, int encounteredZeroesInRotations) ConductInstructionSequence(string[] instructions)
    {
        var encounteredExactZeroes = 0;
        var encounteredZeroesInRotations = 0;
        foreach (var instruction in instructions)
        {
            var result = MoveDial(instruction);
            if (result.currentDialPosition == 0) encounteredExactZeroes++;
            encounteredZeroesInRotations += result.rotatedAcrossZeroCount;
        }

        return (encounteredExactZeroes, encounteredZeroesInRotations);
    }
}
