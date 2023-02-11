using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string userInput;
        Journal journal1 = new Journal();

        do
        {
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            userInput = Console.ReadLine();

            if (userInput == "1")
            {
                PromptGenerator prompt = new PromptGenerator();
                string chosenPrompt = prompt.RandomPrompt();
                Console.WriteLine(chosenPrompt);
                string userEntry = Console.ReadLine();
                Entry entry1 = new Entry(chosenPrompt, userEntry);

                journal1.AddEntries(entry1.FullJournalEntry());
            }
            else if (userInput == "2")
            {
                journal1.Display();
            }
            else if (userInput == "3")
            {
                Console.Write("What is the file name? ");
                string filename = Console.ReadLine();
                File reader = new File(filename, journal1.GetEntries());
                journal1.SetEntries(reader.ParseFile());
            }
            else if (userInput == "4")
            {
                Console.Write("Enter the file name: ");
                string filename = Console.ReadLine();
                File writer = new File(filename, journal1.GetEntries());
                writer.SaveFile();
            }
        } while (userInput != "5");
    }
}