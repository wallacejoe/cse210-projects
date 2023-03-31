using System;
public class Environment
{
    private Location _currentLocal;
    private Character _playerCharacter;
    private List<Location> _allLocations = new List<Location>();

    /*Constructors*/
    public Environment()
    {
        InitializeLocations();
        _currentLocal = _allLocations[0];
        _playerCharacter = new Character();
    }

    public Environment(Character playerCharacter)
    {
        //_currentLocal = currentLocal;
        _playerCharacter = playerCharacter;
        //_allLocations = allLocations;
        InitializeLocations();
        _currentLocal = _allLocations[0];
    }

    /*Methods*/
    public void MainMenu()
    {
        string userInput = "";
        while (userInput != "4")
        {
            Console.Clear();
            Console.WriteLine("Main menu:");
            Console.WriteLine("  1. Back to game");
            Console.WriteLine("  2. Character Menu");
            Console.WriteLine("  3. Keyboard shortcuts");
            Console.WriteLine("  4. Save and Quit");
            Console.Write("Select a choice from the menu: ");
            userInput = Console.ReadLine();

            if (userInput == "1")
            {
                bool localChange = _currentLocal.InteractionMenu(_playerCharacter);
                if (localChange)
                {
                    ChangeLocation();
                }
            }
            else if (userInput == "2")
            {
                _playerCharacter.CharacterMenu();
            }
            else if (userInput == "3")
            {
                Console.Clear();
                Console.WriteLine("c. Character menu");
                Console.Write("Press enter to continue:");
                Console.ReadLine();
            }
            else if (userInput == "4")
            {
                List<string> saveToFile = new List<string>();
                Console.WriteLine("Leave blank if you'd like to quit without saving");
                Console.Write("Enter the file you'd like to save to: ");
                File file = new File(Console.ReadLine());
                foreach (string line in _playerCharacter.Serialize())
                {
                    saveToFile.Add(line);
                }
                foreach (Location area in _allLocations)
                {
                    foreach (string line in area.Serialize())
                    {
                        saveToFile.Add(line);
                    }
                }
                file.WriteToFile(saveToFile);
            }
            else {
                Console.Write("That input was not valid. Press enter to continue:");
                Console.ReadLine();
            }
        }
    }

    private void ChangeLocation()
    {
        Console.Clear();
        int listNum = 0;
        foreach (Location local in _allLocations)
        {
            listNum += 1;
            Console.WriteLine($"  {listNum}. {local.GetLocationName()}");
        }
        Console.Write("Enter the location you'd like to move to: ");
        try
        {
            int chosenLocal = int.Parse(Console.ReadLine()) - 1;
            _currentLocal = _allLocations[chosenLocal];
        } catch {}
        _currentLocal.InteractionMenu(_playerCharacter);
    }

    private void InitializeLocations()
    {
        _allLocations.Add(new Location("forest", "A dense forest, thick enough to block most light, unnerving sounds eminate from the trees around you."));
        _allLocations.Add(new Location("swamp", "This foul bog reeks of death and decay, and has several steaming pools of some unknown substance. Aside from a constant hiss from the pools, the swamp is unnaturally silent."));
    }

    public List<string> Serialize()
    {
        List<string> listToSerialize = new List<string>();

        return listToSerialize;
    }
}