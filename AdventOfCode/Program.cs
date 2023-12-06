// See https://aka.ms/new-console-template for more information

using AdventOfCode;

// Console.WriteLine("Day 1 - Trebuchet?!");
// Console.WriteLine("Part 1: " + Day1.Part1());
// Console.WriteLine("Part 2: " + Day1.Part2());

// Console.WriteLine("Day 2 - Cube Conundrum");
// Console.WriteLine("Part 1: " + Day2.Part1());
// Console.WriteLine("Part 2: " + Day2.Part2());

// Console.WriteLine("Day 3 - Gear Ratios");
// Console.WriteLine("Part 1: " + Day3.Part1());
// Console.WriteLine("Part 2: " + Day3.Part2());

// Console.WriteLine("Day 4 - Scratchcards");
// Console.WriteLine("Part 1: " + Day4.Part1());
// Console.WriteLine("Part 2: " + Day4.Part2());

var days = new List<IDay>
{
    new Day1(),
    new Day2(),
    new Day3(),
    new Day4(),
    new Day5(),
    new Day6(),
};

foreach (var day in days)
{
    Console.WriteLine(day.Title);
    Console.WriteLine("Part 1: " + day.Part1());
    Console.WriteLine("Part 2: " + day.Part2());
    Console.WriteLine();
}
