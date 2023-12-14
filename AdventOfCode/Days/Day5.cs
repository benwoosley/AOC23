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

    // TODO: only check if the current seed is within the range (i.e. start + lengthOf Ranges) and whatever length of ranges is navigate to dest + thatLength 
    // thatLength may be startDest - currSeed
    // This naive map solution TLEs on the Input File
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
                foreach (var map in mapList)
                {
                    if (currValue < map.SourceRangeStart || currValue > map.SourceRangeStart + map.RangeLength)
                        continue;
                    currValue = map.DestRangeStart + (currValue - map.SourceRangeStart);
                    break;
                }
            }
            res = long.Min(res, currValue);
        }

        return res;
    }

    public object Part2()
    {
        return -1;
    }
}