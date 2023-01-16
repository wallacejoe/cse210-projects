using System;

public class Writer
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
}