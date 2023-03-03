using System;

public abstract class Goal
{
    protected string _description;
    protected string _name;
    protected int _points;

    /*Constructor*/
    public Goal(string description, string name, int points)
    {
        _description = description;
        _name = name;
        _points = points;
    }

    /*Abstract Methods*/
    public abstract int RecordEvent();
    public abstract bool IsComplete();
    public abstract void DisplayGoal();
    public void CheckBox()
    {
        if (IsComplete())
        {
            Console.Write("[X] ");
        }
        else
        {
            Console.Write("[ ] ");
        }
    }
}