using System;

class Program
{
    static void Main(string[] args)
    {
        int points = 0;

        void CheckBox(bool stateOfCompletion)
        {
            if (stateOfCompletion)
            {
                Console.Write("[X] ");
            }
            else
            {
                Console.Write("[ ] ");
            }
        }

        SimpleGoal simpleGoal = new SimpleGoal("Go to the temple", 100);
        CheckBox(simpleGoal.IsComplete());
        simpleGoal.DisplayGoal();
        Console.Write("Press enter to mark complete:");
        Console.ReadLine();
        points += simpleGoal.RecordEvent();
        CheckBox(simpleGoal.IsComplete());
        simpleGoal.DisplayGoal();
        Console.WriteLine($"points: {points}");

        EternalGoal eternalGoal = new EternalGoal("Daily scripture study", 20);
        CheckBox(eternalGoal.IsComplete());
        eternalGoal.DisplayGoal();
        Console.Write("Press enter to mark complete:");
        Console.ReadLine();
        points += eternalGoal.RecordEvent();
        CheckBox(eternalGoal.IsComplete());
        eternalGoal.DisplayGoal();
        Console.WriteLine($"points: {points}");
    }
}