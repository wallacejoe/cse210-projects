using System;

public class Entry
{
    public string _prompt = "";
    public string _userEntry = "";
    
    public string FullJournalEntry()
    {
        DateTime currentTime = DateTime.Now;
        string dateText = currentTime.ToShortDateString();
        string saveTime = currentTime.ToShortTimeString();

        string journalEntry = $@"{saveTime}, {dateText} - Prompt: {_prompt}
{_userEntry}";

        return journalEntry;
    }
}