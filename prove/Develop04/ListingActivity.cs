using System;

public class ListingActivity : Activity
{
    private int _numListed;
    private List<string> _prompts = new List<string>();
    private List<string> _initialPrompts = new List<string>();

    /*Constructors*/
    public ListingActivity(string name, string description, int duration) : base(name, description, duration)
    {
        string[] defaultPrompts = {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
        foreach (string prompt in defaultPrompts)
            _prompts.Add(prompt);
        foreach (string prompt in defaultPrompts)
            _initialPrompts.Add(prompt);
    }

    //I added options to allow for more input because they would
    //be convenient to have in many situations. I will only use
    //the default options for the assignment though.
    public ListingActivity(List<string> prompts, string name, string description, int duration) : base(name, description, duration)
    {
        _prompts = prompts;
        _initialPrompts = prompts;
    }

    /*Class Methods*/
    private string PromptGenerator()
    {
        if (!_prompts.Any())
        {
            _prompts = _initialPrompts;
        }
        Random randomGenerator = new Random();
        int magicNum = randomGenerator.Next(0, _prompts.Count());
        string chosenPrompt = _prompts[magicNum];
        _prompts.RemoveAt(magicNum);

        return chosenPrompt;
    }

    public void DisplayPrompt()
    {
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($" --- {PromptGenerator()} ---");
        Console.Write("You may begin in: ");
        PauseCountdown(5);
        Console.WriteLine();
    }

    public void DisplayListNum()
    {
        if (_numListed == 1)
        {
            Console.WriteLine($"You listed {_numListed} item!\n");
        }
        else
        {
            Console.WriteLine($"You listed {_numListed} items!\n");
        }
    }

    public void DisplayUserInput()
    {
        _numListed = 0;
        DateTime futureTime = DateTime.Now.AddSeconds(_duration);

        DateTime currentTime = DateTime.Now;
        while (currentTime < futureTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            _numListed += 1;
            currentTime = DateTime.Now;
        }
    }
}