using System;

public class SimpleGoal : Goal
{
    private string _completion = "false";

    /*Constructors*/
    public SimpleGoal(string description, string name, string type, int points) : base(description, name, type, points){}

    public SimpleGoal(string completion, string description, string name, string type, int points) : base(description, name, type, points)
    {
        _completion = completion;
    }
    /*Override Methods*/
    public override int RecordEvent()
    {
        if (!IsComplete())
        {
            _completion = "true";
            return _points;
        }
        else
        {
            return 0;
        }
    }

    public override bool IsComplete()
    {
        if (_completion == "true")
        {
            return true;
        }
        return false;
    }

    public override void DisplayGoal()
    {
        Console.WriteLine($"{_name} ({_description})");
    }

    public override string SerializedGoal()
    {
        string serializedString = $"{_type}|/^|{_name}|/^|{_description}|/^|{_points}|/^|{_completion}";
        return serializedString;
    }
}