namespace AdventOfCode;

using static Utility;

public abstract class Day3
{
    private const string InputFile = "/Users/bdw/RiderProjects/AdventOfCode/AdventOfCode/input/day3_input.txt";
    private const string TestFile = "/Users/bdw/RiderProjects/AdventOfCode/AdventOfCode/input/day3_test.txt";

    // directions:
    // front
    // -1 -1  (behind top diagonal)
    // -1 0 (behind)
    // -1 +1 (behind bottom diagonal)
    // 0 +1 (below)
    // +1 +1 (front bottom diagonal)
    // +1 0 (front)
    // +1 -1 (front top diagonal)
    // 0 -1 (above)
    // . . . . . .
    // . a b c d . 
    // . . . . . . 
    
    public static int Part1()
    {
        var directions = new List<List<int>>
        {
            new List<int>() { -1, -1 }, // behind top diagonal
            new List<int>() { -1, 0 }, // behind
            new List<int>(){-1, 1}, // behind bottom diagonal
            new List<int>(){0, 1}, // below 
            new List<int>(){1, 1}, // front bottom diagonal 
            new List<int>(){1, 0}, // front 
            new List<int>(){1, -1}, // front top diagonal
            new List<int>(){0, -1} // above 
       };
       var total = 0;
       var lines = GetLines(InputFile);
       var currNum = "";
       var isValid = false;
       
       for (var i = 1; i < lines.Count - 1; i++)
       {
           for (var j = 1; j < lines[i].Length - 1; j++)
           {
               if (char.IsDigit(lines[i][j]))
               {
                   currNum += lines[i][j];
                   if (directions.Any(direction => lines[i + direction[0]][j + direction[1]] != '.' &&
                                                   !char.IsDigit(lines[i + direction[0]][j + direction[1]])))
                   {
                       isValid = true;
                   }
               }
               else
               {
                   if (isValid)
                   {
                       total += int.Parse(currNum);
                   }
                   currNum = "";
                   isValid = false;
               }
           }
       }
       return total;
    }

    public static int Part2()
    {
        var total = 0;
        return total;
    }
}
