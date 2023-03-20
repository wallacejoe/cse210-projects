using System;
public class Environment
{
    private Location _currentLocal;
    private List<Location> _allLocations = new List<Location>();

    /*Constructors*/
    public Environment(){}

    public Environment(Location currentLocal)
    {
        _currentLocal = currentLocal;
    }

    /*Methods*/
    public void ActionMenu()
    {
        Console.Clear();
        Console.WriteLine("  1. Interact with location");
        Console.WriteLine("  2. Move to new location");
        Console.WriteLine("  3. Combat");
        Console.WriteLine("  4. Character Menu");
        Console.WriteLine("  5. Save and Quit");
        Console.Write("Select a choice from the menu: ");
        string userInput = Console.ReadLine();

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
        else if (userInput == "6")
        {

        }
        else {
            Console.Write("That input was not valid. Press enter to continue:");
            Console.ReadLine();
        }
    }

}