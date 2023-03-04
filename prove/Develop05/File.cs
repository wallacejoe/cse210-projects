using System;
using System.IO;

public class File
{
    private string _filename;
    private int _points;

    /*Constructor*/
    public File(string filename)
    {
        _filename = filename;
    }

    /*Methods*/
    //I decided to serialize directely from the classes, I kept
    //the file class in order to condence the code for reading
    //and writing to a file.
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

    public List<Goal> DeserializeFile()
    {
        List<Goal> loadedGoals = new List<Goal>();
        string[] lines = System.IO.File.ReadAllLines(_filename);
        foreach (string line in lines)
        {
            string[] parts = line.Split("|/^|");

            if (parts[0] == "SimpleGoal")
            {
                loadedGoals.Add(new SimpleGoal(parts[4] ,parts[2], parts[1], parts[0], int.Parse(parts[3])));
            }
            else if (parts[0] == "EternalGoal")
            {
                loadedGoals.Add(new EternalGoal(parts[2], parts[1], parts[0], int.Parse(parts[3])));
            }
            else if (parts[0] == "ChecklistGoal")
            {
                loadedGoals.Add(new ChecklistGoal(int.Parse(parts[6]), int.Parse(parts[5]), parts[2], parts[1], parts[0], int.Parse(parts[3])));
                //{_type}|/^|{_name}|/^|{_description}|/^|{_points}|/^|{_completion}|/^|{_numToCompletion}|/^|{_pointBonus}
            }
            else
            {
                _points = int.Parse(parts[0]);
            }
        }
        return loadedGoals;
    }

    public int GetPoints()
    {
        return _points;
    }
}