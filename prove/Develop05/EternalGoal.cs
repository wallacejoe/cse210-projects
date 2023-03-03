using System;

public class EternalGoal : Goal
{
    /*Constructor*/
    public EternalGoal(string description, string name, string type, int points) : base(description, name, type, points){}

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

    public override string SerializedGoal()
    {
        string serializedString = $"{_type}|/^|{_name}|/^|{_description}|/^|{_points}";
        return serializedString;
    }
}