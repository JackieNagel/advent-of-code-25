using AdventOfCode25.Logic.Day4;

namespace AdventOfCode25.Tests.Day4;

public class ForkliftPaperRollFinderTests
{
    [Test]
    public void Correctly_Identifies_Number_Of_Accessible_Paper_Rolls()
    {
        var forkliftPaperRollFinder = new ForkliftPaperRollFinder(
            "..@@.@@@@.\n@@@.@.@.@@\n@@@@@.@.@@\n@.@@@@..@.\n@@.@@@@.@@\n.@@@@@@@.@\n.@.@.@.@@@\n@.@@@.@@@@\n.@@@@@@@@.\n@.@.@@@.@."
        );

        var accessiblePaperRolls = forkliftPaperRollFinder.IdentifyNumberOfAccessiblePaperRolls();

        Assert.That(accessiblePaperRolls, Is.EqualTo(13));
    }

    [Test]
    public void Correctly_Identifies_Number_Of_Accessible_Paper_Rolls_In_Iterations()
    {
        var forkliftPaperRollFinder = new ForkliftPaperRollFinder(
            "..@@.@@@@.\n@@@.@.@.@@\n@@@@@.@.@@\n@.@@@@..@.\n@@.@@@@.@@\n.@@@@@@@.@\n.@.@.@.@@@\n@.@@@.@@@@\n.@@@@@@@@.\n@.@.@@@.@."
        );

        var accessiblePaperRolls = forkliftPaperRollFinder.IdentifyNumberOfAccessiblePaperRollsInIterations();

        Assert.That(accessiblePaperRolls, Is.EqualTo(43));
    }
}
