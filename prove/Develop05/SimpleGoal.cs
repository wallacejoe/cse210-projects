using System;

public class SimpleGoal : Goal
{
    private bool _completion = false;

    /*Constructors*/
    public SimpleGoal(string description, string name, int points) : base(description, name, points){}

    public SimpleGoal(bool completion, string description, string name, int points) : base(description, name, points)
    {
        _completion = completion;
    }
    /*Override Methods*/
    public override int RecordEvent()
    {
        if (!IsComplete())
        {
            _completion = true;
            return _points;
        }
        else
        {
            return 0;
        }
    }

    public override bool IsComplete()
    {
        if (_completion)
        {
            return true;
        }
        return false;
    }

    public override void DisplayGoal()
    {
        Console.WriteLine(_description);
    }
}