using System;

class Program
{
    static void Main(string[] args)
    {
        string scriptureBook;
        string scriptureChapter;
        string[] fullScripRef;
        string userInput = "";
        Console.Write("Would you like to load a file (y/n)? ");
        string usersChoice = Console.ReadLine();

        /*Set scripture to be used.*/
        if (usersChoice == "y")
        {
            try
            {
                Console.WriteLine("Enter the filename: ");
                string filename = Console.ReadLine();
                File chosenFile = new File(filename);
                List<string> fileContent = chosenFile.ParseFile();
                scriptureBook = fileContent[0];
                scriptureChapter = fileContent[1];
                if (fileContent.Count() > 3)
                {
                    List<string> newList = new List<string>();
                    for (int i = 2; i < fileContent.Count(); i++)
                    {
                        newList.Add(fileContent[i]);
                    }
                    string[] scriptureText = newList.ToArray();
                    Reference scripRef = new Reference(scriptureBook, scriptureChapter, scriptureText);
                    fullScripRef = scripRef.FullReference();
                }
                else
                {
                    string scriptureText = fileContent[2];
                    Reference scripRef = new Reference(scriptureBook, scriptureChapter, scriptureText);
                    fullScripRef = scripRef.FullReference();
                }
            } catch {
                Console.WriteLine("Your filename was not valid.");
                Console.WriteLine("Press enter to continue with the defualt text: ");
                Console.ReadLine();
                scriptureBook = "Proverbs";
                scriptureChapter = "3:5-6";
                string[] scriptureText = {"Trust in the Lord with all thine heart and lean not unto thine own understanding;", "in all thy ways acknowledge him, and he shall direct thy paths."};
                Reference scripRef = new Reference(scriptureBook, scriptureChapter, scriptureText);
                fullScripRef = scripRef.FullReference();
            }
        }
        else
        {
            scriptureBook = "Proverbs";
            scriptureChapter = "3:5-6";
            string[] scriptureText = {"Trust in the Lord with all thine heart and lean not unto thine own understanding;", "in all thy ways acknowledge him, and he shall direct thy paths."};
            Reference scripRef = new Reference(scriptureBook, scriptureChapter, scriptureText);
            fullScripRef = scripRef.FullReference();
        }

        //Give the scripture class it's initial value.
        Scripture scrip = new Scripture(fullScripRef);

        //Loops the program until the user enters 'quit'.
        while (userInput != "quit") {
            Console.Clear();
            Console.WriteLine(scrip.GetRenderedText());
            Console.WriteLine();
            userInput = scrip.IsCompletelyHidden();
        }
    }
}