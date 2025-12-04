using AdventOfCode25.Logic.Day1;

namespace AdventOfCode25.Tests.Day1;

public class InstructionTests
{
    [TestCase("L1", Direction.Left, 1)]
    [TestCase("L100", Direction.Left, 100)]
    [TestCase("L1000", Direction.Left, 1000)]
    [TestCase("R1", Direction.Right, 1)]
    [TestCase("R100", Direction.Right, 100)]
    [TestCase("R1000", Direction.Right, 1000)]
    public void Instruction_Parses(string instruction, Direction expectedDirection,  int clicks)
    {
        var parsed = new Instruction(instruction);

        Assert.That(parsed.Direction, Is.EqualTo(expectedDirection));
        Assert.That(parsed.Clicks, Is.EqualTo(clicks));
    }
}
