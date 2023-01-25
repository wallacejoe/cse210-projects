using System;

public class Journal
{
    public List<string> _entries = new List<string>();
    
    public void Display()
    {
        foreach (string line in _entries)
            {
                Console.WriteLine(line);
            }
    }
}