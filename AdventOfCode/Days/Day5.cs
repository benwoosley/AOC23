using System.ComponentModel;
using AdventOfCode.Interfaces;
using static AdventOfCode.Utilities.InputUtility;

namespace AdventOfCode.Days;

internal struct Map()
{
    public long DestRangeStart { get; init;  }
    public long SourceRangeStart { get; init; }
    public long RangeLength { get; init; }
}

public class Day5 : IDay
{
    public string Title { get; set; } = "--- Day 5: If You Give A Seed A Fertilizer ---";
    private const string InputFile = "/Users/bdw/RiderProjects/AdventOfCode/AdventOfCode/Input/day5_input.txt";
    private const string TestFile = "/Users/bdw/RiderProjects/AdventOfCode/AdventOfCode/Input/day5_test.txt";

    public object Part1()
    {
        var lines = GetLines(InputFile);
        var seeds = lines[0].Split(':')[1].Split(' ').Where(x => x != "").Select(long.Parse).ToList();
        var maps = new List<List<Map>>();
        for (var i = 1; i < lines.Count; i++)
        {
            if (!lines[i].Contains(':')) continue;
            var currList = new List<Map>();
            i++;
            while (i < lines.Count && lines[i] != "")
            {
                var nums = lines[i].Split(' ').Where(x => x != "").ToList();
                var currMap = new Map
                {
                    DestRangeStart = long.Parse(nums[0]),
                    SourceRangeStart = long.Parse(nums[1]),
                    RangeLength = long.Parse(nums[2])
                };
                currList.Add(currMap);
                i++;
            }
            maps.Add(currList);
        }

        var res = long.MaxValue;
        
        foreach (var seed in seeds)
        {
            var currValue = seed;
            foreach (var mapList in maps)
            {
                foreach (var map in mapList.Where(map => currValue >= map.SourceRangeStart && currValue <= map.SourceRangeStart + map.RangeLength))
                {
                    currValue = map.DestRangeStart + (currValue - map.SourceRangeStart);
                    break;
                }
            }
            res = long.Min(res, currValue);
        }
        return res;
    }

    // TODO: treat the seeds like a map struct, find the lowest seed that allows you to get into the seed to soil map
    public object Part2()
    {
        var lines = GetLines(TestFile);
        var seedRanges = lines[0].Split(':')[1].Split(' ').Where(x => x != "").Select(long.Parse).ToList();
        var seeds = new List<long>();
        for (var i = 0; i < seedRanges.Count; i++)
        {
            if (i % 2 != 0) continue;
            seeds.Add(seedRanges[i]);
            for (var j = 1; j < seedRanges[i + 1]; j++)
            {
                seeds.Add(seedRanges[i] + j);
            }
        }
        
        var maps = new List<List<Map>>();
        for (var i = 1; i < lines.Count; i++)
        {
            if (!lines[i].Contains(':')) continue;
            var currList = new List<Map>();
            i++;
            while (i < lines.Count && lines[i] != "")
            {
                var nums = lines[i].Split(' ').Where(x => x != "").ToList();
                var currMap = new Map
                {
                    DestRangeStart = long.Parse(nums[0]),
                    SourceRangeStart = long.Parse(nums[1]),
                    RangeLength = long.Parse(nums[2])
                };
                currList.Add(currMap);
                i++;
            }
            maps.Add(currList);
        }

        var res = long.MaxValue;
        
        foreach (var seed in seeds)
        {
            var currValue = seed;
            foreach (var mapList in maps)
            {
                foreach (var map in mapList.Where(map => currValue >= map.SourceRangeStart && currValue <= map.SourceRangeStart + map.RangeLength))
                {
                    currValue = map.DestRangeStart + (currValue - map.SourceRangeStart);
                    break;
                }
            }
            res = long.Min(res, currValue);
        }
        return res;
    }
}