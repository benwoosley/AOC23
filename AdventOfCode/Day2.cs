namespace AdventOfCode;

using static Utility;

public abstract class Day2
{
    private const string InputFile = "/Users/bdw/RiderProjects/AdventOfCode/AdventOfCode/input/day2_input.txt";
    private const int TotalGreen = 13;
    private const int TotalBlue = 14;
    private const int TotalRed = 12;


    private static bool IsPossible(string line)
    {
        // create a map 
        var dict = new Dictionary<string, int>
        {
            ["green"] = TotalGreen,
            ["blue"] = TotalBlue,
            ["red"] = TotalRed 
        };
        
        // Step 1, remove the game name from the string (":"), and split by drawn hands (";")
        var newLines = line.Split(":")[1].Split(";");
        
        // LINQ 
        // Check if all elements in 'newLines' satisfy the condition:
        // For each 'newLine', split it by ',' and check if there exists any subsequence 
        // (after skipping the first character of each substring) where the corresponding 
        // dictionary value ('dict[splitStr[1]]') is less than the parsed integer value 
        
        // of the first substring ('int.Parse(splitStr[0])').
        return newLines.All(newLine => !newLine.Split(",").Select(val => val[1..].Split(" ")).Any(splitStr => dict[splitStr[1]] < int.Parse(splitStr[0])));
    }
//    private static bool IsPossible(string line)
//    {
//        // create a map 
//        var dict = new Dictionary<string, int>
//        {
//            ["green"] = TotalGreen,
//            ["blue"] = TotalBlue,
//            ["red"] = TotalRed 
//        };
//        
//        // Step 1, remove the game name from the string
//        var newStr = line.Split(":")[1];
//        var newLines = newStr.Split(";");
//        foreach (var newLine in newLines)
//        {
//            foreach (var val in newLine.Split(","))
//            {
//                var splitStr = val[1..].Split(" ");
//                var isInRange = dict[splitStr[1]] < int.Parse(splitStr[0]);
//                
//                // Console.WriteLine("COLOR: " + splitStr[1] + "\tVAL: " + splitStr[0] + "\tMAX: " + dict[splitStr[1]] + "\tIS VALID: " + isInRange);
//                
//                if (isInRange)
//                {
//                    return false;
//                }
//            }
//        }
//
//        return true;
//    }
    
    public static int Part1()
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
                 // Console.WriteLine(currColor + " " + currCount);
                 minimums[currColor] = int.Max(minimums[currColor], currCount);
             }
         }
         
         // foreach (var kvp in minimums)
         // {
         //     Console.Write(kvp.Key + " = " + kvp.Value + " ");
         // }
         // Console.WriteLine();
         
         var list = minimums.Values.ToList();
         return list.Aggregate(1, (current, power) => current * power);
     }
    
    public static int Part2()
    {
        return GetLines(InputFile).Sum(GetPower);
    }
}