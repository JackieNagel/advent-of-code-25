using AdventOfCode25.Logic.Day7;

namespace AdventOfCode25.Tests.Day7;

public class TachyonManifoldTests
{
    [Test]
    public void Will_Determine_Amount_Of_Splits_Given_Input()
    {
        var tachyonManifold = new TachyonManifold(".......S.......\n...............\n.......^.......\n...............\n......^.^......\n...............\n.....^.^.^.....\n...............\n....^.^...^....\n...............\n...^.^...^.^...\n...............\n..^...^.....^..\n...............\n.^.^.^.^.^...^.\n...............");
        var splits = tachyonManifold.DetermineTachyonManifoldSplitCount();

        Assert.That(splits, Is.EqualTo(21));
    }
}
