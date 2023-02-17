using System;

class Program
{
    static void Main(string[] args)
    {
        string userInput = "";
        while (userInput != "4")
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine(" 1. Start breathing activity");
            Console.WriteLine(" 2. Start relecting activity");
            Console.WriteLine(" 3. Start listing activity");
            Console.WriteLine(" 4. Quit");
            Console.Write("Select a choice from the menu: ");
            userInput = Console.ReadLine();

            if (userInput == "1")
            {
                BreathingActivity breathingActivity = new BreathingActivity("Breathing Activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.", 30);
                breathingActivity.DisplayStartMessage();
                breathingActivity.RunBreaths();
                breathingActivity.DisplayEndMessage();
            }
            else if (userInput == "2")
            {

            }
            else if (userInput == "3")
            {
                
            }
            else if (userInput != "4")
            {
                Console.Write($"\nThat is not a valid option. Press enter to continue: ");
                Console.ReadLine();
            }
        }
    }
}