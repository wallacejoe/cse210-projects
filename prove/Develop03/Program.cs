using System;

class Program
{
    static void Main(string[] args)
    {
        string userInput;

        do {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press enter to continue or type 'quit' to finish:");
            userInput = Console.ReadLine();
        } while (userInput != "quit");
    }
}