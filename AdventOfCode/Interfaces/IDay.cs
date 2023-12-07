namespace AdventOfCode.Interfaces;

public interface IDay
{
    string Title
    {
        get;
        set;
    }
    
    public  object Part1();
    public object Part2();
}