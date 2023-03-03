using System;

public class EternalGoal : Goal
{
    private int _completion = 0;

    /*Constructors*/
    public EternalGoal(string description, int points) : base(description, points){}

    public EternalGoal(int completion, string description, int points) : base(description, points)
    {
        _completion = completion;
    }

    /*Override Methods*/
    public override int RecordEvent()
    {
        _completion += 1;
        return _points;
    }

    public override bool IsComplete()
    {
        if (_completion == 0)
        {
            return false;
        }
        return true;
    }

    public override void DisplayGoal()
    {
        if (IsComplete())
        {
            Console.WriteLine($"Recorded completions: {_completion}");
        }
        else
        {
            Console.WriteLine("No recorded completions");
        }
    }
}