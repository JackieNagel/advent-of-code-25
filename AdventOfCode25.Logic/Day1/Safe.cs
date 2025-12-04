namespace AdventOfCode25.Logic.Day1;

public class Safe
{
    private int CurrentDialPosition { get; set; } = 50;

    public int MoveDial(string instruction)
    {
        var parsed = new Instruction(instruction);

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

            if (CurrentDialPosition < 0) CurrentDialPosition = 99;
            if (CurrentDialPosition > 99) CurrentDialPosition = 0;
        }

        return CurrentDialPosition;
    }

    public int ConductInstructionSequence(string[] instructions)
    {
        var encounteredZeroes = 0;
        foreach (var instruction in instructions)
        {
            var currentDialPosition = MoveDial(instruction);
            if (currentDialPosition == 0) encounteredZeroes++;
        }

        return encounteredZeroes;
    }
}
