using System;

class Program
{
    static void Main(string[] args)
    {
        string userInput = "";
        BreathingActivity breathingActivity = new BreathingActivity("Breathing Activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.", 30);
        ReflectingActivity reflectingActivity = new ReflectingActivity("Reflecting Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.", 30);
        ListingActivity listingActivity = new ListingActivity("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", 30);
        while (userInput != "4")
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine(" 1. Start breathing activity");
            Console.WriteLine(" 2. Start reflecting activity");
            Console.WriteLine(" 3. Start listing activity");
            Console.WriteLine(" 4. Quit");
            Console.Write("Select a choice from the menu: ");
            userInput = Console.ReadLine();

            if (userInput == "1")
            {
                breathingActivity.DisplayStartMessage();
                breathingActivity.RunBreaths();
                breathingActivity.DisplayEndMessage();
            }
            else if (userInput == "2")
            {
                reflectingActivity.DisplayStartMessage();
                reflectingActivity.DisplayPrompt();
                reflectingActivity.DisplayQuestion();
                reflectingActivity.DisplayEndMessage();
            }
            else if (userInput == "3")
            {
                listingActivity.DisplayStartMessage();
                listingActivity.DisplayPrompt();
                listingActivity.DisplayUserInput();
                listingActivity.DisplayListNum();
                listingActivity.DisplayEndMessage();
            }
            else if (userInput != "4")
            {
                Console.Write($"\nThat is not a valid option. Press enter to continue: ");
                Console.ReadLine();
            }
        }
    }
}