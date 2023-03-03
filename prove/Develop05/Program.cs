using System;

class Program
{
    static void Main(string[] args)
    {
        int points = 0;
        string userInput = "";

        while (userInput != "6")
        {
            Console.Clear();
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

            }
            else if (userInput == "2")
            {

            }
            else if (userInput == "3")
            {
                
            }
            else if (userInput == "4")
            {
                
            }
            else if (userInput == "5")
            {
                
            }
            else if (userInput == "6"){}
            else
            {
                Console.WriteLine("That input is not valid.");
                Console.Write("Press enter to continue:");
                Console.ReadLine();
            }
        }
    }
}