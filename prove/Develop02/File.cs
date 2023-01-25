using System;

public class File
{
    public string _filename = "";

    public List<string> _entries = new List<string>();
    public void SaveFile()
    {    using (StreamWriter outputFile = new StreamWriter(_filename))
        {
            foreach (string line in _entries)
            {
                outputFile.WriteLine(line);
            }
        }
    }
    public List<string> LoadFile()
    {    string[] lines = System.IO.File.ReadAllLines(_filename);

        foreach (string line in lines)
        {
            _entries.Add(line);
        }
        return _entries;
    }  
}