using System;
using System.IO;
using System.Text;

public class File
{
    private string _filename = "";

    private List<string> _entries = new List<string>();
    public void SaveFile()
    {    
        try
        {
            using (StreamWriter outputFile = new StreamWriter(_filename))
            foreach (string line in _entries)
            {
                outputFile.WriteLine(line);
            }
        } catch {Console.WriteLine("Error: Could not save to the chosen file.");}
    }
    public List<string> ParseFile()
    {    
        try
        {
            string[] lines = System.IO.File.ReadAllLines(_filename);

            foreach (string line in lines)
            {
                _entries.Add(line);
            }
            return _entries;
        } catch {
            Console.WriteLine("Error: could not load the chosen file.");
            _entries.Add("The chosen file could not be loaded.");
            return _entries;
            }
    }  

    /*Constructor*/
    public File(string filename, List<string> entries)
    {
        _filename = filename;
        _entries = entries;
    }
}