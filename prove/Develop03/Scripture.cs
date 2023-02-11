using System;

public class Scripture
{
    private string[] _words;
    private string _text;
    private string _fullRef;
    private List<int> _hiddenWords = new List<int>();
    private bool _initialDisplay = true;

    /*Methods, public and private*/
    //In conjunction with the Word class, this method hides a set number
    //of words that are not already hidden.
    private string HideWords()
    {
        string newText = "";
        int currentNum = 0;
        List<int> hideOptions = new List<int>();
        _words = _text.Split(" ");
        if (!_initialDisplay)
        {
            foreach (string line in _words)
            {
                Word findHidden = new Word(currentNum);
                if (!findHidden.IsHidden(_hiddenWords))
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
        }
        currentNum = 0;
        foreach (string line in _words)
        {
            Word hideWord = new Word(line, currentNum);
            hideWord.IsHidden(_hiddenWords);
            
            if (currentNum == _words.Count() - 1)
            {
                currentNum += 1;
                newText += hideWord.GetRenderedText();
            }
            else
            {
                currentNum += 1;
                newText += $"{hideWord.GetRenderedText()} ";
            }
        }
        return newText;
    }

    //Gets and returns the complete rendered text, including the reference.
    public string GetRenderedText()
    {
        string fullText = $"{_fullRef} {HideWords()}";
        return fullText;
    }

    //Determines if all words are hidden. Either takes the users input,
    //or terminates the program if all words are hidden.
    public string IsCompletelyHidden()
    {
        string userInput;
        if (_initialDisplay)
        {
            _initialDisplay = false;
            Console.WriteLine("Type 'reset' to start over or 'back' to undo recently hidden words.");
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
            Console.WriteLine("Type 'reset' to start over or 'back' to undo recently hidden words.");
            Console.WriteLine("Press enter to continue or type 'quit' to finish:");
            userInput = Console.ReadLine();
            return userInput;
        }
    }

    //Reveals the last set of words to be hidden.
    public void Undo()
    {
        try
        {
            for (int i = 0; i < 4; i++)
            {
                _hiddenWords.RemoveAt(_hiddenWords.Count() - 1);
            }
        } catch {}
        _initialDisplay = true;
    }

    //'Restarts' the program by clearing the list keeping track of hidden words.
    public void Reset()
    {
        _hiddenWords.Clear();
        _initialDisplay = true;
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