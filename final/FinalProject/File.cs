using System;
public class File
{
    private string _filename;

    /*Constructors*/
    public File(string filename)
    {
        _filename = filename;
    }

    /*Methods*/
    public void WriteToFile(List<string> lines)
    {
        try
        {
            using (StreamWriter outputFile = new StreamWriter(_filename))
            foreach (string line in lines)
            {
                outputFile.WriteLine(line);
            }
        } catch {Console.WriteLine("Error: Could not save to the chosen file.");}
    }

    public void Deserialize()
    {
        
    }
}