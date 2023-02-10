using System;
using System.IO;

public class File
{
    private string _filename = "";
    private List<string> _fileLines = new List<string>();

    public List<string> ParseFile()
    {    
        string[] lines = System.IO.File.ReadAllLines(_filename);

        foreach (string line in lines)
        {
            _fileLines.Add(line);
        }
        return _fileLines;
    }

    /*Constructor*/
    //Takes input of 'string'. Stores it in _filename.
    public File(string filename)
    {
        _filename = filename;
    }
}