using System;

class Program
{
    static void Main(string[] args)
    {
        Environment environment;
        bool successfulLoad = false;

        while (!successfulLoad)
        {
            Console.Write("Would you like to load a saved game (y/n)? ");
            string userInput = Console.ReadLine();
            
            successfulLoad = true;
            if (userInput == "y")
            {
                try
                {
                    Console.Write("Enter the file you'd like to load from: ");
                    string filename = Console.ReadLine();
                    File file = new File(filename);
                    file.Deserialize();
                    Character loadCharacter = file.CreateCharacterClass();
                    environment = new Environment(file.GetLocalNum(), loadCharacter, file.CreateLocationClasses());
                    environment.MainMenu();
                } catch {successfulLoad = false;}
            }
            else
            {
                environment = new Environment();
                environment.MainMenu();
            }
        }
    }
}