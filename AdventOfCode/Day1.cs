namespace AdventOfCode;
using static Utility;

// Trebuchet?!
public abstract class Day1
{
    private const string InputFile = "/Users/bdw/RiderProjects/AdventOfCode/AdventOfCode/input/day1_input.txt";

    public static int Part1()
    {
        var total = 0;
        var lines = GetLines(InputFile);
        foreach (var line in lines)
        {
            var l = 0;
            var r = line.Length - 1;
            while (!char.IsNumber(line[l]))
            {
                l++;
            }

            while (!char.IsNumber(line[r]))
            {
                r--;
            }

            char[] chars = { line[l], line[r] };
            total += int.Parse(new string(chars));
        }

        return total;
    }

    private static string FixLine(string line)
    {
            var replace = line.Replace("one", "oonee");
            
            // fix text colliding together
            replace = replace.Replace("two", "ttwoo");
            replace = replace.Replace("three", "tthreee");
            replace = replace.Replace("four", "ffourr");
            replace = replace.Replace("five", "ffivee");
            replace = replace.Replace("six", "ssixx");
            replace = replace.Replace("seven", "ssevenn");
            replace = replace.Replace("eight", "eeightt");
            replace = replace.Replace("nine", "nninee");
            replace = replace.Replace("zero", "zzeroo");

            // make numbers
            replace = replace.Replace("one", "1");
            replace = replace.Replace("two", "2");
            replace = replace.Replace("three", "3");
            replace = replace.Replace("four", "4");
            replace = replace.Replace("five", "5");
            replace = replace.Replace("six", "6");
            replace = replace.Replace("seven", "7");
            replace = replace.Replace("eight", "8");
            replace = replace.Replace("nine", "9");
            replace = replace.Replace("zero", "0");
            
            return replace.Where(char.IsDigit).Aggregate("", (current, c) => current + c);
    }

    public static int Part2()
    {
        var total = 0;
        var lines = GetLines(InputFile);
        foreach (var newLine in lines.Select(FixLine))
        {
            // Console.WriteLine(newLine + "\t" + newLine[0] + newLine[^1]);
            char[] chars = { newLine[0], newLine[^1] };
            total += int.Parse(new string(chars));
        }
        return total;
    }
}