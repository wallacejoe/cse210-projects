using System;

public class Word
{
    private string _currentWord;
    private int _currentNum;
    private bool _currentState;

    /*Originally I planned for all these methods to return a string.
    I realized that was not necessary. Having a 'Show' method
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
    
    public bool IsHidden(List<int> hiddenWords)
    {
        bool hidden = false;
        for (int i = 0; i < hiddenWords.Count(); i++)
        {
            if (_currentNum == hiddenWords[i])
            {
                hidden = true;
            }
        }
        _currentState = hidden;
        return hidden;
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
    //Takes an input of 'string' and 'int'.
    public Word(string text, int currentNum)
    {
        _currentWord = text;
        _currentNum = currentNum;
    }

    //Takes just an 'int' as an input.
    //Used primarily to determine shown/hidden state.
    public Word(int currentNum)
    {
        _currentNum = currentNum;
    }
}