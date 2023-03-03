using System;

class Program
{
    static void Main(string[] args)
    {
        int points = 0;

        SimpleGoal simpleGoal = new SimpleGoal("Go to the temple", 100);
        simpleGoal.DisplayGoal();
        Console.Write("Press enter to mark complete:");
        Console.ReadLine();
        points += simpleGoal.RecordEvent();
        simpleGoal.DisplayGoal();
        Console.WriteLine($"points: {points}");
    }
}