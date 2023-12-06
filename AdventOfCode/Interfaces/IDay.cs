namespace AdventOfCode.Interfaces;

public interface IDay
{
    string Title
    {
        get;
        set;
    }
    public  int Part1();
    public int Part2();
}