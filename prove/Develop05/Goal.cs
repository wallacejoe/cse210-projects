using System;

public abstract class Goal
{
    protected string _description;
    protected int _points;

    /*Constructor*/
    public Goal(string description, int points)
    {
        _description = description;
        _points = points;
    }

    /*Abstract Methods*/
    public abstract int RecordEvent();
    public abstract bool IsComplete();
    public abstract void DisplayGoal();
}