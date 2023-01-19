using System;
using System.IO;
public class PromptGenerator
{
    public string RandomPrompt()
    {
        List<string> prompts = new List<string>() {
            "What was the most random thing that happened today?",
            "What is something new you've leared today?",
            "What was the most productive thing you've done today?",
            "What do you wish you would've done today?",
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        Random randomGenerator = new Random();
        int magicNum = randomGenerator.Next(1, prompts.Count);

        string randomString = prompts[magicNum];

        return randomString;
    }

}