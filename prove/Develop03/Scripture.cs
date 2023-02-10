using System;

public class Scripture
{
    private string[] _words;
    private string _text;
    private int _hiddenNum;
    private bool _initialDisplay = true;

    public string GetRenderedText()
    {
        if (_initialDisplay)
        {
            return _text;
        }
        else
        {
            HideWords();
            return _text;
        }
    }
    public string IsCompletelyHidden()
    {
        string userInput;
        if (_initialDisplay)
        {
            _initialDisplay = false;
            Console.WriteLine("Press enter to continue or type 'quit' to finish:");
            userInput = Console.ReadLine();
            return userInput;
        }
        else
        {
            if (_hiddenNum >= _words.Count())
            {
                return "quit";
            }
            Console.WriteLine("Press enter to continue or type 'quit' to finish:");
            userInput = Console.ReadLine();
            return userInput;
        }
    }
    //Initially this method was supposed to return a string.
    //I realized that was unnecessary and made it void.
    private void HideWords()
    {
        _words = _text.Split(" ");
        Word newWords = new Word(_words);
        _text = newWords.GetRenderedText();
        _hiddenNum = newWords.GetNumHidden();
    }

    /*Constructors*/
    //Takes a single 'string' input. Was originally going to
    //store the reference (book and chapter) but I realized it
    //had no reason to interact with that element.
    public Scripture(string verse)
    {
        _text = verse;
    }
}