using System;

public class Word
{
    private string _currentWord;
    private string[] _words;
    private int _numHidden = 0;

    /*Originally I planned for all these private methods to return
    a string. I realized that would not work quite as I had hoped.
    Removed the 'Show' method. It was initially going to handle display.*/
    
    //Changes the provided list of words, hiding some of them.
    private void HideWords()
    {
        Random randomNum = new Random();
        int wordNum = -1;
        List<int> hideOptions = new List<int>();
        //Determine if the current word is already hidden.
        foreach (string word in _words)
        {
            _currentWord = word;
            if (IsHidden() == true)
            {
                _numHidden += 1;
                wordNum += 1;
            }
            else
            {
                wordNum += 1;
                hideOptions.Add(wordNum);
            }
        }
        if (hideOptions.Count > 4)
        {
            int loopNum = 0;
            while (loopNum < 4)
            {
                int chosenNum = randomNum.Next(0,hideOptions.Count);
                _currentWord = _words[hideOptions[chosenNum]];
                _words[hideOptions[chosenNum]] = Hide();
                hideOptions.Remove(chosenNum);
                loopNum += 1;
                _numHidden += 1;
            }
        }
        else
        {
            foreach (int integer in hideOptions)
            {
                _currentWord = _words[integer];
                _words[integer] = Hide();
                _numHidden += 1;
            }
        }
    }

    //Hides the chosen word.
    private string Hide()
    {
        string newWord = "";
        foreach (char c in _currentWord)
        {
            newWord += "_";
        }
        return newWord;
    }

    //Determines if the current word is already hidden.
    private bool IsHidden()
    {
        bool hidden = true;
        char[] charArray = _currentWord.ToCharArray();
        foreach (char letter in charArray)
        {
            string letterString = $"{letter}";
            if (letterString != "_")
            {
                    hidden = false;
            }
        }
        return hidden;
    }

    //Gets the 'hiddenNum' attribute.
    public int GetNumHidden()
    {
        return _numHidden;
    }

    //Returns all words, 'hidden' words are replaced with underscores.
    public string GetRenderedText()
    {
        string newWords = "";
        HideWords();
        foreach (string line in _words)
        {
            newWords += $"{line} ";
        }
        return newWords;
    }

    /*Constructors*/
    //Takes a 'string[]' as an input.
    public Word(string[] text)
    {
        _words = text;
    }
}