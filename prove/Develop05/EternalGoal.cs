using System;

public class EternalGoal : Goal
{
    /*Constructor*/
    public EternalGoal(string description, string name, int points) : base(description, name, points){}

    /*Override Methods*/
    public override int RecordEvent()
    {
        return _points;
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override void DisplayGoal()
    {
        Console.WriteLine($"{_name} ({_description})");
    }
}