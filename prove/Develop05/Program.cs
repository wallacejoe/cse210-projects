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

        SimpleGoal simpleGoal = new SimpleGoal("Participate in any temple ordinance", "Go to the temple", 100);
        CheckBox(simpleGoal.IsComplete());
        simpleGoal.DisplayGoal();
        Console.Write("Press enter to mark complete:");
        Console.ReadLine();
        points += simpleGoal.RecordEvent();
        CheckBox(simpleGoal.IsComplete());
        simpleGoal.DisplayGoal();
        Console.WriteLine($"points: {points}");

        EternalGoal eternalGoal = new EternalGoal("Study the scriptures for at least 10 minutes", "Daily scripture study", 20);
        CheckBox(eternalGoal.IsComplete());
        eternalGoal.DisplayGoal();
        Console.Write("Press enter to mark complete:");
        Console.ReadLine();
        points += eternalGoal.RecordEvent();
        CheckBox(eternalGoal.IsComplete());
        eternalGoal.DisplayGoal();
        Console.WriteLine($"points: {points}");

        ChecklistGoal checklistGoal = new ChecklistGoal(500, 5, "Get any investigator to attend church with you", "Investigator attendance", 50);
        CheckBox(checklistGoal.IsComplete());
        checklistGoal.DisplayGoal();
        Console.Write("Press enter to mark complete:");
        Console.ReadLine();
        points += checklistGoal.RecordEvent();
        CheckBox(checklistGoal.IsComplete());
        checklistGoal.DisplayGoal();
        Console.WriteLine($"points: {points}");
    
    }
}