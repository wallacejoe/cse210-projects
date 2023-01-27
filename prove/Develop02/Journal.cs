using System;

public class Journal
{
    public List<string> _entries = new List<string>();
    private String separator = ",";

    public void Display()
    {

        foreach (string line in _entries)
            {
                int lineTracker = 1;
                String[] lineList = line.Split(separator);
                int lineNum = lineList.Length;
                foreach (string innerLine in lineList)
                {
                    if (lineNum == lineTracker)
                    {
                        Console.WriteLine(innerLine);
                    }
                    else if (lineNum == lineTracker + 1)
                    {
                        Console.WriteLine(innerLine);
                    }
                    else
                    {
                        Console.Write($"{innerLine}, ");
                    }
                    lineTracker += 1;
                }
            }
    }
}