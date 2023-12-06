namespace AdventOfCode;

using static Utility;

public abstract class Day4
{
    
    private const string InputFile = "/Users/bdw/RiderProjects/AdventOfCode/AdventOfCode/input/day4_input.txt";
    private const string TestFile = "/Users/bdw/RiderProjects/AdventOfCode/AdventOfCode/input/day4_test.txt";

    private static List<HashSet<string>> GetMap(List<string> lines)
    {
        var res = new List<HashSet<string>>();
        foreach (var line in lines)
        {
            var currHashSet = new HashSet<string>();
            foreach (var num in line.Split(':')[1].Split('|')[0].Split(' '))
            {
                if (num != "") currHashSet.Add(num);
            }
            res.Add(currHashSet);
        }
        return res;
    }

    private static List<List<string>> GetGames(IEnumerable<string> lines)
    {
        return lines.Select(line => line.Split('|')[1].Split(' ').Where(num => num != "").ToList()).ToList();
    }
    
    
    public static int Part1()
    {
        var lines = GetLines(InputFile);
        var cards =  GetMap(lines);
        var games = GetGames(lines);
        return games.Select((t, i) => -1 + t.Count(num => cards[i].Contains(num))).Where(currPower => currPower >= 0).Sum(currPower => 1 << currPower);
    }

    public static int Part2()
    {
        var lines = GetLines(InputFile);
        var numCards = lines.Count;
        var instances = new List<int>();
        for (var i = 0; i < numCards; i++)
        {
            instances.Add(1);
        }
        var cards = GetMap(lines);
        var games = GetGames(lines);
        for (var i = 0; i < numCards-1; i++)
        {
            var currMatches = games[i].Count(num => cards[i].Contains(num));
            for (var j = i + 1; j <= i + currMatches; j++)
            {
                instances[j] += instances[i];
            }
        }
        return instances.Sum();
    }
}
