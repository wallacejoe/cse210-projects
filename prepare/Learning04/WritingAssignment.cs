using System;

public class WritingAssignment : Assignment
{
    private string _title;

    public string GetWritingInfo()
    {
        return $"{_title} by {_studentName}";
    }

    /*Constructor*/
    public WritingAssignment(string studentName, string topic, string title) : base(studentName, topic)
    {
        _title = title;
    }
}