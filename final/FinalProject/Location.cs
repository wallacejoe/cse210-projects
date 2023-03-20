using System;
public class Location
{
    private List<Mobs> _mobs = new List<Mobs>();
    private List<Loot> _loot = new List<Loot>();
    private string _description;
    private string _locationName;

    /*Constructors*/
    public Location(string locationName, string description)
    {
        _description = description;
        _locationName = locationName;
    }

    public Location(string locationName, string description, List<Mobs> mobs, List<Loot> loot)
    {
        _description = description;
        _locationName = locationName;
        _mobs = mobs;
        _loot = loot;
    }

    /*Methods*/
    public void LocationDescription()
    {
        Console.Clear();
        Console.WriteLine(_locationName);
        Console.WriteLine();
        Console.WriteLine(_description);
    }

    public void InteractionMenu()
    {
        Console.WriteLine("  1. Interact with chest loot");
        Console.WriteLine("  2. Interact with mob loot");
        Console.Write("Select a choice from the menu: ");
        string userInput = Console.ReadLine();
        if (userInput == "1")
        {

        }
        else if (userInput == "2")
        {
            
        }
    }
}