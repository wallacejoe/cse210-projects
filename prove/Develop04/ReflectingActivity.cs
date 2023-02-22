using System;

public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>();
    private List<string> _initialPrompts = new List<string>();
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
        foreach (string prompt in defaultPrompts)
            _initialPrompts.Add(prompt);

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
        _initialPrompts = prompts;
        _questions = questions;
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

    private string RandomQuestion(List<string> updatedQuestions)
    {
        if (!updatedQuestions.Any())
        {
            updatedQuestions = _questions;
        }
        Random randomGenerator = new Random();
        int magicNum = randomGenerator.Next(1, updatedQuestions.Count());
        string chosenQuestion = updatedQuestions[magicNum];

        return chosenQuestion;
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
        List<string> updatedQuestions = _questions;
        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        PauseCountdown(5);
        Console.Clear();

        DateTime futureTime = DateTime.Now.AddSeconds(_duration);
        DateTime currentTime = DateTime.Now;
        while (currentTime < futureTime)
        {
            Console.Write($"> {RandomQuestion(updatedQuestions)} ");
            PauseSpinner(30);
            Console.WriteLine();
            currentTime = DateTime.Now;
        }
        Console.WriteLine();
    }
}