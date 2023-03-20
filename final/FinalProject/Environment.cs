using System;
public class Environment
{
    private Location _currentLocal;
    private List<Location> _allLocations = new List<Location>();

    /*Constructors*/
    public Environment()
    {
        InitializeLocations();
        _currentLocal = _allLocations[0];
    }

    public Environment(Location currentLocal)
    {
        _currentLocal = currentLocal;
    }

    /*Methods*/
    public void ActionMenu()
    {
        string userInput = "";
        while (userInput != "4")
        {
            Console.Clear();
            Console.WriteLine("Environment menu:");
            Console.WriteLine("  1. Interact with location");
            Console.WriteLine("  2. Move to new location");
            Console.WriteLine("  3. Character Menu");
            Console.WriteLine("  4. Save and Quit");
            Console.Write("Select a choice from the menu: ");
            userInput = Console.ReadLine();

            if (userInput == "1")
            {
                _currentLocal.InteractionMenu();
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
            else {
                Console.Write("That input was not valid. Press enter to continue:");
                Console.ReadLine();
            }
        }
    }

    private void InitializeLocations()
    {
        _allLocations.Add(new Location("forest", "A dense forest, thick enough to block most light, unnerving sounds eminate from the trees around you."));
        _allLocations.Add(new Location("swamp", "This foul bog reeks of death and decay, and has several steaming pools of some unknown substance. Aside from a constant hiss from the pools, the swamp is unnaturally silent."));
    }

}