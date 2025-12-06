using AdventOfCode25.Logic.Day6;

namespace AdventOfCode25.Tests.Day6;

public class CephalopodCalculatorTests
{
    [Test]
    public void Calculates_Sum_Of_Problems_Correctly()
    {
        var input = "123 328  51 64 \n 45 64  387 23 \n  6 98  215 314\n*   +   *   +  ";

        var calculator = new CephalopodCalculator();

        var sum = calculator.CalculateSumOfProblems(input);

        Assert.That(sum, Is.EqualTo(4277556));
    }

    [Test]
    public void Calculates_Sum_Of_Problems_RTL_Correctly()
    {
        var input = "123 328  51 64 \n 45 64  387 23 \n  6 98  215 314\n*   +   *   +  ";

        var calculator = new CephalopodCalculator();

        var sum = calculator.CalculateSumOfProblemsRTL(input);

        Assert.That(sum, Is.EqualTo(3263827));
    }
}
