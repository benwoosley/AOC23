// See https://aka.ms/new-console-template for more information

using AdventOfCode.Days;
using AdventOfCode.Interfaces;

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
