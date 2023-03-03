using System;

public class SimpleGoal : Goal
{
    private bool _completion;

    /*Constructors*/
    public SimpleGoal(string description, int points) : base(description, points){}

    public SimpleGoal(bool completion, string description, int points) : base(description, points)
    {
        _completion = completion;
    }
    /*Override Methods*/
    
}