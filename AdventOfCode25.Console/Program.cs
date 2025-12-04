// See https://aka.ms/new-console-template for more information

using AdventOfCode25.Logic.Day1;

var homeDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
var filePath = Path.Combine(homeDirectory, "projects/advent-of-code-25/AdventOfCode25.Console/Assets/day1_puzzle_input.txt");

// Day 1
var lines = await File.ReadAllLinesAsync(filePath);
var safe = new Safe();
var encounteredZeroes = safe.ConductInstructionSequence(lines);

Console.WriteLine($"Conducted sequence, encountered zeroes: {encounteredZeroes}");
