using System;

public class ChecklistGoal : Goal
{
    private int _completion = 0;
    private int _numToCompletion;
    private int _pointBonus;

    /*Constructors*/
    public ChecklistGoal(int pointBonus, int numToCompletion, string description, string name, int points) : base(description, name, points)
    {
        _pointBonus = pointBonus;
        _numToCompletion = numToCompletion;
    }

    public ChecklistGoal(int completion, int pointBonus, int numToCompletion, string description, string name, int points) : base(description, name, points)
    {
        _completion = completion;
        _pointBonus = pointBonus;
        _numToCompletion = numToCompletion;
    }

    /*Override Methods*/
    public override int RecordEvent()
    {
        if (!IsComplete())
        {
            _completion += 1;
            if (IsComplete())
            {
                return _points + _pointBonus;
            }
            return _points;
        }
        return 0;
    }

    public override bool IsComplete()
    {
        if (_completion < _numToCompletion)
        {
            return false;
        }
        return true;
    }

    public override void DisplayGoal()
    {
        Console.WriteLine($"{_name} ({_description}) -- Currently completed {_completion}/{_numToCompletion}");
    }
}