using AdventOfCode25.Logic.Day1;

namespace AdventOfCode25.Tests.Day1;

public class SafeTests
{
    [TestCase("L1", 49)]
    [TestCase("L51", 99)]
    [TestCase("R1", 51)]
    [TestCase("R50", 0)]
    public void Dial_Moves_As_Expected(string instruction, int expected)
    {
        var safe = new Safe();
        var result = safe.MoveDial(instruction);

        Assert.That(result.currentDialPosition, Is.EqualTo(expected));
    }

    [Test]
    public void Sequences_Correctly_When_Dialed()
    {
        var safe = new Safe();
        var instructions = new []
        {
            "L68",
            "L30",
            "R48",
            "L5",
            "R60",
            "L55",
            "L1",
            "L99",
            "R14",
            "L82"
        };

        var result = safe.ConductInstructionSequence(instructions);

        Assert.That(result.encounteredExactZeroes, Is.EqualTo(3));
    }
}
