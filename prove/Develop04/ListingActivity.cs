using System;

public class ListingActivity : Activity
{
    private int _numListed = 0;
    private List<string> _prompts = new List<string>();

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
    }

    public ListingActivity(List<string> prompts, string name, string description, int duration) : base(name, description, duration)
    {
        _prompts = prompts;
    }
    
    /*Class Methods*/
    private string PromptGenerator()
    {
        Random randomGenerator = new Random();
        int magicNum = randomGenerator.Next(1, _prompts.Count());

        return _prompts[magicNum];
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
        Console.WriteLine($"You listed {_numListed} items!\n");
    }

    public void DisplayUserInput()
    {
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