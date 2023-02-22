using System;

public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>();
    private List<string> _questions = new List<string>();

    /*Constructors*/
    public ReflectingActivity(string name, string description, int duration) : base(name, description, duration)
    {
        string[] defaultPrompts = {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };
        foreach (string prompt in defaultPrompts)
            _prompts.Add(prompt);

        string[] defaultQuestions = {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
        foreach (string question in defaultQuestions)
            _questions.Add(question);
    }

    public ReflectingActivity(List<string> prompts, List<string> questions, string name, string description, int duration) : base(name, description, duration)
    {
        _prompts = prompts;
        _questions = questions;
    }
    
    /*Class Methods*/
    private string PromptGenerator()
    {
        Random randomGenerator = new Random();
        int magicNum = randomGenerator.Next(1, _prompts.Count());

        string randomPrompt = _prompts[magicNum];
        return randomPrompt;
    }

    private string RandomQuestion()
    {
        Random randomGenerator = new Random();
        int magicNum = randomGenerator.Next(1, _questions.Count());
        return _questions[magicNum];
    }

    public void DisplayPrompt()
    {
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine($"\n --- {PromptGenerator()} ---");
        Console.WriteLine($"\nWhen you have something in mind, press enter to contiue.");
        Console.ReadLine();
    }

    public void DisplayQuestion()
    {
        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        PauseCountdown(5);
        Console.Clear();

        DateTime futureTime = DateTime.Now.AddSeconds(_duration);
        DateTime currentTime = DateTime.Now;
        while (currentTime < futureTime)
        {
            Console.Write($"> {RandomQuestion()} ");
            PauseSpinner(30);
            Console.WriteLine();
            currentTime = DateTime.Now;
        }
        Console.WriteLine();
    }
}