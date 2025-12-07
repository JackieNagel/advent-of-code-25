using AdventOfCode25.Logic.Day7;

namespace AdventOfCode25.Tests.Day7;

public class TachyonManifoldTests
{
    [Test]
    public void Will_Determine_Amount_Of_Splits_Given_Input()
    {
        var rawInput =
            ".......S.......\n...............\n.......^.......\n...............\n......^.^......\n...............\n.....^.^.^.....\n...............\n....^.^...^....\n...............\n...^.^...^.^...\n...............\n..^...^.....^..\n...............\n.^.^.^.^.^...^.\n...............";
        var tachyonManifold = new TachyonManifold();
        var splits = tachyonManifold.DetermineTachyonManifoldSplitCount(rawInput);

        Assert.That(splits, Is.EqualTo(21));
    }

    [Test] public void Will_Determine_Amount_Of_Timelines_Given_Input()
    {
        var rawInput =
            ".......S.......\n...............\n.......^.......\n...............\n......^.^......\n...............\n.....^.^.^.....\n...............\n....^.^...^....\n...............\n...^.^...^.^...\n...............\n..^...^.....^..\n...............\n.^.^.^.^.^...^.\n...............";
        var tachyonManifold = new TachyonManifold();
        var timelines = tachyonManifold.DetermineTachyonManifoldTimelines(rawInput);

        Assert.That(timelines, Is.EqualTo(40));
    }
}
