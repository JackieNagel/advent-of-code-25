using AdventOfCode25.Logic.Day5;

namespace AdventOfCode25.Tests.Day5;

public class IngredientInventoryManagementSystemTests
{
    [Test]
    public void Correctly_Identifies_Count_Of_Fresh_Ingredients()
    {
        var ingredientInventoryManagementSystem = new IngredientInventoryManagementSystem("3-5\n10-14\n16-20\n12-18\n\n1\n5\n8\n11\n17\n32");
        var freshIngredientCount = ingredientInventoryManagementSystem.DetermineFreshIngredientCount();

        Assert.That(freshIngredientCount, Is.EqualTo(3));
    }

    [Test]
    public void Correctly_Identifies_Count_Of_Fresh_Ingredients_In_Ranges()
    {
        var ingredientInventoryManagementSystem = new IngredientInventoryManagementSystem("3-5\n10-14\n16-20\n12-18\n\n1\n5\n8\n11\n17\n32");
        var freshIngredientCount = ingredientInventoryManagementSystem.DetermineFreshIngredientCountInRanges();

        Assert.That(freshIngredientCount, Is.EqualTo(14));
    }
}
