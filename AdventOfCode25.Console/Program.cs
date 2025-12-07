// See https://aka.ms/new-console-template for more information

using AdventOfCode25.Logic.Day1;
using AdventOfCode25.Logic.Day2;
using AdventOfCode25.Logic.Day3;
using AdventOfCode25.Logic.Day4;
using AdventOfCode25.Logic.Day5;
using AdventOfCode25.Logic.Day6;
using AdventOfCode25.Logic.Day7;

var homeDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
var filePath = Path.Combine(homeDirectory, "projects/advent-of-code-25/AdventOfCode25.Console/Assets");

// Day 1
// var lines = await File.ReadAllLinesAsync(Path.Combine(filePath, "day1_puzzle_input.txt"));
// var safe = new Safe();
// var result = safe.ConductInstructionSequence(lines);
//
// Console.WriteLine($"Conducted sequence. Result: exact zeroes: {result}");
// Console.WriteLine($"\texact zeroes: {result.encounteredExactZeroes}");
// Console.WriteLine($"\tencountered zeroes in rotations: {result.encounteredZeroesInRotations}");

// Day 2
// var rawProductIdInput = await File.ReadAllTextAsync(Path.Combine(filePath, "day2_puzzle_input.txt"));
// var ranges = rawProductIdInput.Split(',');
// var finder = new InvalidProductIdFinder();
// var aggregatedResults = new List<long>();
//
// foreach (var range in ranges)
// {
//     var productIdRange = new ProductIdRange(range);
//     var result = finder.FindInvalidProductIds(productIdRange);
//     aggregatedResults.AddRange(result);
// }
//
// Console.WriteLine($"Sum of invalid product IDs: {aggregatedResults.Sum()}");

// Day 2, part 2
// var rawProductIdInput = await File.ReadAllTextAsync(Path.Combine(filePath, "day2_puzzle_input.txt"));
// var ranges = rawProductIdInput.Split(',');
// var finder = new InvalidProductIdFinder();
// var aggregatedResults = new List<long>();
//
// foreach (var range in ranges)
// {
//     var productIdRange = new ProductIdRange(range);
//     var result = finder.FindInvalidProductIdsExtended(productIdRange);
//     aggregatedResults.AddRange(result);
// }
//
// Console.WriteLine($"Sum of invalid product IDs: {aggregatedResults.Sum()}");

// // Day 3
// var batteryBanks = await File.ReadAllLinesAsync(Path.Combine(filePath, "day3_puzzle_input.txt"));
// var sum = batteryBanks.Select(x => new BatteryBank(x).IdentifyHighestJoltageRating(numberOfJoltages: 2)).Sum();
//
// Console.WriteLine($"Total joltage rating: {sum}");

// Day 3, part 2
// var batteryBanks = await File.ReadAllLinesAsync(Path.Combine(filePath, "day3_puzzle_input.txt"));
// var sum = batteryBanks.Select(x => new BatteryBank(x).IdentifyHighestJoltageRating(numberOfJoltages: 12)).Sum();
//
// Console.WriteLine($"Total joltage rating: {sum}");

// Day 4
// var rawGrid = await File.ReadAllTextAsync(Path.Combine(filePath, "day4_puzzle_input.txt"));
// var forkliftPaperRollFinder = new ForkliftPaperRollFinder(rawGrid);
// var accessiblePaperRolls = forkliftPaperRollFinder.IdentifyNumberOfAccessiblePaperRolls();
//
// Console.WriteLine($"Accessible Paper Rolls: {accessiblePaperRolls}");

// Day 4, part 2
// var rawGrid = await File.ReadAllTextAsync(Path.Combine(filePath, "day4_puzzle_input.txt"));
// var forkliftPaperRollFinder = new ForkliftPaperRollFinder(rawGrid);
// var accessiblePaperRolls = forkliftPaperRollFinder.IdentifyNumberOfAccessiblePaperRollsInIterations();
//
// Console.WriteLine($"Accessible Paper Rolls: {accessiblePaperRolls}");

// Day 5
// var database = await File.ReadAllTextAsync(Path.Combine(filePath, "day5_puzzle_input.txt"));
// var iims = new IngredientInventoryManagementSystem(database);
// var freshIngredientCount = iims.DetermineFreshIngredientCount();
//
// Console.WriteLine($"Fresh ingredient count: {freshIngredientCount}");

// Day 5, part 2
// var database = await File.ReadAllTextAsync(Path.Combine(filePath, "day5_puzzle_input.txt"));
// var iims = new IngredientInventoryManagementSystem(database);
// var freshIngredientInRangesCount = iims.DetermineFreshIngredientCountInRanges();
//
// Console.WriteLine($"Fresh ingredient count in ranges: {freshIngredientInRangesCount}");

// Day 6
// var cephalopodMath = await File.ReadAllTextAsync(Path.Combine(filePath, "day6_puzzle_input.txt"));
// var cephalopodCalculator = new CephalopodCalculator();
// var sum = cephalopodCalculator.CalculateSumOfProblems(cephalopodMath);
//
// Console.WriteLine($"Sum of problems: {sum}");

// Day 6, part 2
// var cephalopodMath = await File.ReadAllTextAsync(Path.Combine(filePath, "day6_puzzle_input.txt"));
// var cephalopodCalculator = new CephalopodCalculator();
// var sum = cephalopodCalculator.CalculateSumOfProblemsRTL(cephalopodMath);
//
// Console.WriteLine($"Sum of problems, RTL: {sum}");

// Day 7
// var rawTachyonManifoldGrid = await File.ReadAllTextAsync(Path.Combine(filePath, "day7_puzzle_input.txt"));
// var tachyonManifold = new TachyonManifold();
// var splits = tachyonManifold.DetermineTachyonManifoldSplitCount(rawTachyonManifoldGrid);
//
// Console.WriteLine($"Number of beam splits: {splits}");

// Day 7, part 2
var rawTachyonManifoldGrid = await File.ReadAllTextAsync(Path.Combine(filePath, "day7_puzzle_input.txt"));
var tachyonManifold = new TachyonManifold();
var timelines = tachyonManifold.DetermineTachyonManifoldTimelines(rawTachyonManifoldGrid);

Console.WriteLine($"Number of timelines: {timelines}");
