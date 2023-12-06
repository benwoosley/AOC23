namespace AdventOfCode;

using static Utility;

public class Day2: IDay
{
    private const string InputFile = "/Users/bdw/RiderProjects/AdventOfCode/AdventOfCode/input/day2_input.txt";
    private const int TotalGreen = 13;
    private const int TotalBlue = 14;
    private const int TotalRed = 12;
    public string Title { get; set; } = "--- Day 2: Cube Conundrum ---";

    private static bool IsPossible(string line)
    {
        var dict = new Dictionary<string, int>
        {
            ["green"] = TotalGreen,
            ["blue"] = TotalBlue,
            ["red"] = TotalRed 
        };
        var newLines = line.Split(":")[1].Split(";");
        return newLines.All(newLine => !newLine.Split(",").Select(val => val[1..].Split(" ")).Any(splitStr => dict[splitStr[1]] < int.Parse(splitStr[0])));
    }

    public int Part1()
    {
        var lines = GetLines(InputFile);
        var total = 0;
        for (var i = 1; i <= lines.Count; i++)
        {
            if (IsPossible(lines[i-1]))
            {
                total += i;
            }
        }

        return total;
    }

     private static int GetPower(string line)
     {
         var minimums = new Dictionary<string, int>
         {
             ["red"] = int.MinValue,
             ["green"] = int.MinValue,
             ["blue"] = int.MinValue 
         };
         
         var newStr = line.Split(":")[1];
         var newLines = newStr.Split(";");
         
         foreach (var newLine in newLines)
         {
             foreach (var val in newLine.Split(","))
             {
                 var splitStr = val[1..].Split(" ");
                 var currColor = splitStr[1];
                 var currCount = int.Parse(splitStr[0]);
                 minimums[currColor] = int.Max(minimums[currColor], currCount);
             }
         }
         var list = minimums.Values.ToList();
         return list.Aggregate(1, (current, power) => current * power);
     }
    
    public int Part2()
    {
        return GetLines(InputFile).Sum(GetPower);
    }
}