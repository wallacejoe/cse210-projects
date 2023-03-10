using System;

class Program
{
    static void Main(string[] args)
    {
        int points = 0;
        string userInput = "";
        DateTime dateTime = DateTime.Today;
        int goalStreak = 0;
        List<Goal> goals = new List<Goal>();

        while (userInput != "6")
        {
            Console.WriteLine($"\nCurrent Rank: {DetermineRank(points)}");
            Console.WriteLine($"You have {points} points\n");
        
            Console.WriteLine("Menu Options:");
            Console.WriteLine(" 1. Create New Goal");
            Console.WriteLine(" 2. List Goals");
            Console.WriteLine(" 3. Save Goals");
            Console.WriteLine(" 4. Load Goals");
            Console.WriteLine(" 5. Record Event");
            Console.WriteLine(" 6. Quit");
            Console.Write("Select a choice from the menu: ");
            userInput = Console.ReadLine();

            if (userInput == "1")
            {
                string goalChoice = "";

                Console.Clear();
                Console.WriteLine("The types of Goals are:");
                Console.WriteLine(" 1. Simple Goal");
                Console.WriteLine(" 2. Eternal Goal");
                Console.WriteLine(" 3. Checklist Goal");
                Console.Write("Which type of goal would you like to create? ");
                goalChoice = Console.ReadLine();
                if (goalChoice == "1")
                {
                    try
                    {
                        Console.Write("What is the name of your goal? ");
                        string goalName = Console.ReadLine();
                        Console.Write("What is a short description of it? ");
                        string goalDescription = Console.ReadLine();
                        Console.Write("What is the amount of points associated with this goal? ");
                        int goalPoints = int.Parse(Console.ReadLine());
                        goals.Add(new SimpleGoal(goalDescription, goalName, "SimpleGoal", goalPoints));
                    } catch{Console.WriteLine("Your input did not match the required format");}
                }
                else if (goalChoice == "2")
                {
                    try
                    {
                        Console.Write("What is the name of your goal? ");
                        string goalName = Console.ReadLine();
                        Console.Write("What is a short description of it? ");
                        string goalDescription = Console.ReadLine();
                        Console.Write("What is the amount of points associated with this goal? ");
                        int goalPoints = int.Parse(Console.ReadLine());
                        goals.Add(new EternalGoal(goalDescription, goalName, "EternalGoal", goalPoints));
                    } catch{Console.WriteLine("Your input did not match the required format");}
                }
                else if (goalChoice == "3")
                {
                    try
                    {
                        Console.Write("What is the name of your goal? ");
                        string goalName = Console.ReadLine();
                        Console.Write("What is a short description of it? ");
                        string goalDescription = Console.ReadLine();
                        Console.Write("What is the amount of points associated with this goal? ");
                        int goalPoints = int.Parse(Console.ReadLine());
                        Console.Write("How many times does this goal need to be accomplished? ");
                        int requiredNum = int.Parse(Console.ReadLine());
                        Console.Write("What is the bonus for accomplishing it that many times? ");
                        int goalBonus = int.Parse(Console.ReadLine());
                        goals.Add(new ChecklistGoal(goalBonus, requiredNum, goalDescription, goalName, "ChecklistGoal", goalPoints));
                    } catch{Console.WriteLine("Your input did not match the required format");}
                }
                else
                {
                    Console.WriteLine("That was not a valid input");
                }
            }
            else if (userInput == "2")
            {
                foreach (Goal goal in goals)
                {
                    goal.CheckBox();
                    goal.DisplayGoal();
                }
            }
            else if (userInput == "3")
            {
                Console.Write("What is the filename for the goal file? ");
                File file = new File(Console.ReadLine());
                List<string> serializedGoals = new List<string>();
                serializedGoals.Add($"Points|/^|{points.ToString()}");
                serializedGoals.Add($"Streak|/^|{goalStreak.ToString()}");
                serializedGoals.Add($"Date|/^|{dateTime.ToString()}");
                foreach (Goal goal in goals)
                {
                    serializedGoals.Add(goal.SerializedGoal());
                }
                file.WriteToFile(serializedGoals);
            }
            else if (userInput == "4")
            {
                Console.Write("What is the filename for the goal file? ");
                File file = new File(Console.ReadLine());
                goals = file.DeserializeFile();
                points = file.GetPoints();
                goalStreak = file.GetStreak();
                dateTime = file.GetDate();
            }
            else if (userInput == "5")
            {
                int currentPoints = points;
                int goalInteger = 1;
                Console.WriteLine("The goals are:");
                foreach (Goal goal in goals)
                {
                    Console.WriteLine($" {goalInteger}. {goal.GetName()}");
                    goalInteger += 1;
                }
                Console.Write("Which goal did you accomplish? ");
                int chosenGoal = int.Parse(Console.ReadLine()) - 1;
                points += goals[chosenGoal].RecordEvent();
                DateTime currentTime = DateTime.Today;
                if (currentPoints < points)
                {
                    if (dateTime.AddDays(1) <= currentTime && dateTime.AddDays(2) > currentTime)
                    {
                        goalStreak += 1;
                        points += goalStreak * 10;
                        dateTime = currentTime;
                        Console.WriteLine($"\nYou get {goalStreak * 10} points for your goal streak, log in every day to increase your streak!");
                        Console.WriteLine($"Current streak: {goalStreak}\n");
                    }
                    else if (dateTime.AddDays(1) < currentTime)
                    {
                        dateTime = currentTime;
                        goalStreak = 0;
                    }
                }
            }
            else if (userInput == "6"){}
            else
            {
                Console.WriteLine("That input is not valid.");
                Console.Write("Press enter to continue:");
                Console.ReadLine();
            }
        }

        string DetermineRank(int points)
        {
            if (points < 2000)
            {
                points = points / 1000;
                return $"Beginner {points + 1}";
            }
            else if (points < 6000)
            {
                points -= 2000;
                points = points / 1000;
                return $"Novice {points + 1}";
            }
            else if (points < 12000)
            {
                points -= 6000;
                points = points / 1000;
                return $"Intermediate {points + 1}";
            }
            else if (points < 20000)
            {
                points -= 12000;
                points = points / 1000;
                return $"Advanced {points + 1}";
            }
            else
            {
                points -= 20000;
                points = points / 1000;
                return $"Master of Goals {points + 1}";
            }
        }
    }
}