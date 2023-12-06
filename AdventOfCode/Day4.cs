using System;
using static System.Math;

namespace AdventOfCode;

using static Utility;

public class Day4
{
    
    private const string InputFile = "/Users/bdw/RiderProjects/AdventOfCode/AdventOfCode/input/day4_input.txt";
    private const string TestFile = "/Users/bdw/RiderProjects/AdventOfCode/AdventOfCode/input/day4_test.txt";


    private List<HashSet<string>> GetMap(List<string> lines)
    {
        var res = new List<HashSet<string>>();
        foreach (var line in lines)
        {
            var currHashSet = new HashSet<string>();
            foreach (var num in line.Split(':')[1].Split('|')[0].Split(' '))
            {
                if (num != "")
                {
                    currHashSet.Add(num);
                }
            }
            res.Add(currHashSet);
        }

        return res;
    }
    
    public int Part1()
    {
        var lines = GetLines(TestFile);

        var cards =  GetMap(lines);
        var games = lines.Select(line => line.Split('|')[1].Split(' ').Where(num => num != "").ToList()).ToList();
        var total = 0;
        
        for (var i = 0; i < games.Count; i++)
        {
            var currPower = -1;
            foreach (var num in games[i])
            {
                if (cards[i].Contains(num))
                {
                    currPower++;
                }
            }
            if (currPower >= 0)
                 total += 1 << currPower;
        }
        return total;
    }
}