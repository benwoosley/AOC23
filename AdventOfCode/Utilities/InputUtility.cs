namespace AdventOfCode.Utilities;

public abstract class InputUtility
{
    public static List<string> GetLines(string inputFile)
    {
        var res = new List<string>();
        var sr = new StreamReader(inputFile);
        try
        {
            var line = sr.ReadLine();
            while (line != null)
            {
                res.Add(line);
                line = sr.ReadLine();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }

        return res;
    }
    
}