using System;

public abstract class Goal
{
    protected string _description;
    protected string _name;
    protected int _points;
    protected string _type;

    /*Constructor*/
    public Goal(string description, string name, string type, int points)
    {
        _description = description;
        _name = name;
        _type = type;
        _points = points;
    }

    /*Abstract Methods*/
    public abstract int RecordEvent();
    public abstract bool IsComplete();
    public abstract void DisplayGoal();
    public abstract string SerializedGoal();
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

    /*Getters*/
    public string GetName()
    {
        return _name;
    }
}