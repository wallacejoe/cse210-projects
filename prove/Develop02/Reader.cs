using System;
using System.IO;

public class Reader
{
    public string _filename = "";
    List<string> _entries = new List<string>();
    public List<string> CreateFile()
    {    string[] lines = System.IO.File.ReadAllLines(_filename);

        foreach (string line in lines)
        {
            _entries.Add(line);
        }
        return _entries;
    }    
}