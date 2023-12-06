namespace AdventOfCode;

using static Utility;

public abstract class Day3
{
    private const string InputFile = "/Users/bdw/RiderProjects/AdventOfCode/AdventOfCode/input/day3_input.txt";
    private const string TestFile = "/Users/bdw/RiderProjects/AdventOfCode/AdventOfCode/input/day3_test.txt";

    private static readonly List<List<int>> Directions = new List<List<int>>
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
                   if (Directions.Any(direction => lines[i + direction[0]][j + direction[1]] != '.' &&
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

    private static string GetNumber(IReadOnlyList<string> lines, int iIdx, int jIdx, bool[,] visited)
    {
        var res = "";
        res += lines[iIdx][jIdx];
        visited[iIdx,jIdx] = true;
        var left = jIdx - 1;
        var right = jIdx + 1;
        if (char.IsDigit(lines[iIdx][left]))
        {
            while (jIdx < lines[0].Length && char.IsDigit(lines[iIdx][left]))
            {
                res += lines[iIdx][left];
                visited[iIdx,left] = true;
                left--;
            }
            var strArray = res.ToCharArray();
            Array.Reverse(strArray);
            var reversedStr = new string(strArray);
            res = reversedStr;
        }

        if (!char.IsDigit(lines[iIdx][right])) return res;
        while (jIdx < lines[0].Length && char.IsDigit(lines[iIdx][right]))
        {
            res += lines[iIdx][right];
            visited[iIdx,right] = true;
            right++;
        }
        return res;
    }
    
    public static int Part2()
    {
        var total = 0;
        var lines = GetLines(InputFile);
        
        var visited = new bool[lines.Count, lines[0].Length];
        
        for (var i = 1; i < lines.Count - 1; i++)
        {
            for (var j = 1; j < lines[i].Length - 1; j++)
            {
                if (lines[i][j] != '*') continue;
                // found a '*'
                var countNumbers = 0;
                var currNums = new List<string>();
                var i1 = i;
                var j1 = j;
                foreach (var direction in from direction in Directions let iIdx = i1 + direction[0] let jIdx = j1 + direction[1] where char.IsDigit(lines[iIdx][jIdx]) && !visited[iIdx, jIdx] select direction)
                {
                    countNumbers++;
                    var num = GetNumber(lines, i + direction[0], j + direction[1], visited);
                    currNums.Add(num);
                }
                if (countNumbers == 2) total += int.Parse(currNums[1]) * int.Parse(currNums[0]);
            }
        }
        return total;
    }
}
