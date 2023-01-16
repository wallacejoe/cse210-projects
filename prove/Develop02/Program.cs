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
                Entry entry1 = new Entry();
                entry1._prompt = RandomPrompt();
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
                Reader reader1 = new Reader();
                Console.Write("What is the file name? ");
                string filename = Console.ReadLine();
                reader1._filename = filename;

                entries = reader1.CreateFile();
            }
            else if (userInput == "4")
            {
                Writer writer1 = new Writer();
                Console.Write("Enter the file name: ");
                string fileName = Console.ReadLine();
                writer1._filename = fileName;
                writer1._entries = entries;
                writer1.SaveFile();
            }
        } while (userInput != "5");
        
        static string RandomPrompt()
        {
            List<string> prompts = new List<string>() {
                "What was the most random thing that happened today?",
                "What is something new you've leared today?",
                "What was the most productive thing you've done today?",
                "What do you wish you would've done today?",
                "Who was the most interesting person I interacted with today?",
                "What was the best part of my day?",
                "How did I see the hand of the Lord in my life today?",
                "What was the strongest emotion I felt today?",
                "If I had one thing I could do over today, what would it be?"
                };

                Random randomGenerator = new Random();
                int magicNum = randomGenerator.Next(1, prompts.Count);

                string randomString = prompts[magicNum];

            return randomString;
        }
    }
}