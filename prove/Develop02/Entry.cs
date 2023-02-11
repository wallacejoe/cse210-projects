using System;

public class Entry
{
    private string _prompt;
    private string _userEntry;
    
    public string FullJournalEntry()
    {
        DateTime currentTime = DateTime.Now;
        string dateText = currentTime.ToShortDateString();
        string saveTime = currentTime.ToShortTimeString();

        string journalEntry = $"{saveTime},{dateText},";
        journalEntry = journalEntry + $"\"{_prompt}\"" + "," + $@"""{_userEntry}""";

        return journalEntry;
    }

    /*Constructor*/
    public Entry(string prompt, string userEntry)
    {
        _prompt = prompt;
        _userEntry = userEntry;
    }
}