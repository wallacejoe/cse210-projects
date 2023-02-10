using System;

public class Word
{
    private string _currentWord;
    private bool _currentState;

    /*Originally I planned for all these private methods to return
    a string. I realized that was not necessary. Having a 'Show' method
    proved unnecessary since it did not change _currentWord at all.*/
    
    //Hides the chosen word.
    private void Hide()
    {
        string newWord = "";
        foreach (char c in _currentWord)
        {
            newWord += "_";
        }
        _currentWord = newWord;
    }

    //Returns all words, 'hidden' words are replaced with underscores.
    public string GetRenderedText()
    {
        if (_currentState)
        {
            Hide();
            return _currentWord;
        }
        return _currentWord;
    }

    /*Constructors*/
    //Takes a 'string' as an input.
    public Word(string text, bool hidden)
    {
        _currentWord = text;
        _currentState = hidden;
    }
}