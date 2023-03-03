using System;

public class SimpleGoal : Goal
{
    private bool _completion = false;

    /*Constructors*/
    public SimpleGoal(string description, int points) : base(description, points){}

    public SimpleGoal(bool completion, string description, int points) : base(description, points)
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