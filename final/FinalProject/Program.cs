using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Would you like to load a saved game (y/n)? ");
        string userInput = Console.ReadLine();
        Environment environment;
        
        if (userInput == "y")
        {
            Console.Write("Enter the file you'd like to load from: ");
            string filename = Console.ReadLine();
            File file = new File(filename);
            file.Deserialize();
            Character loadCharacter = file.CreateCharacterClass();
            environment = new Environment(file.GetLocalNum(), loadCharacter, file.CreateLocationClasses());
        }
        else
        {
            environment = new Environment();
        }
        environment.MainMenu();
    }
}