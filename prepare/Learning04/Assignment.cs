using System;

public class Assignment
{
    protected string _studentName;
    private string _topic;

    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }

    /*Constructor*/
    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }
}