using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string userInput;
        List<string> entries = new List<string>();

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
                Entry entry1 = new Entry();
                entry1._prompt = prompt.RandomPrompt();
                Console.WriteLine(entry1._prompt);
                entry1._userEntry = Console.ReadLine();

                entries.Add(entry1.FullJournalEntry());
            }
            else if (userInput == "2")
            {
                foreach (string line in entries)
                {
                    Console.WriteLine(line);
                }
            }
            else if (userInput == "3")
            {
                File reader1 = new File();
                Console.Write("What is the file name? ");
                string filename = Console.ReadLine();
                reader1._filename = filename;

                entries = reader1.CreateFile();
            }
            else if (userInput == "4")
            {
                File writer1 = new File();
                Console.Write("Enter the file name: ");
                string fileName = Console.ReadLine();
                writer1._filename = fileName;
                writer1._entries = entries;
                writer1.SaveFile();
            }
        } while (userInput != "5");
    }
}