using System;
using System.IO;

public class File
{
    private string _filename;

    /*Constructor*/
    public File(string filename)
    {
        _filename = filename;
    }

    /*Methods*/
    //I decided to serialize directely from the classes, I kept
    //the file class in order to condence reading and writing
    //to a file.
    public void WriteToFile(List<string> values)
    {
        using (StreamWriter outputFile = new StreamWriter(_filename))
        {
            foreach (string output in values)
            {
                outputFile.WriteLine(output);
            }
        }
    }
}