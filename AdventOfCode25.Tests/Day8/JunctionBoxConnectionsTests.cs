using AdventOfCode25.Logic.Day8;

namespace AdventOfCode25.Tests.Day8;

public class JunctionBoxConnectionsTests
{
    [Test]
    public void Identifies_Correct_Product_Given_Assumption()
    {
        var junctionBoxConnections = new JunctionBoxConnections("162,817,812\n57,618,57\n906,360,560\n592,479,940\n352,342,300\n466,668,158\n542,29,236\n431,825,988\n739,650,466\n52,470,668\n216,146,977\n819,987,18\n117,168,530\n805,96,715\n346,949,466\n970,615,88\n941,993,340\n862,61,35\n984,92,344\n425,690,689");

        Assert.That(junctionBoxConnections.GetProductOfLargestCircuits(3, 10), Is.EqualTo(40));
    }

    [Test]
    public void Identifies_Correct_X_Coordinate_Product_In_One_Circuit_Given_Assumption()
    {
        var junctionBoxConnections = new JunctionBoxConnections("162,817,812\n57,618,57\n906,360,560\n592,479,940\n352,342,300\n466,668,158\n542,29,236\n431,825,988\n739,650,466\n52,470,668\n216,146,977\n819,987,18\n117,168,530\n805,96,715\n346,949,466\n970,615,88\n941,993,340\n862,61,35\n984,92,344\n425,690,689");

        Assert.That(junctionBoxConnections.GetXCoordinateProductOfLargestCircuit(), Is.EqualTo(25272));
    }
}
