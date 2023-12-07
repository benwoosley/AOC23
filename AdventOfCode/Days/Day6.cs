using AdventOfCode.Interfaces;
using AdventOfCode.Utilities;

namespace AdventOfCode.Days;

using static InputUtility;

internal readonly struct Race(int time, int distance)
{
    public int GetTime()
    {
        return time;
    }

    public int GetDistance()
    {
        return distance;
    }
}

public class Day6: IDay
{
    private const string InputFile = "/Users/bdw/RiderProjects/AdventOfCode/AdventOfCode/Input/day6_input.txt";
    private const string TestFile = "/Users/bdw/RiderProjects/AdventOfCode/AdventOfCode/Input/day6_test.txt";
    public string Title { get; set; } = "--- Day 6: Wait For It ---";

    public object Part1()
    {
        var lines = GetLines(InputFile);
        var times = (from time in lines[0].Split(':')[1].Split(' ') where time != "" select int.Parse(time)).ToList();
        var distances = (from distance in lines[1].Split(':')[1].Split(' ')
            where distance != ""
            select int.Parse(distance)).ToList();
        var races = times.Select((t, i) => new Race(t, distances[i])).ToList();
        var counts = new List<int>();
        foreach (var race in races)
        {
            var currCount = 0;
            for (var i = 1; i < race.GetTime() - 1; i++)
            {
                var currRes = i * (race.GetTime() - i);
                if (currRes > race.GetDistance()) currCount++;
            }
            counts.Add(currCount);
        }
        return counts.Where(count => count > 0).Aggregate(1, (current, count) => current * count);
    }

    public object Part2()
    {
        var lines = GetLines(InputFile);
        var time = long.Parse(lines[0].Split(':')[1].Split(' ').Where(num => num != "").Aggregate("", (current, num) => current + num));
        var distance = long.Parse(lines[1].Split(':')[1].Split(' ').Where(num => num != "").Aggregate("", (current, num) => current + num));
        var count = 0;
        for (var i = 1; i < time - 1; i++)
        {
            var currRes = i * (time - i);
            if (currRes > distance) count++;
        }
        return count;
    }
}