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

}