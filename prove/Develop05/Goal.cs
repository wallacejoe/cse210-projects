using System;

public abstract class Goal
{
    protected string _description;
    protected int _points;

    public Goal(string description, int points)
    {
        _description = description;
        _points = points;
    }

    public abstract int RecordEvent();
    public abstract bool IsComplete();
    public abstract void DisplayGoal();
}