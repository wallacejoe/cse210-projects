using System;

public class Scripture
{
    private string[] _words;
    private string _text;
    private string _fullRef;
    private List<int> _hiddenWords = new List<int>();
    private bool _initialDisplay = true;
    private string HideWords()
    {
        string newText = "";
        int currentNum = 0;
        List<int> hideOptions = new List<int>();
        _words = _text.Split(" ");
        foreach (string line in _words)
        {
            bool hidden = false;
            for (int i = 0; i < _hiddenWords.Count(); i++)
            {
                if (currentNum == _hiddenWords[i])
                {
                    hidden = true;
                }
            }
            if (!hidden)
            {
                hideOptions.Add(currentNum);
            }
            currentNum += 1;
        }
        if (hideOptions.Count() > 4)
        {
            for (int i = 0; i < 4; i++)
            {
                Random getRandomNum = new Random();
                int randomNum = getRandomNum.Next(0, hideOptions.Count());
                int hideNewWord = hideOptions[randomNum];
                hideOptions.Remove(hideNewWord);
                _hiddenWords.Add(hideNewWord);
            }
        }
        else
        {
            foreach (int number in hideOptions)
            {
                _hiddenWords.Add(number);
            }
        }
        currentNum = 0;
        foreach (string line in _words)
        {
            bool hidden = false;
            for (int i = 0; i < _hiddenWords.Count(); i++)
            {
                if (currentNum == _hiddenWords[i])
                {
                    hidden = true;
                }
            }
            if (currentNum == _words.Count() - 1)
            {
                currentNum += 1;
                Word hideWord = new Word(line, hidden);
                newText += hideWord.GetRenderedText();
            }
            else
            {
                currentNum += 1;
                Word hideWord = new Word(line, hidden);
                newText += $"{hideWord.GetRenderedText()} ";
            }
        }
        return newText;
    }

    public string GetRenderedText()
    {
        if (_initialDisplay)
        {
            string fullText = $"{_fullRef} {_text}";
            return fullText;
        }
        else
        {
            string fullText = $"{_fullRef} {HideWords()}";
            return fullText;
        }
    }
    public string IsCompletelyHidden()
    {
        Console.Clear();
        Console.WriteLine((GetRenderedText()));
        Console.WriteLine("");
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
            if (_hiddenWords.Count() >= _words.Count())
            {
                return "quit";
            }
            Console.WriteLine("Press enter to continue or type 'quit' to finish:");
            userInput = Console.ReadLine();
            return userInput;
        }
    }

    /*Constructors*/
    //Takes a single 'string' input. Was originally going to
    //store the reference (book and chapter) but I realized it
    //had no reason to interact with that element.
    public Scripture(string[] fullText)
    {
        _text = fullText[1];
        _fullRef = fullText[0];
    }
}