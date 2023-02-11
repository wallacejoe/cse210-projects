using System;
using System.Text;

public class Journal
{
    private List<string> _entries = new List<string>();

    /*Getters and Setters*/
    public List<string> GetEntries()
    {
        return _entries;
    }

    public void SetEntries(List<string> entries)
    {
        _entries = entries;
    }

    public void AddEntries(string entry)
    {
        _entries.Add(entry);
    }

    /*Display Method*/

    public void Display()
    {
        foreach (string line in _entries)
            {
                int lineTracker = 1;
                String[] splitList = SplitCsv(line);
                int lineNum = splitList.Length;
                foreach (string innerLine in splitList)
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
                Console.WriteLine();
            }

    //Csv string parser, ignores commas inside double quotes.
    //Found on stackoverflow: https://stackoverflow.com/questions/3776458/split-a-comma-separated-string-with-both-quoted-and-unquoted-strings
    static string[] SplitCsv(string line)
    {
        List<string> result = new List<string>();
        StringBuilder currentStr = new StringBuilder("");
        bool inQuotes = false;
        for (int i = 0; i < line.Length; i++) // For each character
        {
            if (line[i] == '\"') // Quotes are closing or opening
                inQuotes = !inQuotes;
            else if (line[i] == ',') // Comma
            {
                if (!inQuotes) // If not in quotes, end of current string, add it to result
                {
                    result.Add(currentStr.ToString());
                    currentStr.Clear();
                }
                else
                    currentStr.Append(line[i]); // If in quotes, just add it 
            }
            else // Add any other character to current string
                currentStr.Append(line[i]); 
        }
        result.Add(currentStr.ToString());
        return result.ToArray(); // Return array of all strings
    }
    }
}